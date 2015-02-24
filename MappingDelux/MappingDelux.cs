using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace MappingDelux
{
    public static class MappingDelux
    {
        private static EqualityComparer equalityComparer = new EqualityComparer();
        private static IMapper mapping =  new Mapper();
        public static TReturned MapTo<TInput, TReturned>(this TInput mappingFrom) where TReturned : class, new() where TInput : class
        {
            var mappingFromType = mappingFrom.GetType();
            var returning = new TReturned();
            IEnumerable<PropertyInfoMovemovent> propertyIntersection = GetPropertyIntersection(mappingFromType, returning.GetType());
            mapping.Map(mappingFrom, returning, propertyIntersection);
            return returning;
        }

        private static IEnumerable<PropertyInfoMovemovent> GetPropertyIntersection(Type mappingFromType, Type returningType)
        {
            var listOfGetters = TypePropertyCache.GetPropertiesWithGetters(mappingFromType);
            var listOfSetters = TypePropertyCache.GetPropertiesWithSetters(returningType);
            return from getter in listOfGetters from setter in listOfSetters.Where(setter => equalityComparer.Equals(getter, setter)) 
                   select new PropertyInfoMovemovent{Getter = getter, Setter = setter};
        }
    }
}