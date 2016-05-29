using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    public interface IConfigManager<T>
    {
        void Globally<TOut>(Expression<Func<T, TOut>> func, string alias);
        void WhenMappingBetween<TMappingTo>(Action<IConfigManagerClassDirect<T, TMappingTo>> action);
    }

    public interface IConfigManagerClassDirect<lhsClass, rhsClass>
    {
        void With<TOut>(Expression<Func<lhsClass, TOut>> lhsProp, Expression<Func<rhsClass, TOut>> rhsProp);
    }

    class ConfigManagerClassDirect<lhsClass, rhsClass> : IConfigManagerClassDirect<lhsClass, rhsClass>
    {
        private IMappingConfigurationEdit editConfig = new MappingConfiguration();

        public void With<TOut>(Expression<Func<lhsClass, TOut>> lhsProp, Expression<Func<rhsClass, TOut>> rhsProp)
        {
            var lhs = PropertyHelper<lhsClass>.GetProperty(lhsProp);
            var rhs = PropertyHelper<rhsClass>.GetProperty(rhsProp);

            editConfig.AddToConfig<lhsClass>(new SingleBindDetails(lhs, rhs.Name, typeof(rhsClass)));
            editConfig.AddToConfig<rhsClass>(new SingleBindDetails(rhs, lhs.Name, typeof(lhsClass)));

        }
    }

    internal class SingleBindDetails : IMappingConfigurationDetails
    {
        private readonly Type forType;
        public SingleBindDetails(PropertyInfo lhs, string name, Type type)
        {
            OfficialName = lhs.Name;
            AliasAs = name;
            forType = type;
            Priority = 1;
        }

        public bool IsGlobal { get { return false; } }
        public bool MappingTo<T>()
        {
            return typeof (T) == forType;
        }

        public string AliasAs { get; private set; }
        public string OfficialName { get; private set; }
        public int Priority { get; private set; }
    }
}