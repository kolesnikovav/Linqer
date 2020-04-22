using System;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace Linqer
{
    /// <summary>
    /// Static class that represent some Linq expression
    /// </summary>    
    public static class LinqerExtention
    {
        internal static Expression GetExpressionByType(Expression left, Expression right, PredicateType pType)
        {
            if (pType == PredicateType.Equal) return Expression.Equal(left, right);
            if (pType == PredicateType.NotEqual) return Expression.NotEqual(left, right);
            if (pType == PredicateType.GreaterThan) return Expression.GreaterThan(left, right);
            if (pType == PredicateType.GreaterThanOrEqual) return Expression.GreaterThanOrEqual(left, right);
            if (pType == PredicateType.LessThan) return Expression.LessThan(left, right);
            if (pType == PredicateType.LessThanOrEqual) return Expression.LessThanOrEqual(left, right);
            return null; // unreachable
        }
        /// <summary>
        /// Comparing member of value with anover value. Comparison type should be set
        /// </summary>
        /// <param name="val">The source value. Left part of comparison</param>
        /// <param name="name">Name of field/property of source value</param>
        /// <param name="valCompare">The value to compare</param>
        /// <param name="pType">Comparison type</param>
        /// <returns>The comparison result</returns>        
        public static bool GetCustomPredicate<T>(T val,string name, object valCompare, PredicateType pType)
        {

            ParameterExpression parameterModelFind = Expression.Parameter(typeof(T), "a");
            MemberExpression propertyModelFind = Expression.Property(parameterModelFind, name);
            ConstantExpression cExpr = Expression.Constant(valCompare);
            Expression ex = GetExpressionByType(propertyModelFind, cExpr, pType);
            LambdaExpression la = Expression.Lambda(ex,new ParameterExpression[] {parameterModelFind});
            return (bool)la.Compile().DynamicInvoke(val);
        }
        /// <summary>
        /// Evaluate equality for member of source value with anover value.
        /// </summary>
        /// <param name="val">The source value. Left part of comparison</param>
        /// <param name="name">Name of field/property of source value</param>
        /// <param name="valCompare">The value to compare</param>
        /// <returns>The comparison result</returns>                
        public static bool EqualPredicate<T>(T val,string name, object valCompare)
         => GetCustomPredicate<T>(val,name, valCompare, PredicateType.Equal);
        /// <summary>
        /// Evaluate not equal condition for member of source value with anover value.
        /// </summary>
        /// <param name="val">The source value. Left part of comparison</param>
        /// <param name="name">Name of field/property of source value</param>
        /// <param name="valCompare">The value to compare</param>
        /// <returns>The evaluation result</returns>          
        public static bool NotEqualPredicate<T>(T val,string name, object valCompare)
         => GetCustomPredicate<T>(val,name, valCompare, PredicateType.NotEqual);
        /// <summary>
        /// Evaluate greater than condition for member of source value with anover value.
        /// </summary>
        /// <param name="val">The source value. Left part of comparison</param>
        /// <param name="name">Name of field/property of source value</param>
        /// <param name="valCompare">The value to compare</param>
        /// <returns>The evaluation result</returns>          
        public static bool GreaterThanPredicate<T>(T val,string name, object valCompare)
        => GetCustomPredicate<T>(val,name, valCompare, PredicateType.GreaterThan);
        /// <summary>
        /// Evaluate greater than or equal condition for member of source value with anover value.
        /// </summary>
        /// <param name="val">The source value. Left part of comparison</param>
        /// <param name="name">Name of field/property of source value</param>
        /// <param name="valCompare">The value to compare</param>
        /// <returns>The evaluation result</returns>           
        public static bool GreaterThanOrEqualPredicate<T>(T val,string name, object valCompare)
        => GetCustomPredicate<T>(val,name, valCompare, PredicateType.GreaterThanOrEqual);
        /// <summary>
        /// Evaluate less than condition for member of source value with anover value.
        /// </summary>
        /// <param name="val">The source value. Left part of comparison</param>
        /// <param name="name">Name of field/property of source value</param>
        /// <param name="valCompare">The value to compare</param>
        /// <returns>The evaluation result</returns>        
        public static bool LessThanPredicate<T>(T val,string name, object valCompare)
        => GetCustomPredicate<T>(val,name, valCompare, PredicateType.LessThan);
        /// <summary>
        /// Evaluate less than or equal condition for member of source value with anover value.
        /// </summary>
        /// <param name="val">The source value. Left part of comparison</param>
        /// <param name="name">Name of field/property of source value</param>
        /// <param name="valCompare">The value to compare</param>
        /// <returns>The evaluation result</returns>           
        public static bool LessThanOrEqualPredicate<T>(T val,string name, object valCompare)
        => GetCustomPredicate<T>(val,name, valCompare, PredicateType.LessThanOrEqual);                                    
    }
}
