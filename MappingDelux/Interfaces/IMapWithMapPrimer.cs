namespace MappingDelux.Interfaces
{
    public interface IMapWithMapPrimer<TFrom>
    {
        void Map<TTo>(TTo mapTo) where TTo : class;
        TTo Map<TTo>() where TTo : class, new();
    }
}