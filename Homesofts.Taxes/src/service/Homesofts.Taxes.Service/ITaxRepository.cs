using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.Taxes.Service
{
    public interface ITaxRepository
    {
        bool Exist(string code, string organizationId);

        void Insert(Models.Tax tax);

        Models.Tax Get(string id);

        void Remove(string id);

        void Update(Models.Tax tax);
    }
}
