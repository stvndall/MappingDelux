using NUnit.Framework;

namespace MappingDelux.Tests
{
  public class MapPrimerForOnly
  {
    public int InternalIdentification { get; set; }
    public int Id { get; set; }
    public string SystemWideSpread { get; set; }
  }

  public class TestFake2
  {
    public int Id { get; set; }
    public string VarString { get; set; }
  }

  public class BaseFake
  {
    public int InternalIdentification { get; set; }
    public int Id { get; set; }
    public string SystemWideSpread { get; set; }
  }
}