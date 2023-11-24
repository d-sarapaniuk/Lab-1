using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class Seller : Person
    {
        public override string? First_Name { get; set; }
        public override string? Last_Name { get; set; }
        public override string? Gender { get; set; }
        public Seller(string first_Name, string last_Name, string gender) : base(first_Name, last_Name, gender) { }
    }
}
