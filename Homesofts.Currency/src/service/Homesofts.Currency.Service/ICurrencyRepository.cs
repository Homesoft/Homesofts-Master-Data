using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models = Homesofts.Currency.Service.models;

namespace Homesofts.Currency.Service
{
    public interface ICurrencyRepository
    {
        bool Exist(string code, string organizationId);

        void Insert(Models.Currency ccy);

        Models.Currency Get(string ccyId);

        void Update(Models.Currency ccy);

        void Remove(string id);
    }
}
