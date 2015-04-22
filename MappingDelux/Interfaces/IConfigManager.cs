using System;
using System.Linq.Expressions;

namespace MappingDelux
{
    public interface IConfigManager<T>
    {
        void Globally<TOut>(Expression<Func<T, TOut>> func, string alias);
    }
}