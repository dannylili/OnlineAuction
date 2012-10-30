using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using OnlineAuction.Business.BusinessRulesEngine.Common;

namespace OnlineAuction.Business.Extension
{
    public static class ExtensionIqueryable
    {
        //public static IQueryable<T> Where<T>(this IQueryable<T> source, ICondition filterCondition)
        //{
        //    var type = typeof(T);
        //    var argument = Expression.Parameter(type, "x");
        //    var expression = filterCondition.ToExpression(argument);

        //    var expressionType = typeof(Func<,>).MakeGenericType(type, typeof(bool));
        //    var lambda = Expression.Lambda(expressionType, expression, argument);

        //    var methodCallExpression = Expression.Call(typeof(Queryable), "Where", new[] { source.ElementType }, source.Expression, lambda);

        //    return source.Provider.CreateQuery<T>(methodCallExpression);
        //}

        public static IQueryable<TU> Select<T, TU>(this IQueryable<T> source, IExpression selectExpression)
        {
            return source.Select(selectExpression, typeof(TU)) as IQueryable<TU>;
        }

        public static IQueryable Select<T>(this IQueryable<T> source, IExpression selectExpression, Type filterPropertyType)
        {
            var type = typeof(T);

            var parameter = Expression.Parameter(type, "x");
            var expression = selectExpression.ToExpression(parameter);

            var expressionType = typeof(Func<,>).MakeGenericType(type, filterPropertyType);
            var lambda = Expression.Lambda(expressionType, expression, parameter);
            var methodCallExpression = Expression.Call(typeof(Queryable), "Select", new[] { source.ElementType, filterPropertyType }, source.Expression, lambda);
            source.Provider.CreateQuery(methodCallExpression);
            return source.Provider.CreateQuery(methodCallExpression);
        }

        public static IQueryable<object> Select(this IQueryable source, IExpression selectExpression)
        {
            var type = source.ElementType;

            var parameter = Expression.Parameter(type, "x");
            var expression = selectExpression.ToExpression(parameter);

            var expressionType = typeof(Func<,>).MakeGenericType(type, expression.Type);
            var lambda = Expression.Lambda(expressionType, expression, parameter);
            var methodCallExpression = Expression.Call(
                typeof(Queryable), "Select", new[] { source.ElementType, expression.Type }, source.Expression, lambda);
            return source.Provider.CreateQuery(methodCallExpression) as IQueryable<object>;
        }
    }
}
