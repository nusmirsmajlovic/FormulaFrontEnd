using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace formulaFrontEnd.ViewModels
{
    public class Coment
    {
        public int comentId { get; set; }

        public string coment { get; set; }
        public DateTime createdAt { get; set; }
        public int driverId { get; set; }
    }
}
