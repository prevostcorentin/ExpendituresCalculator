using ExpendituresCalculator.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;

namespace ExpendituresCalculator.Services
{
    public static class JsonTransformer
    {
        public static ICollection<FilterCriteria> JObjectToFilterCriterias(JObject json)
        {
            List<FilterCriteria> criterias = new List<FilterCriteria>();
            foreach (KeyValuePair<String, JToken> element in json)
            {
                FilterCriteria singleCriteria = new FilterCriteria { Name = element.Key, Value = element.Value.ToString() };
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