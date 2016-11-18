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
    public class EaTxtTagParser : AbstractTagParser
    {
        public override string GetRegExPattern()
        {
            return "(<EA_TXT(.*)EA_TXT>)|(<ea_txt(.*)ea_txt>)";
        }


    }
}
