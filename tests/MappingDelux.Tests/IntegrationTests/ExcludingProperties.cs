using System.Security.Cryptography.X509Certificates;
using MappingDelux.Tests.FakeClasses;
using NUnit.Framework;

namespace MappingDelux.Tests.IntegrationTests
{
  [TestFixture]
  public class ExcludingProperties
  {
    [Test]
    public void given_ClassesThatHaveMultipleMatchingProperties_should_OnlyMatchOne()
    {
      MappingDelux.Configure(x => x.For<IntegrationOne>(config =>
        config.WhenMappingBetween<IntegrationTwo>(
          mapping => mapping.With(one => one.Name, two => two.Surname))));

      var intOne = new IntegrationOne
      {
        DetailedSummary = "this is a detailed Summary",
        Name = "John",
        Surname = "Doe",
        Identification = 12
      };
      IntegrationTwo intTwo = intOne.MapTo<IntegrationOne, IntegrationTwo>();
      Assert.AreEqual(intOne.Name, intTwo.Surname);
      Assert.AreEqual(null, intTwo.Name);
      Assert.AreEqual(0, intTwo.Identification);
      Assert.AreEqual(null, intTwo.DetailedSummary);
    }
  }
}