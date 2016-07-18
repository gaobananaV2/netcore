using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peak.EStore.Infrastructure.Domain
{
    public abstract class ValueObjectBase
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();
        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();
            if (!_brokenRules.Any()) return;
            var issues = new StringBuilder();
            foreach (var businessRule in _brokenRules)
                issues.AppendLine(businessRule.Rule);
            throw new ValueObjectIsInvalidException(issues.ToString());
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }

    //an exception will be thrown if it is invalid. The  ThrowExceptionIfInvalid will be called from the subclasses constructor
}