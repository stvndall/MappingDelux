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
    private readonly TFrom fromClass;
    private readonly List<PropertyInfo> props;

    public MapExclude(TFrom fromClass, params PropertyInfo[] props)
    {
      this.fromClass = fromClass;
      this.props = props.ToList();
    }

    public TTo Map<TTo>() where TTo : class, new()
    {
      var mapTo = new TTo();
      Map(mapTo);
      return mapTo;
    }

    public PropertyInfo[] GetPropertiesThatWillNotMap()
    {
      return props.ToArray();
    }

    public void Map<TTo>(TTo mapTo) where TTo : class
    {
      var sniffer = new PropertySniffer(fromClass.GetType(), mapTo.GetType());
      IEnumerable<IPropertyInfoMovemovent> mappingProperties = sniffer.GetPropertyIntersectionWithout(props.ToArray());
      new Mapper().Map(fromClass, mapTo, mappingProperties);
    }

    public IMapExclude<TFrom> Nor<TReturn>(Expression<Func<TFrom, TReturn>> prop)
    {
      props.Add(PropertyHelper<TFrom>.GetProperty(prop));
      return this;
    }
  }
}