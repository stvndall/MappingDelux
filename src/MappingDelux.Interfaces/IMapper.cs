using System.Collections.Generic;

namespace MappingDelux.Interfaces
{
    public interface IMapper
    {
        void Map(object input, object returned, IEnumerable<IPropertyInfoMovemovent> propertyIntersection);
        void Map(object input, object returned);
    }
}