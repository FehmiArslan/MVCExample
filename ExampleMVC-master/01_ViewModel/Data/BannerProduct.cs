﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_ViewModel.Data
{
    public class BannerArea
    {

        public int Id { get; set; }

        public List<Product> BanProducts { get; set; }
    }
}