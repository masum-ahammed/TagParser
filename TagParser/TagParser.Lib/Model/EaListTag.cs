using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagParser.Lib.Utility;

namespace TagParser.Lib.Model
{
    public class EaListTag : Tag
    {
        public EaListTag(HtmlTagContent htmlTagContent,int index, int length):
            base(TagEnum.EA_LIST, htmlTagContent, index, length)
        {
            base.Childern = new List<Tag>();
            base.Childern.AddRange(GetTextTags(htmlTagContent.InnerHtml));
            base.Childern.AddRange(GetImageTags(htmlTagContent.InnerHtml));
        }

        private  List<Tag> GetTextTags(string content)
        {
            List<Tag> tags = new List<Tag>();
            string pattern = "(<EA_LIST_TXT(.*)EA_LIST_TXT>)|(<ea_list_txt(.*)ea_list_txt>)";
            MatchCollection matches = RegularExpressionUtility.GetMaches(pattern, content);
            foreach (Match match in matches)
            {
                HtmlTagContent htmlTagContent = new HtmlTagContent(match.Value);
                tags.Add(new EaTextTag(htmlTagContent, match.Index, match.Length));
            }
            return tags;
        }
        private List<Tag> GetImageTags(string content)
        {
            List<Tag> tags = new List<Tag>();
            string pattern = "(<EA_LIST_IMG(.*)EA_LIST_IMG>)|(<ea_list_img(.*)ea_list_img>)";
            MatchCollection matches = RegularExpressionUtility.GetMaches(pattern, content);
            foreach (Match match in matches)
            {
                HtmlTagContent htmlTagContent = new HtmlTagContent(match.Value);
                tags.Add(new EaImageTag(htmlTagContent, match.Index, match.Length));
            }
            return tags;
        }
    }
}
