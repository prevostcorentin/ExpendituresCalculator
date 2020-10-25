using SpentCalculator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SpentCalculator.Services
{
    public static class JsonTransformer
    {
        public static dynamic JsonElementToTypedValue(JsonElement element)
        {
            switch(element.ValueKind)
            {
                case JsonValueKind.Number:
                    return element.GetDecimal();
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return element.GetBoolean();
                default:
                    return element.GetString();
            }
        }
    }
}