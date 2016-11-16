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
        HtmlDocument _TagDocument;
        public HtmlTagContent( string tagContent)
        {
            _TagContent = tagContent;
            _Node = ConvertToHtmlNode(_TagContent);
        }
        private HtmlNode ConvertToHtmlNode(string tagContent)
        {
            _TagDocument = new HtmlDocument();
            _TagDocument.LoadHtml(tagContent);
            HtmlNode node = _TagDocument.DocumentNode.FirstChild;

            return node;
        }

        public string InnerHtml { get { return _Node.InnerHtml; } }
      

        public  string GetAttributeValueByName(string attributeName)
        {
            return _Node.Attributes[attributeName]?.Value ;
        }

        public List<ParseError> GetParseErrors()
        {
           return  _TagDocument.ParseErrors.Select(x =>new ParseError() { Reason = x.Reason}).ToList();
        }
        
    }
}
