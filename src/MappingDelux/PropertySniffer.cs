﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MappingDelux.EqualityComparers;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    public class PropertySniffer
    {
        private readonly Type leftHandSideType;
        private readonly Type rightHandSideType;
        private readonly PropertyInfoEqualityComparer propertyInfoEqualityComparer = new PropertyInfoEqualityComparer();

        public PropertySniffer(Type lhs, Type rhs)
        {
            leftHandSideType = lhs;
            rightHandSideType = rhs;
        }


        internal IEnumerable<IPropertyInfoMovemovent> GetPropertyIntersection()
        {

            var listOfGetters = TypePropertyCache.GetPropertiesWithGetters(leftHandSideType);
            var listOfSetters = TypePropertyCache.GetPropertiesWithSetters(rightHandSideType);
            return from getter in listOfGetters
                   from setter in listOfSetters.Where(setter => propertyInfoEqualityComparer.Equals(getter, setter))
                   select new PropertyInfoMovemovent { Getter = getter, Setter = setter };
        }
        
        internal IEnumerable<IPropertyInfoMovemovent> GetPropertyIntersection(params PropertyInfo[] props)
        {

            var listOfGetters = TypePropertyCache.GetPropertiesWithGetters(leftHandSideType).Intersect(props, propertyInfoEqualityComparer);
            var listOfSetters = TypePropertyCache.GetPropertiesWithSetters(rightHandSideType);
            return from getter in listOfGetters
                   from setter in listOfSetters.Where(setter => propertyInfoEqualityComparer.Equals(getter, setter))
                   select new PropertyInfoMovemovent { Getter = getter, Setter = setter };
        }

        internal IEnumerable<IPropertyInfoMovemovent> GetPropertyIntersectionWithout(params PropertyInfo[] without)
        {
            var listOfGetters = TypePropertyCache.GetPropertiesWithGetters(leftHandSideType).Except(without, propertyInfoEqualityComparer);
            var listOfSetters = TypePropertyCache.GetPropertiesWithSetters(rightHandSideType);
            return from getter in listOfGetters
                   from setter in listOfSetters.Where(setter => propertyInfoEqualityComparer.Equals(getter, setter))
                   select new PropertyInfoMovemovent { Getter = getter, Setter = setter };

        }
    }

    
}