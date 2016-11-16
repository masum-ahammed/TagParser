using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagParser.Lib.Model;
using TagParser.Lib.Utility;

namespace TagParser.Lib.TagParser
{
    public class EaImageTagParser : ITagParser
    {
        public List<Tag> Parse(string content)
        {
            List<Tag> tags = new List<Tag>();
            string pattern = "<EA_IMG(.*)EA_IMG>";
            MatchCollection matches = RegularExpressionUtility.GetMaches(pattern, content);
            foreach (Match match in matches)
            {
                HtmlTagContent htmlTagContent = new HtmlTagContent(match.Value);
                tags.Add(new EaImageTag(htmlTagContent,match.Index, match.Length));
            }
            return tags;
        }


    }
}
