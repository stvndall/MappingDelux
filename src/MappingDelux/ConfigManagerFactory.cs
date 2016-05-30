using System;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    internal class ConfigManagerFactory : IConfigManagerFactory
    {
        public void For<T>(Action<IConfigManager<T>> action)
        {
            action.Invoke(new ConfigManager<T>());
        }
    }
}