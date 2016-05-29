using System;
using System.Linq.Expressions;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    internal class ConfigManager<T> : IConfigManager<T>
    {
        private IMappingConfigurationEdit editConfig;
        public ConfigManager()
        {
            editConfig = new MappingConfiguration();
        }


        public void Globally<TOut>(Expression<Func<T, TOut>> func, string alias)
        {
            editConfig.AddToConfig<T>(new GlobalMappingConfigurationDetails(PropertyHelper<T>.GetProperty(func).Name, alias));
        }

        public void WhenMappingBetween<TMappingTo>(Action<IConfigManagerClassDirect<T, TMappingTo>> action)
        {
            action.Invoke(new ConfigManagerClassDirect<T, TMappingTo>());
        }
    }
}