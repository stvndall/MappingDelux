using System;
using System.Collections.Generic;
using System.Reflection;

namespace MappingDelux.EqualityComparers
{
  public class PropertyInfoEqualityComparer : IEqualityComparer<PropertyInfo>
  {
    public bool Equals(PropertyInfo lhs, PropertyInfo rhs)
    {
      return lhs.PropertyType == rhs.PropertyType &&
             (lhs.Name.Equals(rhs.Name, StringComparison.InvariantCultureIgnoreCase));
    }

    public int GetHashCode(PropertyInfo obj)
    {
      unchecked
      {
        return obj.PropertyType.GetHashCode() * obj.PropertyType.Name.ToLowerInvariant().GetHashCode();
      }
    }
  }
}