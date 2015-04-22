using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MappingDelux.Interfaces
{
    public interface IMapInclude<TFrom> : IMapWithMapPrimer
    {
        IMapInclude<TFrom> And<TReturn>(Expression <Func<TFrom, TReturn>> prop);

        PropertyInfo[] GetPropertiesThatWillMap();
    }

}