using System;
using MappingDelux.Interfaces;

namespace MappingDelux
{
	internal class GlobalMappingConfigurationDetails : IMappingConfigurationDetails
  {
    private Type typeToMapTo;

    public string AliasAs { get; protected set; }
    public string OfficialName { get; protected set; }
    public int Priority { get; protected set; }

    public GlobalMappingConfigurationDetails(string propertyName, string aliasAs)
    {
      OfficialName = propertyName;
      Priority = 0;
      AliasAs = aliasAs;
    }

    public bool IsGlobal
    {
      get { return true; }
    }

    public bool MappingTo<T>()
    {
      return true;
    }

		public bool MappingTo (Type mappingToType)
		{
			return true;
		}
  }
}