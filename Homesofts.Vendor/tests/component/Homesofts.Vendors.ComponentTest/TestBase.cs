using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Homesofts.MongoConfiguration;
using Homesofts.Vendors.Service.others;
using MongoDB.Driver.Builders;

namespace Homesofts.Vendors.ComponentTest
{
    public class TestBase
    {
        public TestBase()
        {
            try
            {
                MongoConfig.Instance.Database.GetCollection<PaymentTerm>().Insert(
                    new PaymentTerm
                    {
                        Id = "term-001",
                        OrganizationId = "denny@homesofts.com"
                    });
                MongoConfig.Instance.Database.GetCollection<PaymentTerm>().Insert(
                    new PaymentTerm
                    {
                        Id = "term-002",
                        OrganizationId = "denny@homesofts.com"
                    });
                MongoConfig.Instance.Database.GetCollection<Currency>().Insert(
                    new Currency
                    {
                        Id = "ccy-001",
                        OrganizationId = "denny@homesofts.com"
                    });
                MongoConfig.Instance.Database.GetCollection<Currency>().Insert(
                    new Currency
                    {
                        Id = "ccy-002",
                        OrganizationId = "denny@homesofts.com"
                    });
            }
            catch (Exception ex)
            {
                RemoveOtherData();
            }
        }

        public static void RemoveOtherData()
        {
            MongoConfig.Instance.Database.GetCollection<PaymentTerm>().Remove(Query<PaymentTerm>.EQ(i => i.Id, "term-001"));
            MongoConfig.Instance.Database.GetCollection<PaymentTerm>().Remove(Query<PaymentTerm>.EQ(i => i.Id, "term-002"));
            MongoConfig.Instance.Database.GetCollection<Currency>().Remove(Query.EQ("_id", "ccy-001"));
            MongoConfig.Instance.Database.GetCollection<Currency>().Remove(Query.EQ("_id", "ccy-002"));
        }
    }
}
