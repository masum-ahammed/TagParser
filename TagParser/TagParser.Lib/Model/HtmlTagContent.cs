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

        public void AddAttribute(string attributeName,string attributeValue)
        {
            _Node.Attributes.Add(attributeName, attributeValue);
           
          
        }

        public void SetId(string value)
        {
            if (!_Node.Attributes.Any(x => string.Compare(x.Name,"id",true) == 0))
            {
                AddAttribute("id", value);
            }
            else
            {
                _Node.Attributes["id"].Value = value;
            }
        }

        public List<ParseError> GetParseErrors()
        {
           return  _TagDocument.ParseErrors.Select(x =>new ParseError() { Reason = x.Reason}).ToList();
        }

        public string ToHtml()
        {
            _Node.InnerHtml = _Node.InnerHtml.Replace("\"", "&#34;");
            string outerHtml = _Node.OuterHtml.Replace("\"", "'");
            outerHtml = outerHtml.Replace("&#34;", "\"");
            var newNode = HtmlNode.CreateNode(outerHtml);
            return newNode.OuterHtml;
        }

    }
}
