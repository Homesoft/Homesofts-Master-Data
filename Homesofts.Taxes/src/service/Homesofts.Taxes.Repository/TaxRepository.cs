using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Taxes.Service;
using Homesofts.MongoConfiguration;
using MongoDB.Driver;
using Models = Homesofts.Taxes.Service.Models;
using Builder = MongoDB.Driver.Builders;

namespace Homesofts.Taxes.Repository
{
    public class TaxRepository : ITaxRepository
    {
        private MongoConfig mongoConfig;
        public TaxRepository(MongoConfig mongoConfig)
        {
            this.mongoConfig = mongoConfig;
        }

        public bool Exist(string code, string organizationId)
        {
            IMongoQuery query = Builder.Query.And(Builder.Query<Models.Tax>.EQ(i => i.Code, code), Builder.Query<Models.Tax>.EQ(i => i.OrganizationId, organizationId));
            return Collection.Count(query) > 0;
        }

        public void Insert(Service.Models.Tax tax)
        {
            Collection.Insert(tax);
        }

        public void Update(Models.Tax tax)
        {
            Collection.Save(tax);
        }

        public Models.Tax Get(string id)
        {
            return Collection.FindOneById(id);
        }

        public void Remove(string id)
        {
            Collection.RemoveById(id);
        }

        private MongoCollection<Models.Tax> Collection
        {
            get { return mongoConfig.Database.GetCollection<Models.Tax>(); }
        }
    }
}
