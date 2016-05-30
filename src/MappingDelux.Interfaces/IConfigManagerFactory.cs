using System;

namespace MappingDelux.Interfaces
{
    public interface IConfigManagerFactory
    {
        void For<T>(Action<IConfigManager<T>> action);
    }
}