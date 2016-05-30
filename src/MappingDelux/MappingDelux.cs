using System;
using System.Data;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using MappingDelux.Interfaces;

namespace MappingDelux
{
  public static class MappingDelux
  {
    private static IMapper mapping = new Mapper();
    internal static IMappingConfiguration config;

    private static readonly IConfigManagerFactory ConfigManagerFactory = new ConfigManagerFactory();

    public static IMappingConfiguration Config
    {
      get { return config ?? (config = new MappingConfiguration()); }
    }

    public static TReturned MapTo<TInput, TReturned>(this TInput mappingFrom)
      where TReturned : class, new()
      where TInput : class
    {
      var returning = new TReturned();
      return MapTo(mappingFrom, returning);
    }

    private static TReturned MapTo<TInput, TReturned>(TInput mappingFrom, TReturned returning)
      where TReturned : class, new()
      where TInput : class
    {
      mapping.Map(mappingFrom, returning);
      return returning;
    }


    public static IMapDefinition<TFrom> GetMappingPrimer<TFrom>(this TFrom fromClass)
    {
      return new MapDefinition<TFrom>(fromClass);
    }

    public static void Configure(Action<IConfigManagerFactory> action)
    {
      action.Invoke(ConfigManagerFactory);
    }
  }
}