using System;
using System.Linq.Expressions;
using System.Reflection;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    public class MapDefinition<TFrom> : IMapDefinition<TFrom>
    {
        private readonly TFrom fromClass;

        public MapDefinition(TFrom fromClass)
        {
            this.fromClass = fromClass;
        }

        public IMapInclude<TFrom> Only<TReturn>(Expression<Func<TFrom, TReturn>> prop)
        {
            return  new MapInclude<TFrom>(fromClass,GetPropertyInfo(prop));
        }

        public IMapExclude<TFrom> WithOut<TReturn>( Expression<Func<TFrom, TReturn>> prop)
        {
            return new MapExclude<TFrom>(fromClass, GetPropertyInfo(prop));
        }

        private  PropertyInfo GetPropertyInfo<TReturn>(Expression<Func<TFrom, TReturn>> prop)
        {
            return PropertyHelper<TFrom>.GetProperty(prop);
        }
    }
}