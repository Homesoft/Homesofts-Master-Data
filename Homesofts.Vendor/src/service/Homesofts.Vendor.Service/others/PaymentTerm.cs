using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Homesofts.Vendors.Service.others
{
    [BsonIgnoreExtraElements]
    public class PaymentTerm
    {
        public string Id { get; set; }
        public string OrganizationId { get; set; }
    }
}
