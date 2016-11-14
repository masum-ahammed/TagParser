using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagParser.Lib.Model
{
    public class EaTextTag:Tag
    {
        public EaTextTag(HtmlTagContent htmlTagContent,int index, int length):
            base(TagEnum.EA_TXT, htmlTagContent, index, length)
        {

        }
    }
}
