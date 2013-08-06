using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.Units.Service.Parameters
{
    public class UpdateParameter
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            if (Code.IsNullOrWhiteSpace())
                throw new Exception("Kode unit harus diisi");
            if (Name.IsNullOrWhiteSpace())
                throw new Exception("Name unit harus diisi");
        }
    }
}
