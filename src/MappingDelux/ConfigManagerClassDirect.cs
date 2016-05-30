using System;
using System.Linq.Expressions;
using MappingDelux.Interfaces;

namespace MappingDelux
{
  internal class ConfigManagerClassDirect<lhsClass, rhsClass> : IConfigManagerClassDirect<lhsClass, rhsClass>
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
}