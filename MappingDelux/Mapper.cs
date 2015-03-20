using System.Collections.Generic;
using System.Reflection;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    internal class Mapper:IMapper
    {

        public void Map(object input, object returned, IEnumerable<PropertyInfoMovemovent> propertyIntersection)
        {
            foreach (var properties in propertyIntersection)
            {
                var value = properties.Getter.GetValue(input);
                properties.Setter.SetValue(returned, value);
            }
        }

        public void Map(object input, object returned)
        {
            var allPropertiesAlikeBetweenClasses = new PropertySniffer(input.GetType(), returned.GetType()).GetPropertyIntersection();
            Map(input, returned, allPropertiesAlikeBetweenClasses);
        }
    }

    public class PropertyInfoMovemovent
    {
        public PropertyInfo Getter { get; set; }
        public PropertyInfo Setter { get; set; }
    }
}