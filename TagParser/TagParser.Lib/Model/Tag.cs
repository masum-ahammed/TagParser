using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TagParser.Lib.Model
{
    public  class Tag
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DefaultValue { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }
        public string Content  { get; set; }

        public static Tag CreateNew(Match match, string type)
        {
            Tag tag = new Tag();
            tag.Type = type;
            tag.Index = match.Index;
            tag.Length = match.Length;
            tag.Content = match.Value;
            HtmlNode node = ConvertToHtmlNode(tag.Content);
            tag.DefaultValue = node.InnerHtml;
            tag.Name = node.Attributes["name"]?.Value ?? string.Empty;
            return tag;
        }

        private static HtmlNode ConvertToHtmlNode(string tagContent)
        {
            HtmlDocument tagDocument = new HtmlDocument();
            tagDocument.LoadHtml(tagContent);
            HtmlNode node = tagDocument.DocumentNode.FirstChild;
            return node;
        }
    }
}
