using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ClientInfo
    {
        public int Id { get; set; }
        public string Culture { get; set; }
        public string Country { get; set; }
        public string Ipv6 { get; set; }
        public string Ipv4 { get; set; }
        public string OS { get; set; }
        public string Privileges { get; set; }
        public string Pcname { get; set; }
        public string Antivirussoftware { get; set; }
        public string RSAPubKey { get; set; }
        public string SymKey { get; set; }
    }
}
