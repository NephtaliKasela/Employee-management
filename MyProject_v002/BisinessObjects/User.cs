using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_v002.BisinessObjects
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return Name + "\t" + Password;
        }
    }
}
