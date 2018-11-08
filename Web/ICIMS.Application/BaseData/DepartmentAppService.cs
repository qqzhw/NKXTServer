using Abp.Domain.Repositories;
using Abp.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData
{
   public class DepartmentAppService: OrganizationUnitManager,IDepartmentAppService
    {
        private IRepository<OrganizationUnit, long> _organizationUnitRepository;
        public DepartmentAppService(IRepository<OrganizationUnit, long>  organizationUnitRepository):base(organizationUnitRepository)
        {
            _organizationUnitRepository = organizationUnitRepository;
        }
    }
}
