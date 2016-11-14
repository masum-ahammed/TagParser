using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagParser.Lib.Model
{
    public class EaImageTag:Tag
    {
        public EaImageTag(HtmlTagContent htmlTagContent,int index, int length):
            base(TagEnum.EA_IMG, htmlTagContent, index, length)
        {

        }
    }
}
