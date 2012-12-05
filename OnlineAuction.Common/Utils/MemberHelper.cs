using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Genuit.Promys.Common.Utils
{
    public static class MemberHelper
    {
        public static Expression GetMember<T>(string property, ParameterExpression arg)
        {
            return GetMember(typeof(T), property, arg);
        }

        public static Expression GetMember(Type T, string memberPath, ParameterExpression arg)
        {
            var type = T;
            var members = memberPath.Split('.');
            Expression expr = arg;
            foreach (var member in members)
            {
                if (member.IsProperty())
                {
                    expr = GetProperty(type, member, expr);
                }
                if (member.IsMethod())
                {
                    expr = GetMethod(type, member, expr);
                }
                type = expr.Type;
            }
            return expr;
        }

        private static Expression GetMethod(Type type, string member, Expression expr)
        {
            var methodName = member.Trim(new[] { '(', ')' });
            return Expression.Call(expr, methodName, null);
        }

        private static bool IsProperty(this string data)
        {
            return !data.IsMethod();
        }

        private static bool IsMethod(this string data)
        {
            return data.Contains("(") && data.Contains(")");
        }

        public static Expression GetProperty(Type T, string property, Expression arg)
        {
            var type = T;
            var pi = type.GetProperty(property);
            if (pi == null)
            {
                var pis = type.GetPublicProperties();
                pi = pis.First(p => p.Name == property);
            }
            return Expression.Property(arg, pi);
        }

        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var propertyInfos = new List<PropertyInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface)) continue;

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var typeProperties = subType.GetProperties(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);

                    var newPropertyInfos = typeProperties
                        .Where(x => !propertyInfos.Contains(x));

                    propertyInfos.InsertRange(0, newPropertyInfos);
                }

                return propertyInfos.ToArray();
            }

            return type.GetProperties(BindingFlags.FlattenHierarchy
                | BindingFlags.Public | BindingFlags.Instance);
        }

        public static string ToAttributeToken(this PropertyInfo member)
        {
            return string.Format("{0}.{1}", member.ReflectedType.Name, member.Name);
        }

        public static string ToAttributeToken(this PropertyInfo member, string entityToken)
        {
            return string.Format("{0}.{1}", entityToken, member.Name);
        }

        public static string ToAttributeName(this PropertyInfo member)
        {
            return string.Format("{0}", member.Name);
        }
    }
}
