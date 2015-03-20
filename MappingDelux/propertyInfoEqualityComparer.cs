using System;
using System.Collections.Generic;
using System.Reflection;

namespace MappingDelux
{
    public class PropertyInfoEqualityComparer : IEqualityComparer<PropertyInfo>
    {
        public bool Equals(PropertyInfo x, PropertyInfo y)
        {
            return x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase) &&
                   x.PropertyType == y.PropertyType;
        }

        public int GetHashCode(PropertyInfo obj)
        {
            unchecked
            {
                return obj.PropertyType.GetHashCode()*obj.PropertyType.Name.ToLowerInvariant().GetHashCode();
            }
        }
    }

    
}