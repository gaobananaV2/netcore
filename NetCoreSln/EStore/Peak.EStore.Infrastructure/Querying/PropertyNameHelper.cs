using System;
using System.Linq.Expressions;

namespace Peak.EStore.Infrastructure.Querying
{

    public static class PropertyNameHelper
    {
        public static string ResolvePropertyName<T>(Expression<Func<T, object>> expression)
        {
            var expr = expression.Body as MemberExpression;
            if (expr != null) return expr.ToString().Substring(expr.ToString().IndexOf(".") + 1);
            var u = expression.Body as UnaryExpression;
            expr = u.Operand as MemberExpression;
            return expr.ToString().Substring(expr.ToString().IndexOf(".") + 1);
        }
    }

    //This allows you to add a new criterion to a query, like so
    //aQuery.Add(new Criterion(PropertyNameHelper.ResolvePropertyName<Product>(p => p.Colour.Id), id, CriteriaOperator.Equal));
    //instead of using magic strings, as shown in the code snippet that follows:
    //aQuery.Add(new Criterion(“Colour.Id”, id, CriteriaOperator.Equal));

    //However, that’s still a bit of a mouthful, so to make it even easier to create  Criterion objects
    //aQuery.Add(Criterion.Create<Product>(p => p.Colour.Id, id,CriteriaOperator.Equal));

}