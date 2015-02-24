using System.Collections.Generic;
using System.Reflection;

namespace MappingDelux
{
    internal interface IMapper
    {
        void Map(object input, object returned, IEnumerable<PropertyInfoMovemovent> propertyIntersection);
    }
}