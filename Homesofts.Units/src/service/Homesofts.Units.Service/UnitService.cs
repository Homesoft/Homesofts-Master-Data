using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Extension;

namespace Homesofts.Units.Service
{
    public class UnitService : IUnitService
    {
        IUnitRepository repository;
        public UnitService(IUnitRepository repository)
        {
            this.repository = repository;
        }

        public Models.Unit Create(Parameters.CreateParameter param)
        {
            param.Validate();
            assertUnitCodeNotExist(param.Code, param.OrganizationId);
            assertUnitNameNotExist(param.Name, param.OrganizationId);
            Models.Unit unit = param.ParseToUnit();
            repository.Insert(unit);
            return unit;
        }

        public void Update(Parameters.UpdateParameter param)
        {
            param.Validate();
            Models.Unit unit = repository.Get(param.Id);
            if (unit.IsNull())
                throw new Exception("Unit tidak di temukan");
            if (unit.Code.NotEquals(param.Code))
            {
                assertUnitCodeNotExist(param.Code, unit.OrganizationId);
                unit.Code = param.Code;
            }
            if (unit.Name.NotEquals(param.Name))
            {
                assertUnitNameNotExist(param.Name, unit.OrganizationId);
                unit.Name = param.Name;
            }

            repository.Update(unit);
        }

        public void Remove(string id)
        {
            repository.Remove(id);
        }

        private void assertUnitCodeNotExist(string code, string organizationId)
        {
            if (repository.Exist(code, organizationId))
                throw new Exception(string.Format("Kode unit {0}, sudah terdaftar.", code));
        }

        private void assertUnitNameNotExist(string name, string organizationId)
        {
            if(repository.ExistName(name, organizationId))
                throw new Exception(string.Format("Nama unit {0}, sudah terdaftar.", name));
        }
    }
}
