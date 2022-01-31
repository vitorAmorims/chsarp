using System;
using System.Collections.Generic;

#nullable disable

namespace sakilaconsole.sakila
{
    public partial class SalesByStore
    {
        public string Store { get; set; }
        public string Manager { get; set; }
        public decimal? TotalSales { get; set; }
    }
}
