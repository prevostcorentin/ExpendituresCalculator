﻿using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.InteropServices.ComTypes;

namespace ExpendituresCalculator.Services
{
    public struct FilterCriteria
    {
        public String Name { get; set; }
        public object Value { get; set; }

        public override String ToString() => $"[{Name}]";
    }

    public class Filter<T>
    {
        public IEnumerable<T> Data { get; set; }
        public ICollection<FilterCriteria> Criterias { get; set; }
        public IEnumerable<T> Result
        { 
            get
            {
                var matchingSet = new Queue<T>();
                foreach (T filterable in Data)
                {
                    if (IsObjectMatching(filterable))
                    {
                        matchingSet.Enqueue(filterable);
                    }
                }
                return matchingSet;
            }
        }

        public bool IsObjectMatching(object filterable)
        {
            foreach (FilterCriteria criteria in Criterias)
            {
                if (IsCriteriaMatchesFilterable(criteria, filterable))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsCriteriaMatchesFilterable(FilterCriteria criteria, object filterable)
        {
            bool filterableContainsCriteria = filterable.GetType().GetProperties()
                                                        .Select(p => p.Name.ToLower())
                                                        .Any(name => name == criteria.Name.ToLower());
            if (!filterableContainsCriteria)
            {
                throw new Exceptions.InvalidCriteriaException(filterable.GetType(), criteria);
            }
            
            object propertyValue = filterable.GetType().GetProperty(criteria.Name).GetValue(filterable);
            if (Utils.Reflection.Equals(criteria.Value, propertyValue))
            {
                return true;
            }
            return false;
        }
    }
}
