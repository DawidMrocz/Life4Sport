using Framework.Shared.Models.Email;
using System.Net.Mail;

namespace Framework.Shared.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(IEnumerable<MailAddress> to,
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
            MailPriority emailPriority = MailPriority.Normal);
    }
}
