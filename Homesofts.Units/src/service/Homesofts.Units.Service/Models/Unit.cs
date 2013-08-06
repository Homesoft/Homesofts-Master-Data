using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.MongoConfiguration;

namespace Homesofts.Units.Service.Models
{
    public class Unit
    {
        public string Id { get; set; }
        [EnsureIndex]
        public string Code { get; set; }
        public string Name { get; set; }
        [EnsureIndex]
        public string OrganizationId { get; set; }
    }
}
