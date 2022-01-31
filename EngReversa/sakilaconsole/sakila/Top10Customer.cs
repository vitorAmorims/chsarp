using System;
using System.Collections.Generic;

#nullable disable

namespace sakilaconsole.sakila
{
    public partial class Top10Customer
    {
        public short CustomerId { get; set; }
        public string FirstName { get; set; }
        public decimal? TotalAmountSpent { get; set; }
    }
}
