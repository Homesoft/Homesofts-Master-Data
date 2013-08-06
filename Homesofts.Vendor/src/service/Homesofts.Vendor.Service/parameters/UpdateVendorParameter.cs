using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;
using Homesofts.Vendors.Service.models;

namespace Homesofts.Vendors.Service.parameters
{
    public class UpdateVendorParameter
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PaymentTermId { get; set; }
        public string CurrencyId { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public List<UpdateVendorContactParameter> Contacts { get; set; }

        internal void Validate()
        {
            if (this.Id.Equals(string.Empty))
                throw new Exception(string.Format("Id Vendor tidak ditemukan"));

            if (this.Id.Equals(Guid.Empty.ToString()))
                throw new Exception(string.Format("Id Vendor tidak ditemukan"));

            if (this.Code.IsNull() || this.Code.Equals(string.Empty))
                throw new Exception(string.Format("Code harus diisi"));

            if (this.Name.IsNull() || (this.Name.Trim().Length > 0 && this.Name.Length < 6))
                throw new Exception(string.Format("Nama harus lebih dari 6 karakter"));

            if (this.PaymentTermId.IsNull() || this.PaymentTermId.Equals(Guid.Empty.ToString()))
                throw new Exception(string.Format("Termin Pembayaran harus dipilih"));

            if (this.CurrencyId.IsNull() || this.CurrencyId.Equals(Guid.Empty.ToString()))
                throw new Exception(string.Format("Mata Uang harus dipilih"));
            
            if (this.Contacts.IsNotNull() && this.Contacts.IsNotEmpty())
            {
                var contactEmails = this.Contacts.Select(i => i.Email);
                this.Contacts.ForEach(i =>
                {
                    if (contactEmails.Count(e => e == i.Email) > 1)
                    {
                        throw new ApplicationException(string.Format("Email ini ({0}) telah ada di kontak vendor {1}", i.Email, this.Name));
                    }
                });
            }
        }
    }
}
