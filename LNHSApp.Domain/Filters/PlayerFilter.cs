using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Filters
{
    public class PlayerFilter
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
    }
}
