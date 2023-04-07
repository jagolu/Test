﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Model
{
    public class CatalogProduct
    {
        public int Id { get; set; }
        public int CategoryId { get;set; }
        public string Name { get; set; }
        public double Price { get; set; }   
    }
}
