using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    public partial class StarSign
    {
        //The name of the class + the suffix id = primary key
        public int StarSignId { get; set; }
        public string NameDetails { get; set; }


    }
}
