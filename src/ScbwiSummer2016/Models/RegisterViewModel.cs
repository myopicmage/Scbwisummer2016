using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScbwiSummer2016.Models
{
    public class RegisterViewModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public bool member { get; set; }
        public int locationid { get; set; }
        public string codeused { get; set; }
    }
}
