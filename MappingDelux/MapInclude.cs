using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    public class MapInclude<TFrom> : IMapInclude<TFrom>
    {
        private readonly TFrom _fromClass;
        private readonly List<PropertyInfo> _propertyInfos;
        private Mapper _mapper;

        public MapInclude(TFrom fromClass, params PropertyInfo[] propertyInfos)
        {
            _fromClass = fromClass;
            _propertyInfos = propertyInfos.ToList();
            _mapper = new Mapper();
        }

        public TTo Map<TTo>() where TTo : class, new()
        {
            var mapTo = new TTo();
            Map(mapTo);
            return mapTo;
        }

        public void Map<TTo>(TTo mapTo) where TTo : class
        {
            var intersection = new PropertySniffer(typeof (TFrom), typeof (TTo)).GetPropertyIntersection(_propertyInfos.ToArray());

            _mapper.Map(_fromClass, mapTo, intersection);
        }

        public IMapInclude<TFrom> And<TReturn>(Expression<Func<TFrom, TReturn>> prop)
        {
            _propertyInfos.Add(PropertyHelper<TFrom>.GetProperty(prop));
            return this;
        }
    }
}