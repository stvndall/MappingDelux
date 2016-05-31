using System;
using System.Collections.Generic;

namespace MappingDelux.Interfaces
{
  public interface IMappingConfigurationEdit : IMappingConfiguration
  {
    void AddToConfig<T>(IMappingConfigurationDetails addToConfiguration);
  }
}