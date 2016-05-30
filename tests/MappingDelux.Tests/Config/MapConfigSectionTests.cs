using System.Linq;
using NUnit.Framework;
using MappingDelux.Interfaces;

namespace MappingDelux.Tests.Config
{
    [TestFixture]
    public class MapConfigSectionTests
    {
        [Test]
        public void For_Config_Given_noItems_ResultsIn_ConfigBeingEmpty()
        {
			var allConfig = MappingDelux.Config.GetAllConfig();
            Assert.IsFalse(allConfig.Any());
        }

        [Test]
        public void For_Config_Given_SingleGlobalConfig_ResultsIn_OneItemInConfig()
        {
            MappingDelux.Configure(x =>
            {
                x.For<BaseFake>(y =>
                {
                    y.Globally(bf => bf.InternalIdentification, "SystemID");
                });
            });
            var allConfig = MappingDelux.Config.GetAllConfig().Where(x => x.IsGlobal).ToArray();
            Assert.AreEqual(1, allConfig.Length);
            Assert.AreEqual("SystemID", allConfig.First().AliasAs);
            Assert.True(allConfig.First().IsGlobal);
            Assert.AreEqual("InternalIdentification", allConfig.First().OfficialName);
        }
        [Test]
        public void For_Config_Given_SingleOneWayConfigurationConfig_ResultsIn_OneItemInConfig()
        {
            MappingDelux.Configure(x =>
            {
                x.For<BaseFake>(y =>
                {
                    y.WhenMappingBetween<TestFake2>(mapper =>
                    {
                        mapper.With(bf => bf.SystemWideSpread, tf2 => tf2.VarString);
                    });
                });
            });
            var allConfig = MappingDelux.Config.GetAllConfig().Where(x => x.GetType().Name == "SingleBindDetails").ToArray();
            Assert.AreEqual(2, allConfig.Count());
            var lhs = allConfig.FirstOrDefault(x => x.MappingTo<TestFake2>());
            Assert.AreEqual("VarString", lhs.AliasAs);
            Assert.False(lhs.IsGlobal);
            Assert.AreEqual("SystemWideSpread", lhs.OfficialName);

            var rhs = allConfig.FirstOrDefault(x => x.MappingTo<BaseFake>());
            Assert.AreEqual("SystemWideSpread", rhs.AliasAs);
            Assert.False(rhs.IsGlobal);
            Assert.AreEqual("VarString", rhs.OfficialName);
        }

    }

}