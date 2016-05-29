using System.Collections.Generic;

namespace MappingDelux.Interfaces
{
    public interface IMappingConfiguration
    {
        IEnumerable<IMappingConfigurationDetails> GetAllConfig();
    }

    internal interface IMappingConfigurationEdit : IMappingConfiguration
    {
        void AddToConfig<T>(IMappingConfigurationDetails addToConfiguration);

    }
}