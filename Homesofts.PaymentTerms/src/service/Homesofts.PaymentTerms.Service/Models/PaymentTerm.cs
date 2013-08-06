using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.MongoConfiguration;

namespace Homesofts.PaymentTerms.Service.Models
{
    public class PaymentTerm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        [EnsureIndex]
        public string OrganizationId { get; set; }
    }
}
