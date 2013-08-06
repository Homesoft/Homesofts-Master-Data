using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Currency.Service;
using Models = Homesofts.Currency.Service.models;

namespace Homesofts.Currency.Test.Component.fakerepository
{
    public class FakeCurrencyRepository : ICurrencyRepository
    {
        List<Models.Currency> currencies;
        public FakeCurrencyRepository()
        {
            currencies = new List<Models.Currency>();
        }

        public bool Exist(string code, string ownerId)
        {
            return currencies.Where(i => i.Code.Equals(code) && i.OrganizationId.Equals(ownerId)).Count() > 0;
        }

        public void Insert(Service.models.Currency ccy)
        {
            currencies.Add(ccy);
        }

        public Models.Currency Get(string ccyId)
        {
            return currencies.FirstOrDefault(i => i.Id == ccyId);
        }

        public void Update(Models.Currency ccy)
        {
            Models.Currency currency = currencies.FirstOrDefault(i => i.Id == ccy.Id);
            currencies.Remove(currency);
            currencies.Add(ccy);
        }

        public void Remove(string id)
        {
            Models.Currency currency = currencies.FirstOrDefault(i => i.Id == id);
            currencies.Remove(currency);
        }
    }
}
