using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using POC;

namespace POCTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void runner()
        {
            var builder = FluentBuilder.For(new ControllerObject());
            builder.Limit().Where().And().Field().Equals().Order().Execute();

        }
    }

    public class ControllerObject
    {
        
    }
}
