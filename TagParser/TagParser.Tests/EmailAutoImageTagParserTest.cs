using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TagParser.Lib;
using TagParser.Lib.TagParser;

namespace TagParser.Tests
{
    [TestClass]
    public class EmailAutoImageTagParserTest
    {
        string _Html;
        ITagParser _TagParser;
        [TestInitialize]
        public void Init()
        {
            _TagParser = new EmailAutoImageTagParser();
            _Html = File.ReadAllText("..\\..\\EmailAutohtml.txt");
            
        }
        [TestMethod]
        public void ShouldReturn4ImageTags()
        {
            Assert.AreEqual<int>(_TagParser.Parse(_Html).Count,4);

        }

        
    }
}
