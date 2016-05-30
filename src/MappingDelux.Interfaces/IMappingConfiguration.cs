using System.Collections.Generic;

namespace MappingDelux.Interfaces
{
    public interface IMappingConfiguration
    {
        IEnumerable<IMappingConfigurationDetails> GetAllConfig();
    }
}