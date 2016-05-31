using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MappingDelux.Interfaces;

namespace MappingDelux
{
  internal class MappingConfiguration : IMappingConfigurationEdit
  {
    internal static ConcurrentDictionary<Type, List<IMappingConfigurationDetails>> ConfigDictinary =
      new ConcurrentDictionary<Type, List<IMappingConfigurationDetails>>();

    public void AddToConfig<T>(IMappingConfigurationDetails addToConfiguration)
    {
      var details = ConfigDictinary.GetOrAdd(typeof(T), new List<IMappingConfigurationDetails>());
      details.Add(addToConfiguration);
    }


    public IEnumerable<IMappingConfigurationDetails> GetAllConfig()
    {
      return ConfigDictinary.Values.Select(x => x).SelectMany(y => y);
    }

    public IList<IMappingConfigurationDetails> GetMappingFor(Type mappingType)
    {
      List<IMappingConfigurationDetails> returningList;
      ConfigDictinary.TryGetValue(mappingType, out returningList);
      return returningList??new List<IMappingConfigurationDetails>();
    }
  }
}