
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagParser.Lib.Model;

namespace TagParser.Lib.TagParser
{
    public interface ITagParser
    {
        List<Tag> Parse(string content);
    }
}
