using System;

using System.Linq.Expressions;

namespace Peak.EStore.Infrastructure.Querying
{
    public class Criterion
    {
        private  string _propertyName;
        private  object _value;
        private  CriteriaOperator _criteriaOperator;
        public Criterion(string propertyName, object value,CriteriaOperator criteriaOperator)
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
        }
        public string PropertyName
        {
            get { return _propertyName; }
        }
        public object Value
        {
            get { return _value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
        }

        #region This helper method will allow users to create Criterion objects like so: aQuery.Add(Criterion.Create<Product>(p => p.Colour.Id, id,CriteriaOperator.Equal));
        public static Criterion Create<T>(Expression<Func<T, object>> expression,object value,CriteriaOperator criteriaOperator)
        {
            var propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            var myCriterion = new Criterion(propertyName, value,
            criteriaOperator);
            return myCriterion;
        }
        #endregion
    }
}