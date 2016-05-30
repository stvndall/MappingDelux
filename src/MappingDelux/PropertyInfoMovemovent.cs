using System.Reflection;
using MappingDelux.Interfaces;

namespace MappingDelux
{
  public class PropertyInfoMovemovent:IPropertyInfoMovemovent
  {
    public PropertyInfo Getter { get; set; }
    public PropertyInfo Setter { get; set; }
  }
}