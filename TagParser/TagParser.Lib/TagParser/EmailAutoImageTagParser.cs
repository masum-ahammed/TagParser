using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagParser.Lib.Model;

namespace TagParser.Lib.TagParser
{
    public class EmailAutoImageTagParser : ITagParser
    {
        public List<Tag> Parse(string content)
        {
            List<Tag> tags = new List<Tag>();
            string pattern = "<EA_IMG.+EA_IMG>";
            MatchCollection matches = RegularExpressionUtility.GetMaches(pattern, content);
            foreach (Match match in matches)
            {
                tags.Add(Tag.CreateNew(match,TagEnum.EA_IMG.ToString()));
            }
            return tags;
        }

       
    }
}
