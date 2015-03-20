using System;
using System.Linq.Expressions;

namespace MappingDelux.Interfaces
{
    public interface IMapInclude<TFrom> : IMapWithMapPrimer<TFrom>
    {
        IMapInclude<TFrom> And<TReturn>(Expression <Func<TFrom, TReturn>> prop);

    }
}