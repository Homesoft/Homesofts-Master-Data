using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Currency.Service;
using Homesofts.MongoConfiguration;
using MongoDB.Driver;
using Models = Homesofts.Currency.Service.models;
using MongoDB.Driver.Builders;

namespace Homesofts.Currency.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private MongoConfig mongoConfig;

        public CurrencyRepository(MongoConfig mongoConfig)
        {
            this.mongoConfig = mongoConfig;
        }

        public bool Exist(string code, string organizationId)
        {
            IMongoQuery query = Query.And(Query<Models.Currency>.EQ(i => i.Code, code), Query<Models.Currency>.EQ(i => i.OrganizationId, organizationId));
            return Collection.Count(query) > 0;
        }

        public void Insert(Service.models.Currency ccy)
        {
            Collection.Insert(ccy);
        }

        public Models.Currency Get(string ccyId)
        {
            return Collection.FindOneById(ccyId);
        }

        public void Update(Models.Currency ccy)
        {
            Collection.Save(ccy);
        }

        public void Remove(string id)
        {
            Collection.RemoveById(id);
        }

        private MongoCollection<Models.Currency> Collection
        {
            get { return mongoConfig.Database.GetCollection<Models.Currency>(); }
        }
    }
}
