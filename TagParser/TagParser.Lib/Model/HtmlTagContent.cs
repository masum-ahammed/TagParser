using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagParser.Lib.Model;

namespace TagParser.Lib.Model
{
    public class HtmlTagContent
    {
        string _TagContent;
        HtmlNode _Node;
        public HtmlTagContent( string tagContent)
        {
            _TagContent = tagContent;
            _Node = ConvertToHtmlNode(_TagContent);
        }
        private static HtmlNode ConvertToHtmlNode(string tagContent)
        {
            HtmlDocument tagDocument = new HtmlDocument();
            tagDocument.LoadHtml(tagContent);
            HtmlNode node = tagDocument.DocumentNode.FirstChild;
            return node;
        }

        public string InnerHtml { get { return _Node.InnerHtml; } }
      

        public  string GetAttributeValueByName(string attributeName)
        {
            return _Node.Attributes[attributeName]?.Value ?? string.Empty;
        }
    }
}
