using SpentCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpentCalculator.Exceptions
{
    public class InvalidCriteriaException : Exception
    {
        private Type _type;
        private FilterCriteria _criteria;

        public InvalidCriteriaException(Type type, FilterCriteria criteria)
        {
            this._type = type;
            this._criteria = criteria;
        }

        public InvalidCriteriaException(String message) : base(message)
        {
        }

        public override string Message
        {
            get
            {
                String resultingMessage = $"Criteria {this._criteria} does not match any object's property. Possible keys are: ";
                IEnumerable<String> typeNames = _type.GetProperties().Select(p => p.Name);
                resultingMessage = resultingMessage + String.Join(", ", typeNames);
                return resultingMessage;
            }
        }

        public override String ToString()
        {
            return Message;
        }
    }
}
