using System;
using System.Collections.Generic;
using System.Linq;
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
            TestFake1 f1 = new TestFake1{VarI = 123,VarInt = 12};
            var returned = f1.MapTo<TestFake1, TestFake2>();
            Assert.AreEqual(f1.VarInt, returned.VarInt);
        }
    }

    public class TestFake2
    {
        public int VarInt { get; set; }
    }

    public class TestFake1
    {
        public int VarI { get; set; }
        public int VarInt { get; set; }
    }
}
