﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.Vendors.Service.parameters
{
    public class UpdateVendorContactParameter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool IsDefault { get; set; }
    }
}
