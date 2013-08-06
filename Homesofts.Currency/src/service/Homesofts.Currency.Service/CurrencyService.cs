using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.MongoConfiguration;
using Models = Homesofts.Currency.Service.models;
using Homesofts.Extension;

namespace Homesofts.Currency.Service
{
    public class CurrencyService : ICurrencyService
    {
        ICurrencyRepository repository;

        public CurrencyService(ICurrencyRepository repository)
        {
            this.repository = repository;
        }

        public Models.Currency Create(parameters.CreateParameter param)
        {
            param.Validate();
            AssertCurrencyNotExist(param.Code, param.OrganizationId);
            Models.Currency ccy = new Models.Currency
            {
                Id = Guid.NewGuid().ToString(),
                Code = param.Code,
                Name = param.Name,
                OrganizationId = param.OrganizationId,
                Rounding = param.Rounding,
                Symbol = param.Symbol
            };
            repository.Insert(ccy);
            return ccy;
        }

        public void Update(parameters.UpdateParameter param)
        {
            param.Validate();
            Models.Currency ccy = repository.Get(param.Id);
            if (ccy.IsNull())
                throw new Exception("Mata uang tidak di temukan");
            if (ccy.Code.NotEquals(param.Code))
            {
                AssertCurrencyNotExist(param.Code, ccy.OrganizationId);
                ccy.Code = param.Code;
            }
            if (ccy.Name.NotEquals(param.Name))
                ccy.Name = param.Name;
            if (ccy.Rounding != param.Rounding)
                ccy.Rounding = param.Rounding;
            if (ccy.Symbol.NotEquals(param.Symbol))
                ccy.Symbol = param.Symbol;

            repository.Update(ccy);
        }

        public void Remove(string id)
        {
            repository.Remove(id);
        }

        private void AssertCurrencyNotExist(string code, string ownerId)
        {
            if (repository.Exist(code, ownerId))
                throw new Exception(string.Format("Code {0} mata uang ini sudah ada.", code));
        }
    }
}
