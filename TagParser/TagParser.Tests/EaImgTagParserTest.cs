using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TagParser.Lib;
using TagParser.Lib.TagParser;

namespace TagParser.Tests
{
    [TestClass]
    public class EaImgTagParserTest
    {
        string _Html;
        AbstractTagParser _TagParser;
        [TestInitialize]
        public void Init()
        {
            _TagParser = new EaImageTagParser();
            _Html = File.ReadAllText("..\\..\\EmailAutohtml.txt");
            
        }
        [TestMethod]
        public void ShouldReturnTwoImageTags()
        {
            Assert.AreEqual(_TagParser.Parse(_Html).Count,3);
        }

        [TestMethod]
        public void StartTagMissing_ReturnsOnlyValidTags()
        {
            _Html = File.ReadAllText("..\\..\\EaImgInvalidSyntex.txt");
            Assert.AreEqual(_TagParser.Parse(_Html).Count, 2);
        }

    }
}
