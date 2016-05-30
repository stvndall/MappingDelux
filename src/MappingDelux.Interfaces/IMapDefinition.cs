using System;
using System.Linq.Expressions;

namespace MappingDelux.Interfaces
{
    public interface IMapDefinition<TFrom>
    {
        IMapInclude<TFrom> Only<TReturn>(Expression<Func<TFrom, TReturn>> prop);
        IMapExclude<TFrom> WithOut<TReturn>(Expression<Func<TFrom, TReturn>> prop);
    }
}