using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.MongoConfiguration;

namespace Homesofts.PaymentModes.Service.Models
{
    public class PaymentMode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [EnsureIndex]
        public string OrganizationId { get; set; }
    }
}
