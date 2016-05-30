using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace MappingDelux
{
  internal class TypePropertyCache
  {
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> allPropertiesForType =
      new ConcurrentDictionary<Type, PropertyInfo[]>();

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> allGettersForType =
      new ConcurrentDictionary<Type, PropertyInfo[]>();

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> allSettersForType =
      new ConcurrentDictionary<Type, PropertyInfo[]>();

    public static PropertyInfo[] GetPropertiesWithGetters(Type typeToFind)
    {
      return allGettersForType.GetOrAdd(typeToFind, FindAllGettersForType);
    }

    public static PropertyInfo[] GetPropertiesWithSetters(Type typeToFind)
    {
      return allSettersForType.GetOrAdd(typeToFind, FindAllSettersForType);
    }

    private static PropertyInfo[] FindAllGettersForType(Type typeToFind)
    {
      return allPropertiesForType.GetOrAdd(typeToFind, FindPropertiesForType).Where(prop => prop.CanRead).ToArray();
    }

    private static PropertyInfo[] FindAllSettersForType(Type typeToFind)
    {
      return allPropertiesForType.GetOrAdd(typeToFind, FindPropertiesForType).Where(prop => prop.CanWrite).ToArray();
    }

    private static PropertyInfo[] FindPropertiesForType(Type type)
    {
      return type.GetProperties();
    }
  }
}