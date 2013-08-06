using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Units.Service;
using Homesofts.MongoConfiguration;
using MongoDB.Driver;
using Homesofts.Units.Service.Models;
using MongoDB.Driver.Builders;

namespace Homesofts.Units.Repository
{
    public class UnitRepository : IUnitRepository
    {
        MongoConfig mongoConfig;
        public UnitRepository(MongoConfig mongoConfig)
        {
            this.mongoConfig = mongoConfig;
        }

        public bool Exist(string code, string organizationId)
        {
            IMongoQuery query = Query.And(Query<Unit>.EQ(i => i.Code, code), Query<Unit>.EQ(i => i.OrganizationId, organizationId));
            return Collection.Count(query) > 0;
        }

        public bool ExistName(string name, string organizationId)
        {
            IMongoQuery query = Query.And(Query<Unit>.EQ(i => i.Name, name), Query<Unit>.EQ(i => i.OrganizationId, organizationId));
            return Collection.Count(query) > 0;
        }

        public void Insert(Service.Models.Unit unit)
        {
            Collection.Insert(unit);
        }

        public Service.Models.Unit Get(string id)
        {
            return Collection.FindOneById(id);
        }

        public void Update(Service.Models.Unit unit)
        {
            Collection.Save(unit);
        }

        public void Remove(string id)
        {
            Collection.RemoveById(id);
        }

        private MongoCollection<Unit> Collection
        {
            get { return mongoConfig.Database.GetCollection<Unit>(); }
        }
    }
}
