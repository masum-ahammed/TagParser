using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TagParser.Lib
{
    public class RegularExpressionUtility
    {
        public static MatchCollection GetMaches(string pattern,string content)
        {
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            return rgx.Matches(content);
        }
    }
}
