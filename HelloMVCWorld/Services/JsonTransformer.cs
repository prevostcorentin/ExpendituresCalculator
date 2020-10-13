using ExpendituresCalculator.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ExpendituresCalculator.Services
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

        public static String SerializeObject(IEnumerable<Spent> filteredResults)
        {
            return JsonConvert.SerializeObject(filteredResults);
        }
    }
}