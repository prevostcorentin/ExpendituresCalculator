using SpentCalculator.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SpentCalculator.Services
{
    public static class JsonTransformer
    {
        public static ICollection<FilterCriteria> JObjectToFilterCriterias(JObject json)
        {
            List<FilterCriteria> criterias = new List<FilterCriteria>();
            foreach (KeyValuePair<String, JToken> element in json)
            {
                FilterCriteria singleCriteria = new FilterCriteria { Name = element.Key, Value = element.Value };
                criterias.Add(singleCriteria);
            }
            return criterias;
        }

        public static dynamic GetTypedFilterCriteriaValue(FilterCriteria criteria)
        {
            JsonElement element = (JsonElement)criteria.Value;
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

        public static String SerializeObject(IEnumerable<Spent> filteredResults)
        {
            return JsonConvert.SerializeObject(filteredResults);
        }

        internal static Byte[] JObjectToBytes(JObject response)
        {
            String stringified = response.ToString();
            Byte[] bytified = Encoding.Default.GetBytes(stringified);
            return bytified;
        }
    }
}