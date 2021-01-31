using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace formulaFrontEnd.ViewModels
{
    public class Circuit
    {
        public string circuitId { get; set; }
        public string url { get; set; }
        public string circuitName { get; set; }
        public Location Location { get; set; }
    }
}
