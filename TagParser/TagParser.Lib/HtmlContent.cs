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

        public List<Tag> AllTags {
            get
            {
                return GetAllTags();
            }
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
            tagParsers.Add(new EmailAutoImageTagParser());
            return tagParsers;
        }
    }
}
