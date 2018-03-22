using System;
using System.Collections.Generic;

namespace RCM.Domain.Emails
{
    public abstract class EmailTemplate
    {
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string TemplateId { get; private set; }
        public Dictionary<string, string> SendGridSubstitutions { get; private set; }

        public EmailTemplate(string to)
        {
            To = to;
            SendGridSubstitutions = new Dictionary<string, string>();
        }

        public void AddTo(string to)
        {
            To = to;
        }

        public void SetSendGridTemplateId(string templateId)
        {
            TemplateId = templateId;
        }

        public void AddSendGridSubstitutions(string key, string value)
        {
            if (SendGridSubstitutions.ContainsKey(key))
                throw new ArgumentException();

            SendGridSubstitutions.Add(key, value);
        }
    }
}
