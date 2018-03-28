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

        private Dictionary<string, string> _sendGridSubstitutions;
        public IReadOnlyDictionary<string, string> SendGridSubstitutions
        {
            get
            {
                return _sendGridSubstitutions;
            }
        }

        public EmailTemplate(string to)
        {
            To = to;

            _sendGridSubstitutions = new Dictionary<string, string>();
        }

        public void SetSendGridTemplateId(string templateId)
        {
            TemplateId = templateId;
        }

        public void AddSendGridSubstitutions(string key, string value)
        {
            if (SendGridSubstitutions.ContainsKey(key))
                throw new ArgumentException();

            _sendGridSubstitutions.Add(key, value);
        }
    }
}
