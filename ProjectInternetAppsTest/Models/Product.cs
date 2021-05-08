﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public byte[] Img { get; set; }
        //public string Image { get; set; } //which type ???
        //public List<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}
