using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Vendors.Service.models;
using Homesofts.Extension;

namespace Homesofts.Vendors.Service
{
    public class VendorService : IVendorService
    {
        IVendorRepository _repository;

        public VendorService(IVendorRepository repository)
        {
            if (repository.IsNull()) throw new Exception("Vendor Repository should not be null");
            this._repository = repository;
        }

        public string Create(parameters.CreateVendorParameter param)
        {
            param.Validate();
            assertVendorNotExist(param.Code, param.OrganizationId);
            assertPaymentTermAlreadyExist(param.PaymentTermId, param.OrganizationId);
            assertCurrencyAlreadyExist(param.CurrencyId, param.OrganizationId);

            Vendor vendor = new Vendor(param);
            _repository.Save(vendor);
            return vendor.Id;
        }

        public void Update(parameters.UpdateVendorParameter param)
        {
            param.Validate();
            Vendor vendor = _repository.Get(param.Id);
            assertVendorNotNull(vendor);

            if (!vendor.Code.Equals(param.Code)) 
                assertVendorNotExist(param.Code, vendor.OrganizationId);
            if (!vendor.CurrencyId.Equals(param.CurrencyId))
                assertCurrencyAlreadyExist(param.CurrencyId, vendor.OrganizationId);
            if (!vendor.PaymentTermId.Equals(param.PaymentTermId))
                assertPaymentTermAlreadyExist(param.PaymentTermId, vendor.OrganizationId);

            vendor.Update(param);
            _repository.Update(vendor);
        }

        public void DeActivate(string id)
        {
            Vendor vendor = _repository.Get(id);
            assertVendorNotNull(vendor);
            if (vendor.Status == enums.Status.InActive)
                return;

            vendor.DeActivate();
            _repository.Update(vendor);
        }

        public void Activate(string id)
        {
            Vendor vendor = _repository.Get(id);
            assertVendorNotNull(vendor);
            if (vendor.Status == enums.Status.Active)
                return;

            vendor.Activate();
            _repository.Update(vendor);
        }

        #region Assert Method

        private void assertVendorNotExist(string code, string organizationId)
        {
            if (_repository.VendorExist(code, organizationId))
                throw new Exception(string.Format("Vendor dengan kode ini ({0}) telah ada.", code));
        }

        private void assertPaymentTermAlreadyExist(string paymentTermId, string organizationId)
        {
            if (!_repository.PaymentTermExist(paymentTermId, organizationId))
                throw new Exception("Termin Pembayaran tidak ditemukan.");
        }

        private void assertCurrencyAlreadyExist(string currencyId, string organizationId)
        {
            if(!_repository.CurrencyExist(currencyId, organizationId))
                throw new Exception("Mata Uang tidak ditemukan.");
        }

        private void assertVendorNotNull(Vendor vendor)
        {
            if(vendor.IsNull())
                throw new Exception("Vendor tidak ditemukan.");
        }

        #endregion
    }
}
