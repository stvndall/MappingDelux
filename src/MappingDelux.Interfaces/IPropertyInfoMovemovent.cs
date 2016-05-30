using System.Reflection;

namespace MappingDelux.Interfaces
{
  public interface IPropertyInfoMovemovent
  {
    PropertyInfo Getter { get; }
    PropertyInfo Setter { get; }
  }
}