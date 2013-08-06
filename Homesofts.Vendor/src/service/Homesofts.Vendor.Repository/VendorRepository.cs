using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Vendors.Service;
using Homesofts.MongoConfiguration;
using MongoDB.Driver;
using Models = Homesofts.Vendors.Service.models;
using Others = Homesofts.Vendors.Service.others;
using Builder = MongoDB.Driver.Builders;

namespace Homesofts.Vendors.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private MongoConfig mongoConfig;

        public VendorRepository(MongoConfig mongoConfig)
        {
            this.mongoConfig = mongoConfig;
        }

        public bool VendorExist(string code, string organizationId)
        {
            var predicate = Builder.Query.And(
                Builder.Query<Models.Vendor>.EQ(i => i.Code, code), 
                Builder.Query<Models.Vendor>.EQ(i => i.OrganizationId, organizationId));
            return Collection.Count(predicate) > 0;
        }

        public bool PaymentTermExist(string paymentTermId, string organizationId)
        {
            var predicate = Builder.Query.And(
                Builder.Query<Others.PaymentTerm>.EQ(i => i.Id, paymentTermId), 
                Builder.Query<Others.PaymentTerm>.EQ(i => i.OrganizationId, organizationId));
            return PaymentTermCollection.Count(predicate) > 0;
        }

        public bool CurrencyExist(string currencyId, string organizationId)
        {
            var predicate = Builder.Query.And(
                Builder.Query<Others.Currency>.EQ(i => i.Id, currencyId), 
                Builder.Query<Others.Currency>.EQ(i => i.OrganizationId, organizationId));
            return CurrencyCollection.Count(predicate) > 0;
        }

        public void Save(Models.Vendor vendor)
        {
            Collection.Insert(vendor);
        }

        public Models.Vendor Get(string id)
        {
            return Collection.FindOneById(id);
        }

        public void Update(Models.Vendor vendor)
        {
            Collection.Save(vendor);
        }

        #region Mongo Collection Region

        private MongoCollection<Models.Vendor> Collection
        {
            get { return mongoConfig.Database.GetCollection<Models.Vendor>(); }
        }

        private MongoCollection<Others.PaymentTerm> PaymentTermCollection
        {
            get { return mongoConfig.Database.GetCollection<Others.PaymentTerm>(); }
        }

        private MongoCollection<Others.Currency> CurrencyCollection
        {
            get { return mongoConfig.Database.GetCollection<Others.Currency>(); }
        }

        #endregion
    }
}
