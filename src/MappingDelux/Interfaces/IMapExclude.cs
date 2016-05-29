using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MappingDelux.Interfaces
{
    public interface IMapExclude<TFrom> : IMapWithMapPrimer
    {
        IMapExclude<TFrom> Nor<TReturn>(Expression<Func<TFrom, TReturn>> prop);
        PropertyInfo[] GetPropertiesThatWillNotMap();
    }
}