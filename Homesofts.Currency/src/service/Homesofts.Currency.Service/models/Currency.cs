using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.MongoConfiguration;
using MongoDB.Bson.Serialization.Attributes;

namespace Homesofts.Currency.Service.models
{
    public class Currency
    {
        public string Id { get; set; }
        [EnsureIndex]
        public string OrganizationId { get; set; }
        [EnsureIndex]
        public string Code { get; set; }
        public string Name { get; set; }
        [BsonDefaultValue("")]
        public string Symbol { get; set; }
        [BsonDefaultValue(2)]
        public int Rounding { get; set; }
        //public bool IsBaseCurrency { get; set; }
    }
}
