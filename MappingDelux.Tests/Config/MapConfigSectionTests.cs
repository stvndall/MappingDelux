using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

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
            var allConfig = MappingDelux.Config.GetAllConfig().ToArray();
            Assert.AreEqual(1, allConfig.Length);
            Assert.AreEqual("SystemID", allConfig.First().AliasAs);
            Assert.True(allConfig.First().IsGlobal);
            Assert.AreEqual("InternalIdentification", allConfig.First().OfficialName);
        }

    }

}