using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Server.Extensions
{
    public static class ObjectExtensions
    {
        public static string CustomSerialize(this int obj, object dataForSerialization)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string serializedString = JsonSerializer.Serialize(dataForSerialization, options);
            return serializedString;
        }
    }
}
