using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.MongoConfiguration;

namespace Homesofts.Taxes.Service.Models
{
    public class Tax
    {
        public string Id { get; set; }
        [EnsureIndex]
        public string Code { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        [EnsureIndex]
        public Enum.TaxType Type { get; set; }
        [EnsureIndex]
        public string OrganizationId { get; set; }
    }
}
