using System;
using System.Collections.Generic;

#nullable disable

namespace sakilaconsole.sakila
{
    public partial class AddressInfo
    {
        public short AddressId { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public short CityId { get; set; }
        public string City { get; set; }
    }
}
