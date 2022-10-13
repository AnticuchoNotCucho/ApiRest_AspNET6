﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRest.Model
{
    public class Band
    {
        public int idBands { get; set; }
        public string? Name { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
