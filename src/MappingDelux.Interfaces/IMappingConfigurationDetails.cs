namespace MappingDelux.Interfaces
{
    public interface IMappingConfigurationDetails
    {
        bool IsGlobal { get; }
        bool MappingTo<T>();
        string AliasAs { get; } 
        string OfficialName { get; }
        int Priority { get; }
    }
}