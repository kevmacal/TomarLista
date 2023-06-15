using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomarLista
{
    class ParesString
    {
        String par1;
        String par2;

        public ParesString()
        {
            par1 = "";
            par2 = "";
        }

        public ParesString(String str1, String str2)
        {
            this.par1 = str1;
            this.par2 = str2;
        }

        public String Par1
        {
            get { return par1; }
            set { par1 = value; }
        }
        public String Par2
        {
            get { return par2; }
            set { par2 = value; }
        }
    }
}
