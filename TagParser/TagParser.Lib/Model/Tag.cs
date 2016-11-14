using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TagParser.Lib.Model
{
    public abstract class Tag
    {
        string _Type;
        HtmlTagContent _HtmlContent;
        int _Index;
        int _Length;
        public Tag(TagEnum type, HtmlTagContent htmlContent, int index, int length)
        {
            if (htmlContent == null)
            {
                throw new ArgumentNullException("tag content html is not defined.");
            }
            _Type = Enum.GetName(typeof(TagEnum),type);
            _HtmlContent = htmlContent;
            _Index = index;
            _Length = length;
        }
        public string Name { get { return _HtmlContent.GetAttributeValueByName("name"); } }
        public string Type { get { return _Type; } }
        public string DefaultValue { get { return _HtmlContent.InnerHtml; } }
        public int Index { get { return _Index; } }
        public int Length { get { return _Length; } }
        public List<Tag> Childern { get; set; }


    }
}
