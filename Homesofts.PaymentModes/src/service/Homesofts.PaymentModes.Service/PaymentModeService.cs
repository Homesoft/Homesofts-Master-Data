using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.PaymentModes.Service
{
    public class PaymentModeService : IPaymentModeService
    {
        IPaymentModeRepository repository;
        public PaymentModeService(IPaymentModeRepository repository)
        {
            this.repository = repository;
        }

        public Models.PaymentMode Create(Parameters.CreateParameter param)
        {
            param.Validate();
            assertPaymentModeNotExist(param.Name, param.OrganizationId);
            Models.PaymentMode mode = param.ParseToPaymentMode();
            repository.Insert(mode);
            return mode;
        }

        public void Update(Parameters.UpdateParameter param)
        {
            param.Validate();
            Models.PaymentMode mode = repository.Get(param.Id);
            if (mode.Name.NotEquals(param.Name))
            {
                assertPaymentModeNotExist(param.Name, mode.OrganizationId);
                mode.Name = param.Name;
            }
            repository.Update(mode);
        }

        public void Remove(string id)
        {
            repository.Remove(id);
        }
        private void assertPaymentModeNotExist(string name, string organizationId)
        {
            if (repository.Exist(name, organizationId))
                throw new Exception(string.Format("Nama Jenis Pembayaran {0} sudah terdaftar", name));
        }
    }
}
