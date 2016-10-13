using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelHumps.Tests
{
    [TestFixture]
    public class CamelHumpsTests
    {
        [Test]
        public void t()
        {
            (2 + 3).Should().Be(5, "bo tak");           
        }
    }
}
