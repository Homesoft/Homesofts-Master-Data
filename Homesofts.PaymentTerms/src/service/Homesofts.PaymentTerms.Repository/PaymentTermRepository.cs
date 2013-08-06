using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.PaymentTerms.Service;
using Homesofts.MongoConfiguration;
using MongoDB.Driver;
using Homesofts.PaymentTerms.Service.Models;
using MongoDB.Driver.Builders;

namespace Homesofts.PaymentTerms.Repository
{
    public class PaymentTermRepository : IPaymentTermRepository
    {
        MongoConfig mongoConfig;
        public PaymentTermRepository(MongoConfig mongoConfig)
        {
            this.mongoConfig = mongoConfig;
        }

        public bool Exist(int value, string organizationId)
        {
            IMongoQuery query = Query.And(Query<PaymentTerm>.EQ(i => i.Value, value), Query<PaymentTerm>.EQ(i => i.OrganizationId, organizationId));
            return Collection.Count(query) > 0;
        }

        public void Insert(Service.Models.PaymentTerm term)
        {
            Collection.Insert(term);
        }

        public Service.Models.PaymentTerm Get(string id)
        {
            return Collection.FindOneById(id);
        }

        public void Update(Service.Models.PaymentTerm term)
        {
            Collection.Save(term);
        }

        public void Remove(string id)
        {
            Collection.RemoveById(id);
        }

        private MongoCollection<PaymentTerm> Collection
        {
            get { return mongoConfig.Database.GetCollection<PaymentTerm>(); }
        }
    }
}
