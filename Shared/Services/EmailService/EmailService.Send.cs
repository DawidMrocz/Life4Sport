using Framework.Shared.Configuration;
using Framework.Shared.Models.Template;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Shared.Services.EmailService
{
    internal partial class EmailService<TDbContext>
    {
        public async Task SendEmail(
            IEnumerable<MailAddress> to,
            string templateString,
            bool bodyAsHtml,
            int cultureId,
            MailAddress? from = null,
            Dictionary<string, string>? bodyParams = null,
            Dictionary<string, string>? subjectParams = null,
            IEnumerable<Attachment>? attachmets = null,
            IEnumerable<MailAddress>? cc = null,
            IEnumerable<MailAddress>? bcc = null,
            IEnumerable<MailAddress>? replyTo = null,
            MailPriority emailPriority = MailPriority.Normal
            )
        {
            //POBRANIE TEMPLATE
            TemplateModel? templateMailAddress = await _dbSet.FirstOrDefaultAsync(t => t.Name == templateString && t.CultureId == cultureId)
                ?? throw new Exception("Template not found");

            if (templateMailAddress.Body is null || templateMailAddress.Subject is null) throw new Exception("Subject or body not provided");

            //PODMIANA PARAMETRÓW BODY
            if (bodyParams is not null)
                foreach (KeyValuePair<string, string> parameter in bodyParams)
                    templateMailAddress.Body = templateMailAddress.Body.Replace("{{" + parameter.Key + "}}", parameter.Value);

            //PODMIANA PARAMETRÓW SUBJECT
            if (subjectParams is not null)
                foreach (KeyValuePair<string, string> parameter in subjectParams)
                    templateMailAddress.Subject = templateMailAddress.Subject.Replace("{{" + parameter.Key + "}}", parameter.Value);

            //OCZYSZCZENIE HTML Z PODEJRZANEGO JAVASCRIPT
            if (bodyAsHtml) //  ADD CHECK IF SANITIZE SETTING
                templateMailAddress.Body = SanitizeBody(templateMailAddress.Body);

            using (SmtpClient smtpClient = new())
            {
                using (MailMessage message = new())
                {
                    //SETTINGS
                    string? _mailLogin = FrameworkConfiguration.User;
                    string? _mailPassword = FrameworkConfiguration.Password;

                    //--------------------------------CLIENT DEFINITION---------------------------------------------
                    smtpClient.Host = FrameworkConfiguration.EmailServer;
                    if (!string.IsNullOrEmpty(_mailLogin) && !string.IsNullOrEmpty(_mailPassword))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(_mailLogin, _mailPassword);
                    }
                    smtpClient.Port = FrameworkConfiguration.EmailPort;
                    smtpClient.Timeout = 12000;
                    smtpClient.EnableSsl = FrameworkConfiguration.EnableSSL;
                    //----------------------------------------------------------------------------------------------


                    //--------------------------------MESSAGE DEFINITION--------------------------------------------
                    message.From = from ?? new MailAddress("_settingService.Get(\"VeloceMailFrom\"");
                    message.Subject = templateMailAddress.Subject;
                    message.SubjectEncoding = Encoding.UTF8;
                    message.IsBodyHtml = bodyAsHtml;
                    message.Body = templateMailAddress.Body;
                    message.BodyEncoding = Encoding.UTF8;
                    message.Priority = emailPriority;
                    foreach (MailAddress receiver in to) message.To.Add(receiver);
                    if (cc is not null) foreach (MailAddress item in cc) message.CC.Add(item);
                    if (bcc is not null) foreach (MailAddress item in bcc) message.Bcc.Add(item);
                    if (replyTo is not null) foreach (MailAddress item in replyTo) message.ReplyToList.Add(item);

                    //DODANIE ZAŁĄCZNIKÓW
                    if (attachmets is not null)
                        foreach (Attachment attachmet in attachmets)
                            message.Attachments.Add(new Attachment(attachmet.ContentStream, attachmet.Name));

                    //PODMIANA OBRAZKÓW W BODY JEŻELI BODY TO HTML
                    if (bodyAsHtml) SetEmbeddedImages(message);
                    //----------------------------------------------------------------------------------------------

                    try
                    {
                        ServicePointManager.DefaultConnectionLimit = 100;
                        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
                        smtpClient.Send(message);
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {
                        foreach (SmtpFailedRecipientException innerEx in ex.InnerExceptions)
                        {
                            SmtpStatusCode status = innerEx.StatusCode;
                            if (status is SmtpStatusCode.MailboxBusy or SmtpStatusCode.MailboxUnavailable)
                            {
                                Thread.Sleep(5000);
                                smtpClient.Send(message);
                            }
                            else
                            {
                                //_logger.Error(GetType(), $"Failed to deliver message to {innerEx.FailedRecipient}", ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //_logger.Error(GetType(), "Mail sending error", ex);
                    }
                }
            }

        }

        public static string SanitizeBody(string body)
        {
            //return HtmlAndSvgSanitizer.SanitizeText(HtmlAndSvgSanitizer.MoveCssInline(body));
            return string.Empty;
        }

        private void SetEmbeddedImages(MailMessage mailMessage)
        {
            string body = mailMessage.Body;
            HtmlDocument html = new();
            html.LoadHtml(body);
            HtmlNodeCollection images = html.DocumentNode.SelectNodes("//img");
            if (images != null && images.Any())
            {
                List<LinkedResource> linkedResources = new();
                foreach (HtmlNode? image in images)
                {
                    string base64Guid = image.Attributes["src"].Value.Split(',').Last();
                    if (string.IsNullOrEmpty(base64Guid)) continue;

                    byte[] fileBytes;
                    if (Regex.IsMatch(base64Guid, "^[a-zA-Z0-9+/]*={0,2}$"))
                    {
                        fileBytes = Convert.FromBase64String(base64Guid);
                    }
                    else
                    {
                        RestClient client = new();
                        RestRequest request = new(base64Guid, Method.Get);
                        RestResponse response = client.Execute(request);
                        if (!response.IsSuccessful) throw new Exception("Communication error...");
                        if (response.RawBytes is null) throw new Exception("Problem with image link");
                        fileBytes = response.RawBytes;
                    }
                    string contentIdGuid = Guid.NewGuid().ToString().Replace("-", "");
                    LinkedResource linkedResource = new(new MemoryStream(fileBytes));
                    linkedResource.ContentId = contentIdGuid;

                    Attachment att = new("C:\\xxx.png");
                    att.ContentDisposition!.Inline = true;
                    att.ContentId = contentIdGuid;
                    linkedResources.Add(linkedResource);
                    image.Attributes["src"].Value = $@"cid:{contentIdGuid}";
                    mailMessage.Attachments.Add(att);
                }
                mailMessage.Body = html.DocumentNode.OuterHtml;

                AlternateView? view = AlternateView.CreateAlternateViewFromString(mailMessage.Body, null, MediaTypeNames.Text.Html);
                linkedResources.ForEach(x => view.LinkedResources.Add(x));
                mailMessage.AlternateViews.Add(view);
            }
        }
    }
}
