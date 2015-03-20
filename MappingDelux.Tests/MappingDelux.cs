using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MappingDelux;
namespace MappingDelux.Tests
{
    [TestFixture]
    public class MappingDelux
    {
        [Test]
        public void Given_OneObject_shouldMapTo_SecondObject()
        {
            BaseFake f1 = new BaseFake { internalIdentification = 123, Id = 12 };
            var returned = f1.MapTo<BaseFake, TestFake2>();
            Assert.AreEqual(f1.Id, returned.Id);
            Assert.AreEqual(null, returned.VarString);
        }


        [Test]
        public void Given_2Objects_WithMapPrimer_Should_Only_map_selected_properties()
        {
            BaseFake f1 = new BaseFake { Id = 123, internalIdentification = 132, SystemWideSpread = "test" };
            var primer = f1.GetMappingPrimer();
            MapPrimerForOnly forOnly = primer.Only(x => x.Id).And(x => x.SystemWideSpread).Map<MapPrimerForOnly>();

            Assert.AreEqual(f1.Id, forOnly.Id);
            Assert.AreEqual(f1.SystemWideSpread, forOnly.SystemWideSpread);
            Assert.AreNotEqual(f1.internalIdentification, forOnly.InternalIdentification);
        }


        [Test]
        public void Given_2Objects_WithMapPrimer_Should_Not_map_selected_properties()
        {
            BaseFake f1 = new BaseFake { Id = 123, internalIdentification = 132, SystemWideSpread = "test" };
            var primer = f1.GetMappingPrimer();
            var without = primer.WithOut(x => x.Id).Nor(x => x.internalIdentification).Map<MapPrimerForOnly>();

            Assert.AreNotEqual(f1.Id, without.Id);
            Assert.AreEqual(f1.SystemWideSpread, without.SystemWideSpread);
            Assert.AreNotEqual(f1.internalIdentification, without.InternalIdentification);
        }



    }

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
        public int internalIdentification { get; set; }
        public int Id { get; set; }
        public string SystemWideSpread { get; set; }
    }
}
