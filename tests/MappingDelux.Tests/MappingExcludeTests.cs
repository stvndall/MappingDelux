using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace MappingDelux.Tests
{
    [TestFixture]
    public class MappingExcludeTests
    {
        private BaseFake fakeClass;
        private PropertyInfo initialProperty;

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
        public void given_newMapExlude_should_assignPropertyInfoInternally()
        {
            MapExclude<BaseFake> includer = new MapExclude<BaseFake>(fakeClass, initialProperty);
            var mappingProperties = includer.GetPropertiesThatWillNotMap();
            Assert.AreEqual(1, mappingProperties.Length);
            Assert.IsTrue(mappingProperties.First().Equals(initialProperty));
        }

        [Test]
        public void Nor_given_newMapExlude_should_assignPropertyInfoInternally()
        {
            MapExclude<BaseFake> excluder = new MapExclude<BaseFake>(fakeClass, initialProperty);
            excluder.Nor(x => x.SystemWideSpread);
            var mappingProperties = excluder.GetPropertiesThatWillNotMap();
            Assert.AreEqual(2, mappingProperties.Length);
            Assert.IsTrue(mappingProperties.First().Equals(initialProperty));
            Assert.IsTrue(mappingProperties.Last().Equals(fakeClass.GetType().GetProperties().First(x => x.Name == "SystemWideSpread")));
        }

    }
}