using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.PaymentModes.Service
{
    public interface IPaymentModeRepository
    {
        bool Exist(string name, string organizationId);

        void Insert(Models.PaymentMode mode);

        Models.PaymentMode Get(string id);

        void Update(Models.PaymentMode mode);

        void Remove(string id);
    }
}
