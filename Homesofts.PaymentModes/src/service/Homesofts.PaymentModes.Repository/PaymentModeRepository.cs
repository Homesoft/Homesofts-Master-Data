using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.PaymentModes.Service;
using Homesofts.MongoConfiguration;
using MongoDB.Driver;
using Homesofts.PaymentModes.Service.Models;
using MongoDB.Driver.Builders;

namespace Homesofts.PaymentModes.Repository
{
    public class PaymentModeRepository : IPaymentModeRepository
    {
        MongoConfig mongoConfig;
        public PaymentModeRepository(MongoConfig mongoConfig)
        {
            this.mongoConfig = mongoConfig;
        }

        public bool Exist(string name, string organizationId)
        {
            IMongoQuery query = Query.And(Query<PaymentMode>.EQ(i => i.Name, name), Query<PaymentMode>.EQ(i => i.OrganizationId, organizationId));
            return Collection.Count(query) > 0;
        }

        public void Insert(Service.Models.PaymentMode mode)
        {
            Collection.Insert(mode);
        }

        public Service.Models.PaymentMode Get(string id)
        {
            return Collection.FindOneById(id);
        }

        public void Update(Service.Models.PaymentMode mode)
        {
            Collection.Save(mode);
        }

        public void Remove(string id)
        {
            Collection.RemoveById(id);
        }

        private MongoCollection<PaymentMode> Collection
        {
            get { return mongoConfig.Database.GetCollection<PaymentMode>(); }
        }
    }
}
