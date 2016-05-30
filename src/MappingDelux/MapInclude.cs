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
    private readonly TFrom fromClass;
    private readonly List<PropertyInfo> propertyInfos;
    private readonly Mapper mapper;

    public MapInclude(TFrom fromClass, params PropertyInfo[] propertyInfos)
    {
      this.fromClass = fromClass;
      this.propertyInfos = propertyInfos.ToList();
      mapper = new Mapper();
    }

    public PropertyInfo[] GetPropertiesThatWillMap()
    {
      return propertyInfos.ToArray();
    }

    public TTo Map<TTo>() where TTo : class, new()
    {
      var mapTo = new TTo();
      Map(mapTo);
      return mapTo;
    }

    public void Map<TTo>(TTo mapTo) where TTo : class
    {
      var intersection = new PropertySniffer(typeof(TFrom), typeof(TTo)).GetPropertyIntersection(propertyInfos.ToArray());

      mapper.Map(fromClass, mapTo, intersection);
    }

    public IMapInclude<TFrom> And<TReturn>(Expression<Func<TFrom, TReturn>> prop)
    {
      propertyInfos.Add(PropertyHelper<TFrom>.GetProperty(prop));
      return this;
    }
  }
}