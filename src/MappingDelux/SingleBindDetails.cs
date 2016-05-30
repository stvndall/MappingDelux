using System;
using System.Reflection;
using MappingDelux.Interfaces;

namespace MappingDelux
{
  internal class SingleBindDetails : IMappingConfigurationDetails
  {
    private readonly Type forType;
    public string AliasAs { get; private set; }
    public string OfficialName { get; private set; }
    public int Priority { get; private set; }
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

  }
}