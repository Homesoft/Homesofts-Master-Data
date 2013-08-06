using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.Currency.Service.parameters
{
    public class CreateParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Rounding { get; set; }
        public string OrganizationId { get; set; }

        public void Validate()
        {
            if (this.Code.IsNullOrWhiteSpace())
                throw new Exception("Code mata uang harus diisi");
            if (this.Name.IsNullOrWhiteSpace())
                throw new Exception("Nama mata uang harus diisi");
            if (this.OrganizationId.IsNullOrWhiteSpace())
                throw new Exception("Id Perusahaan harus diisi");
        }
    }
}
