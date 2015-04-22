using System.Reflection;

namespace MappingDelux.EqualityComparers
{
    public static class EqualityExtensionMethods
    {
        static bool Equals(this PropertyInfo info, PropertyInfo compared)
        {
            var equality = new PropertyInfoEqualityComparer();
            return equality.GetHashCode(info) == equality.GetHashCode(compared);
        }
    }
}