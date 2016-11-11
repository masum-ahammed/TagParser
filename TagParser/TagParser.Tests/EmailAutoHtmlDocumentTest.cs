using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TagParser.Lib;

namespace TagParser.Tests
{
    [TestClass]
    public class EmailAutoHtmlDocumentTest
    {
        string _Html;
        HtmlContent _HtmlContent;
        [TestInitialize]
        public void Init()
        {
            _Html = File.ReadAllText("..\\..\\EmailAutohtml.txt");
            _HtmlContent = new HtmlContent(_Html);
        }
        [TestMethod]
        public void HtmlContentShouldnotBeNull()
        {
            Assert.IsNotNull(_HtmlContent.Content);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Html should not be null")]
        public void NullHtmlContentShouldThrowException()
        {
            _HtmlContent = new HtmlContent(null);
            Assert.IsNull(_HtmlContent.Content);

        }
        
    }
}
