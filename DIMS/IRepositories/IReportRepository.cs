using DIMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IReportRepository
    {
        IQueryable<EnterpriseInfoListViewModel> GetAllEnterpriseList();
    }
}
