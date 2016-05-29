using System;

namespace MappingDelux
{
    public interface IConfigManagerFactory
    {
        void For<T>(Action<IConfigManager<T>> action);
    }
}