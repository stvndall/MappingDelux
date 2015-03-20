using System;
using System.Linq.Expressions;

namespace MappingDelux.Interfaces
{
    public interface IMapExclude<TFrom> : IMapWithMapPrimer<TFrom>
    {
        IMapExclude<TFrom> Nor<TReturn>(Expression<Func<TFrom, TReturn>> prop);
    }
}