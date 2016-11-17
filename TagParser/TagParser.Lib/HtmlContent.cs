using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagParser.Lib.Model;
using TagParser.Lib.TagParser;

namespace TagParser.Lib
{
    public class HtmlContent
    {
        List<ITagParser> _TagParsers;
        string _HtmlContent;

        

        public HtmlContent(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                throw new ArgumentException("Html should not be null");
            }
            _TagParsers = RegisterTagParser();
            _HtmlContent = html;
        }
        public string Content { get { return _HtmlContent; } }

        /// <summary>
        /// Returns all custom tags
        /// </summary>
        public List<Tag> AllTags {
            get
            {
                return GetAllTags();
            }
        }

        /// <summary>
        /// Generates 'id' attribute for all tags
        /// </summary>
        public string ParsedHtml
        {
            get
            {
                return GetIdGeneratedHtml();
            }
        }

        private string GetIdGeneratedHtml()
        {
            IList<Tuple<string,string>> tagContentReplaceList = new List<Tuple<string, string>>();
            foreach (var tag in GetAllTags())
            {
                tagContentReplaceList.Add(new Tuple<string, string>( _HtmlContent.Substring(tag.Index, tag.Length), tag.ToHtml()));
            }
            foreach (var item in tagContentReplaceList)
            {
                _HtmlContent = _HtmlContent.Replace(item.Item1, item.Item2);
            }
            return _HtmlContent;
        }
        private List<Tag> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();
            foreach (var parser in _TagParsers)
            {
                tags.AddRange(parser.Parse(_HtmlContent));
            }
            return tags;
        }

        private List<ITagParser> RegisterTagParser()
        {
            List<ITagParser> tagParsers = new List<ITagParser>();
            tagParsers.Add(new EaImageTagParser());
            tagParsers.Add(new EaTxtTagParser());
            return tagParsers;
        }
    }
}
