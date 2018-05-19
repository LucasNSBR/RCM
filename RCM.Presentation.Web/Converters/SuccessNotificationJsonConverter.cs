using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RCM.Domain.DomainNotifications;
using System;

namespace RCM.Presentation.Web.Converters
{
    public class SuccessNotificationJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CommandSuccessNotification);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var body = jObject.Value<string>("Body");

            return new CommandSuccessNotification(body);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("You cant invoke this method directly.");
        }
    }
}
