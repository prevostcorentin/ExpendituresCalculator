using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpendituresCalculator.Services
{
    public class FilterCriteriaAggregator
    {
        public static IEnumerable<IntervalledFilterCriteria> AggregateFilterCriterias(IEnumerable<FilterCriteria> criterias)
        {
            Queue<IntervalledFilterCriteria> aggregatedCriterias = new Queue<IntervalledFilterCriteria>();
            IEnumerable<IGrouping<string, FilterCriteria>> groupedCriterias = criterias.GroupBy(c => c.Name.ToLower().Substring(3));
            foreach (IGrouping<String, FilterCriteria> group in groupedCriterias)
            {
                var intervalledFilterCriteria = new IntervalledFilterCriteria
                {
                    Name = group.Key,
                    Max = group.Where(c => c.Name.ToLower().StartsWith("max"))
                               .Select(c => c.Value).FirstOrDefault(),
                    Min = group.Where(c => c.Name.ToLower().StartsWith("min"))
                               .Select(c => c.Value).FirstOrDefault()
                };
                intervalledFilterCriteria.Value = Convert.ToString(intervalledFilterCriteria.Min) + " > " + intervalledFilterCriteria.Name + " > " + Convert.ToString(intervalledFilterCriteria.Max);
                aggregatedCriterias.Enqueue(intervalledFilterCriteria);
            }
            return aggregatedCriterias;
        }
    }
}