using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.Units.Service
{
    public interface IUnitRepository
    {
        bool Exist(string code, string organizationId);

        void Insert(Models.Unit unit);

        Models.Unit Get(string id);

        void Update(Models.Unit unit);

        void Remove(string id);

        bool ExistName(string name, string organizationId);
    }
}
