using System;
using System.Linq.Expressions;

namespace MappingDelux.Interfaces
{
    public interface IConfigManager<T>
    {
        void Globally<TOut>(Expression<Func<T, TOut>> func, string alias);
        void WhenMappingBetween<TMappingTo>(Action<IConfigManagerClassDirect<T, TMappingTo>> action);
    }

    public interface IConfigManagerClassDirect<lhsClass, rhsClass>
    {
        void With<TOut>(Expression<Func<lhsClass, TOut>> lhsProp, Expression<Func<rhsClass, TOut>> rhsProp);
    }
}