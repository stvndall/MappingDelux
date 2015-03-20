using System.Data;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using MappingDelux.Interfaces;

namespace MappingDelux
{
    public static class MappingDelux
    {
        private static IMapper mapping = new Mapper();
        public static TReturned MapTo<TInput, TReturned>(this TInput mappingFrom)
            where TReturned : class, new()
            where TInput : class
        {
            var returning = new TReturned();
            return MapTo(mappingFrom, returning);
        }

        private static TReturned MapTo<TInput, TReturned>(TInput mappingFrom, TReturned returning)
            where TReturned : class, new() where TInput : class
        {
            mapping.Map(mappingFrom, returning);
            return returning;
        }


        public static IMapDefinition<TFrom> GetMappingPrimer<TFrom>(this TFrom fromClass)
        {
            return new MapDefinition<TFrom>(fromClass);
        }
    }
}