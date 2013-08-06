using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.MongoConfiguration;
using Homesofts.Extension;
using MongoDB.Bson.Serialization.Attributes;

namespace Homesofts.Vendors.Service.models
{
    public class Vendor
    {
        #region Property

        [BsonId]
        public string Id { get; set; }

        [EnsureIndex, BsonRequired]
        public string Code { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [EnsureIndex, BsonRequired]
        public string OrganizationId { get; set; }

        [EnsureIndex]
        public enums.VendorType Type { get; set; }

        [BsonRequired]
        public string CurrencyId { get; set; }

        [BsonRequired]
        public string PaymentTermId { get; set; }
        
        [EnsureIndex]
        public enums.Status Status { get; set; }

        [BsonDefaultValue("")]
        public string Address { get; set; }

        [BsonDefaultValue("")]
        public string City { get; set; }

        [BsonDefaultValue("")]
        public string ZipCode { get; set; }

        [BsonDefaultValue("")]
        public string Country { get; set; }

        public List<VendorContact> Contacts { get; set; }

        [BsonDefaultValue(0D)]
        public double CreditLimit { get; set; }

        [BsonDefaultValue(0D)]
        public double Outstanding { get; set; }

        #endregion

        public Vendor()
        {
            this.Contacts = new List<VendorContact>();
        }

        public Vendor(parameters.CreateVendorParameter param)
            : this()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Code = param.Code;
            this.CurrencyId = param.CurrencyId;
            this.Name = param.Name;
            this.OrganizationId = param.OrganizationId;
            this.PaymentTermId = param.PaymentTermId;
            this.Type = param.VendorType;
            this.Status = enums.Status.Active;
            this.Address = param.Address.IsNull() ? "": param.Address;
            this.City = param.City.IsNull() ? "" : param.City;
            this.Country = param.Country.IsNull() ? "":param.Country;
            this.ZipCode = param.ZipCode.IsNull() ? "" : param.ZipCode;
            AddContacts(param.Contacts);
        }

        public void Update(parameters.UpdateVendorParameter param)
        {
            if (param.Address.IsNotNull() && param.Address.NotEquals(this.Address)) this.Address = param.Address;
            if (param.City.IsNotNull() && param.City.NotEquals(this.City)) this.City = param.City;
            if (param.Code.IsNotNull() && param.Code.NotEquals(this.Code)) this.Code = param.Code;
            if (param.Country.IsNotNull() && param.Country.NotEquals(this.Country)) this.Country = param.Country;
            if (param.CurrencyId.IsNotNull() && param.CurrencyId.NotEquals(this.CurrencyId)) this.CurrencyId = param.CurrencyId;
            if (param.Name.IsNotNull() && param.Name.NotEquals(this.Name)) this.Name = param.Name;
            if (param.PaymentTermId.IsNotNull() && param.PaymentTermId.NotEquals(this.PaymentTermId)) this.PaymentTermId = param.PaymentTermId;
            if (param.ZipCode.IsNotNull() && param.ZipCode.NotEquals(this.ZipCode)) this.ZipCode = param.ZipCode;

            if (param.Contacts.IsNotNull() && param.Contacts.IsNotEmpty())
            {
                this.Contacts = new List<VendorContact>();
                param.Contacts.ForEach(i => i.Id = (i.Id.IsNull() || i.Id.Equals(string.Empty)) ? Guid.NewGuid().ToString() : i.Id);
                if (param.Contacts.Where(i => i.IsDefault == true).Count() > 0)
                {
                    param.Contacts.Select(i => i.IsDefault = false);
                    param.Contacts.First().IsDefault = true;
                }
                else
                {
                    param.Contacts.First().IsDefault = true;
                }
            }
        }

        public void AddContacts(List<parameters.CreateVendorContactParameter> parameters)
        {
            if (parameters.IsNotNull() && parameters.IsNotEmpty())
            {
                if (parameters.Count(i => i.IsDefault == true) > 1)
                {
                    parameters.Select(i => i.IsDefault = false);
                    parameters.First().IsDefault = true;
                }
                else if(parameters.Count(i => i.IsDefault == true) == 0)
                {
                    parameters.First().IsDefault = true;
                }
                parameters.ForEach(i =>
                {
                    AddContact(i);
                });
            }
        }

        public void UpdateContacts(List<parameters.UpdateVendorContactParameter> parameters)
        {
            if (parameters.IsNotNull() && parameters.IsNotEmpty())
            {
                
            }
        }

        public void AddContact(parameters.CreateVendorContactParameter param)
        {
            if (this.Contacts.IsNotNull() && this.Contacts.IsNotEmpty())
            {
                var emails = this.Contacts.Select(i => i.Email);
                if (emails.Contains(param.Email))
                    throw new ApplicationException(string.Format("Email ini ({0}) telah ada di kontak vendor {1}", param.Email, this.Name));
                if (param.IsDefault.Equals(true))
                    this.Contacts.ForEach(i => i.IsDefault = false);
            }
            this.Contacts.Add(new VendorContact(param));
        }

        public void DeActivate()
        {
            this.Status = enums.Status.InActive;
        }

        public void Activate()
        {
            this.Status = enums.Status.Active;
        }
    }
}
