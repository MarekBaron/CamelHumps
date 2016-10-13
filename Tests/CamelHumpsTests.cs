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
        [TestCase("", "Ala", true)]        
        [TestCase("Ala", "Ala", true)]
        [TestCase("Ala", "ala", true)]
        [TestCase("ALA", "ala", true)]
        [TestCase("ala", "alabaster", true)]
        [TestCase("ala", "alba", false)]
        [TestCase("CreR", "CreateRoom", true)]
        [TestCase("CreR", "CreateDoorRoom", false)]
        [TestCase("CreDoR", "CreateDoorRoom", true)]
        [TestCase("CDR", "CreateDoorRoom", true)]
        public void MatchTest(string aPattern, string aText, bool anExpectedResult)
        {
            CamelHumps.Match(aPattern, aText).Should().Be(anExpectedResult);
        }
    }
}
