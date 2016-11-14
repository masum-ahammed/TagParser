using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TagParser.Lib;
using TagParser.Lib.TagParser;

namespace TagParser.Tests
{
    [TestClass]
    public class EaTagParserTest
    {
        string _Html;
        ITagParser _TagParser;
        [TestInitialize]
        public void Init()
        {
            _TagParser = new EaImageTagParser();
            _Html = File.ReadAllText("..\\..\\EmailAutohtml.txt");
            
        }
        [TestMethod]
        public void ShouldReturnListOfImageTags()
        {
            Assert.IsTrue(_TagParser.Parse(_Html).Count> 0);

        }

        
    }
}
