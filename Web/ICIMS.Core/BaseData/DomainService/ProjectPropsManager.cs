using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData.DomainService
{
    public class ProjectPropsManager: ICIMSDomainServiceBase,IProjectPropsManager
    {
        private readonly IRepository<ProjectProps, int> _repository;
        public ProjectPropsManager(IRepository<ProjectProps, int> repository)
        {
            this._repository = repository;
        }

        public void InitProjectProps()
        {
            throw new NotImplementedException();
        }

    }
}
