using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagParser.Lib.Model;

namespace TagParser.Lib.TagParser
{
    public class TagParserFactory
    {
        public static AbstractTagParser GetParser(TagEnum tagType)
        {
            switch (tagType)
            {
                case TagEnum.EA_IMG:
                   return new EaImageTagParser();
                case TagEnum.EA_TXT:
                    return new EaTxtTagParser();
                case TagEnum.EA_LIST:
                    return new EaListTagParser();
                default:
                    return null;
            }
        }
    }
}
