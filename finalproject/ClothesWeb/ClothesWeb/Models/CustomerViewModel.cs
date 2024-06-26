﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesWeb.Models
{
    public class CustomerViewModel
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Payment { get; set; }
    }
}