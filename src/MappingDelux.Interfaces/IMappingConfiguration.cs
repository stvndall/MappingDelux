using System;
using System.Collections.Generic;

namespace MappingDelux.Interfaces
{
  public interface IMappingConfiguration
  {
    IEnumerable<IMappingConfigurationDetails> GetAllConfig();
    IList<IMappingConfigurationDetails> GetMappingFor(Type mappingType);
  }
}