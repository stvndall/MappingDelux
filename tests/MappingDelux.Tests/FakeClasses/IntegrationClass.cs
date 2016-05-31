namespace MappingDelux.Tests.FakeClasses
{
  public class IntegrationClass
  {
    public int Identification { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string DetailedSummary { get; set; }
  }

  public class IntegrationOne : IntegrationClass
  {
  }

  public class IntegrationTwo : IntegrationClass
  {
  }
}