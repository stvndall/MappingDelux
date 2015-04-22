
using System.Linq;
using System.Reflection;
using MappingDelux.Interfaces;
using NUnit.Framework;
namespace MappingDelux.Tests
{
    [TestFixture]
    public class MapIncludeTests
    {
        private PropertyInfo initialProperty;
        private BaseFake fakeClass;

        [SetUp]
        public void Setup()
        {
            fakeClass = new BaseFake
            {
                Id = 1,
                InternalIdentification = 123,
                SystemWideSpread = "kjsdhfks"
            };

            initialProperty = fakeClass.GetType().GetProperties().First(x => x.Name == "Id");
        }
        [Test]
        public void given_newMapInclude_should_assignPropertyInfoInternally()
        {
            IMapInclude<BaseFake> includer = new MapInclude<BaseFake>(fakeClass, initialProperty);
            var mappingProperties = includer.GetPropertiesThatWillMap();
            Assert.AreEqual(1, mappingProperties.Length);
            Assert.IsTrue(mappingProperties.First().Equals(initialProperty));
        }

        public void And_given_newMapInclude_should_assignPropertyInfoInternally()
        {
            IMapInclude<BaseFake> includer = new MapInclude<BaseFake>(fakeClass, initialProperty);
            includer.And(x => x.SystemWideSpread);
            var second = fakeClass.GetType().GetProperties().First(x => x.Name =="SystemWideSpread");
            var mappingProperties = includer.GetPropertiesThatWillMap();
            Assert.AreEqual(2, mappingProperties.Length);
            Assert.IsTrue(mappingProperties.First().Equals(initialProperty));
            Assert.IsTrue(mappingProperties.Last().Equals(second));
        }
    }
}