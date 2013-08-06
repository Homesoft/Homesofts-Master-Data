using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.Units.Service.Parameters
{
    public class CreateParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrganizationId { get; set; }

        public void Validate()
        {
            if (Code.IsNullOrWhiteSpace())
                throw new Exception("Kode unit harus diisi");
            if (Name.IsNullOrWhiteSpace())
                throw new Exception("Nama unit harus diisi");
            if (OrganizationId.IsNullOrWhiteSpace())
                throw new Exception("Id Perusahaan harus diisi");
        }

        public Models.Unit ParseToUnit()
        {
            Models.Unit unit = new Models.Unit
            {
                Id = Guid.NewGuid().ToString(),
                Code = this.Code,
                Name = this.Name,
                OrganizationId = this.OrganizationId
            };
            return unit;
        }
    }
}
