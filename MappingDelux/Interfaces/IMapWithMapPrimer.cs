using System.Reflection;

namespace MappingDelux.Interfaces
{
    public interface IMapWithMapPrimer
    {
        void Map<TTo>(TTo mapTo) where TTo : class;
        TTo Map<TTo>() where TTo : class, new();
    }
}