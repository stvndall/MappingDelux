using System.Collections.Generic;
using System.Linq;
using MappingDelux.Interfaces;

namespace MappingDelux
{
  internal class Mapper : IMapper
  {
    private readonly IMappingConfiguration config;

    public Mapper(IMappingConfiguration config)
    {
      this.config = config;
    }

    public Mapper()
    {
      this.config = new MappingConfiguration();
    }

    public void Map(object input, object returned, IEnumerable<IPropertyInfoMovemovent> propertyIntersection)
    {
      foreach (var properties in propertyIntersection)
      {
        var value = properties.Getter.GetValue(input);
        properties.Setter.SetValue(returned, value);
      }
    }


    public void Map(object input, object returned)
    {
      var found = config.GetMappingFor(input.GetType()).Where(x => x.MappingTo(returned.GetType())).ToList();
      if (found.Any())
      {
        foreach (var configuration in found)
        {

        }
        return;
      }

      var allPropertiesAlikeBetweenClasses = new PropertySniffer(input.GetType(), returned.GetType()).GetPropertyIntersection();
      Map(input, returned, allPropertiesAlikeBetweenClasses);
    }
  }
}