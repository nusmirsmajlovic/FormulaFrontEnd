﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace formulaFrontEnd.ViewModels
{
    public class Driver
    {
        public int driverId { get; set; }

        public string name { get; set; }
        public string surname { get; set; }

        public List<Coment> coments { get; set; }
    }
}
