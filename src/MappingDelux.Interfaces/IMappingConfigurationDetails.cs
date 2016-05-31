using System;

namespace MappingDelux.Interfaces
{
  public interface IMappingConfigurationDetails
  {
    bool IsGlobal { get; }
    bool MappingTo<T>();
    bool MappingTo(Type mappingToType);
    string AliasAs { get; }
    string OfficialName { get; }
    int Priority { get; }
  }
}