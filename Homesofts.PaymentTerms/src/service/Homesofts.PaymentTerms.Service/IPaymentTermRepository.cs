using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.PaymentTerms.Service
{
    public interface IPaymentTermRepository
    {
        bool Exist(int value, string organizationId);

        void Insert(Models.PaymentTerm term);

        Models.PaymentTerm Get(string id);

        void Update(Models.PaymentTerm term);

        void Remove(string id);
    }
}
