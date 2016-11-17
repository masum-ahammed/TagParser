using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TagParser.Lib;
using TagParser.Lib.TagParser;

namespace TagParser.Tests
{
    [TestClass]
    public class EaTxtTagParserTest
    {
        string _Html;
        ITagParser _TagParser;
        [TestInitialize]
        public void Init()
        {
            _TagParser = new EaTxtTagParser();
            _Html = File.ReadAllText("..\\..\\EmailAutohtml.txt");
            
        }
        [TestMethod]
        public void ShouldReturnFourTextTags()
        {
            Assert.AreEqual(_TagParser.Parse(_Html).Count,4);
        }

        [TestMethod]
        public void EndTagMissing_ReturnsOnlyValidTags()
        {
            _Html = File.ReadAllText("..\\..\\EaImgInvalidSyntex.txt");
            Assert.AreEqual(_TagParser.Parse(_Html).Count, 3);
        }

    }
}
