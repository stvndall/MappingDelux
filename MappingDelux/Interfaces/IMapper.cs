using System.Collections.Generic;

namespace MappingDelux.Interfaces
{
    internal interface IMapper
    {
        void Map(object input, object returned, IEnumerable<PropertyInfoMovemovent> propertyIntersection);
        void Map(object input, object returned);
    }
}