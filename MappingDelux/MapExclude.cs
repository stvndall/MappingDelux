using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    public class MapExclude<TFrom> : IMapExclude<TFrom>
    {
        private readonly TFrom _fromClass;
        private readonly List<PropertyInfo> _props;

        public MapExclude(TFrom fromClass, params PropertyInfo[] props)
        {
            _fromClass = fromClass;
            _props = props.ToList();
        }

        public TTo Map<TTo>() where TTo : class, new()
        {
            var mapTo = new TTo();
            Map(mapTo);
            return mapTo;
        }

        public void Map<TTo>(TTo mapTo) where TTo : class
        {
            var sniffer = new PropertySniffer(_fromClass.GetType(), mapTo.GetType());
            IEnumerable<PropertyInfoMovemovent> mappingProperties = sniffer.GetPropertyIntersectionWithout(_props.ToArray());
            new Mapper().Map(_fromClass, mapTo, mappingProperties);
        }

        public IMapExclude<TFrom> Nor<TReturn>(Expression<Func<TFrom, TReturn>> prop)
        {
            _props.Add(PropertyHelper<TFrom>.GetProperty(prop));
            return this;
        }
    }
}