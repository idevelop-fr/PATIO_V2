using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PATIO.Classes
{
    public class TypeElement
    {
        public string code { get; set; }
        public int id { get; set; }

        public TypeElement(string c, int i)
        {
            code=c;
            id=i;
        }
    }
}
