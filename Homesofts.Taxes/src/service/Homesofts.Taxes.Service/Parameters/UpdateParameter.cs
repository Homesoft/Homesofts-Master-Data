using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.Taxes.Service.Parameters
{
    public class UpdateParameter
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public Enum.TaxType Type { get; set; }

        public void Validate()
        {
            if (this.Code.IsNullOrWhiteSpace())
                throw new Exception("Code pajak harus diisi");
            if (this.Name.IsNullOrWhiteSpace())
                throw new Exception("Nama pajak harus diisi");
            if (this.Value.IsNull())
                throw new Exception("Nilai pajak harus diisi");
            if (this.Value < 1)
                throw new Exception("Nilai pajak tidak boleh kurang dari satu");
        }
    }
}
