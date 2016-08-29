using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScbwiSummer2016.Models
{
    public class Registration
    {
        public int id { get; set; }

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
        public virtual Location location { get; set; }
        public int locationid { get; set; }
        public string codeused { get; set; }
        public decimal total { get; set; }
        public decimal subtotal { get; set; }
        public DateTime created { get; set; }
        public DateTime paid { get; set; }
        public DateTime cleared { get; set; }
    }
}
