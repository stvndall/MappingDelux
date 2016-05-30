using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MappingDelux
{
  public static class PropertyHelper<T>
  {
    public static PropertyInfo GetProperty<TValue>(
      Expression<Func<T, TValue>> selector)
    {
      Expression body = selector;
      if (body is LambdaExpression)
      {
        body = ((LambdaExpression) body).Body;
      }

      var expression = body as MemberExpression;
      if (expression == null)
      {
        throw new InvalidOperationException();
      }
      return (PropertyInfo) expression.Member;
    }
  }
}