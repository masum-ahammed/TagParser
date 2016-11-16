using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagParser.Lib.Utility
{
    public class IdGenerator
    {
        public static string GenerateNewId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
