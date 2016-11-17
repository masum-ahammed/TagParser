using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TagParser.Lib;
using System.Text.RegularExpressions;
using TagParser.Lib.Utility;
using TagParser.Lib.Model;

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

        [TestMethod]
        public void ShouldAllEA_TXT_Have_Id_Attribute()
        {
            string pattern = "<EA_TXT(.*)EA_TXT>";
            string idGenratedHtml = _HtmlContent.ParsedHtml;
            MatchCollection matches = RegularExpressionUtility.GetMaches(pattern, idGenratedHtml);
            foreach (Match match in matches)
            {
                HtmlTagContent htmlTagContent = new HtmlTagContent(match.Value);
                Assert.IsTrue(!string.IsNullOrEmpty(htmlTagContent.GetAttributeValueByName("id")));
            }

        }

        [TestMethod]
        public void ShouldAllEA_Img_Have_Id_Attribute()
        {
            string pattern = "<EA_IMG(.*)EA_IMG>";
            string idGenratedHtml = _HtmlContent.ParsedHtml;
            MatchCollection matches = RegularExpressionUtility.GetMaches(pattern, idGenratedHtml);
            foreach (Match match in matches)
            {
                HtmlTagContent htmlTagContent = new HtmlTagContent(match.Value);
                Assert.IsTrue(!string.IsNullOrEmpty(htmlTagContent.GetAttributeValueByName("id")));
            }

        }

    }
}
