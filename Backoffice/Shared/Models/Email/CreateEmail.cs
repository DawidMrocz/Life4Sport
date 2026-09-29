using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.Models.Email
{
    public class CreateEmail : BaseModel
    {
        public required MailAddress From { get; set; }
        public int CreateUserId { get; set; }
        public string? TemplateName;
        public int CultureId;
        public List<ReplacedParam> Params = new();
        public bool AsHtml { get; set; }

        public required IEnumerable<MailAddress> To { get; set; }
        public IEnumerable<MailAddress>? Cc { get; set; }
        public IEnumerable<MailAddress>? Bcc { get; set; }
        public IEnumerable<MailAddress>? ReplyTo { get; set; }
        public IEnumerable<int> FileIds { get; set; } = Enumerable.Empty<int>();

        public class ReplacedParam
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public ReplacedParam(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
