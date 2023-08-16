using DIMS.DIMSDataContext;
using DIMS.IRepositories;
using DIMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DIMSDbContext _dbContext;
        public ReportRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<EnterpriseInfoListViewModel> GetAllEnterpriseList()
        {
            var EnterpriseListInfo = (from m in _dbContext.Enterprises
                                      join E in _dbContext.EnterpriseAddressInfos on m.Id equals E.EnterpriseId
                                      select new
                                      {
                                          enterPriseName = m.EnterpriseName, 
                                          regionName = E.Region.RegionName,
                                          zoneName = E.Zone.ZoneName,
                                          woreda = E.Woreda.WoredaName,
                                          city =E.City.CityName,
                                          kebele = E.KebeleName,
                                          houseNumber= E.HouseNumber,
                                          phoneNumber =E.PhoneNumber,
                                          foundedYear= E.Enterprise.FoundedYear,
                                          branchName = m.BranchItem.Branch.BranchName,
                                          branchItem = m.BranchItem.BranchItemName,
                                          enterpriseLevelName = m.EnterpriseLevel.EnterpriseLevelName,
                                          groupTypeName = m.GroupType.GroupTypeName,
                                          tinNumber = m.TINNumber,
                                          promotionLevelName = m.PromotionLevel.PromotionLeveName,
                                          initialCapital = m.InitialCapital,
                                          sourceCapital= m.CapitalSource.CapitalSourceName,
                                          enterpriseId = m.EnterUserLocationId,
                                          fMale= m.MaleFouder,
                                          fFemale= m.FemaleFounder,
                                          fMaleYear = m.MaleFouderYear,
                                          fFemaleYear = m.FemaleFounderYear,
                                          fMaleCollege = m.MaleCollege,
                                          fFemaleCollege = m.FemaleCollege,
                                          fMaleUniversity = m.MaleUniversity,
                                          fFemaleUniversity = m.FemaleUniversity,
                                      });
            List<EnterpriseInfoListViewModel> enterpriseInfoLists = new List<EnterpriseInfoListViewModel>();
            foreach(var item in EnterpriseListInfo)
            {
                enterpriseInfoLists.Add(new EnterpriseInfoListViewModel
                {
                    EnterpriseName = item.enterPriseName,
                    RegionName = item.regionName,
                    ZoneName = item.zoneName,
                    WoredaName = item.woreda,
                    CityName = item.city,
                    KebeleName = item.kebele,
                    HouseNumber = item.houseNumber,
                    PhoneNumber =item.phoneNumber,
                    EstableshedYear = item.foundedYear,
                    BranchName= item.branchName,
                    BranchItemName= item.branchItem,
                    EnterpriseLevelName= item.enterpriseLevelName,
                    GroupTypeName= item.groupTypeName,
                    TINNumber= item.tinNumber,
                    PromotionLevelName= item.promotionLevelName,
                    InitialCapital = item.initialCapital,
                    SourceCapitalName =item.sourceCapital,
                    EnterUserLocationId = item.enterpriseId,
                    MaleFouder= item.fMale,
                    FemaleFounder = item.fFemale,
                    MaleFouderYear = item.fMaleYear,
                    FemaleFounderYear = item.fFemaleYear,
                    MaleCollege = item.fMaleCollege,
                    FemaleCollege = item.fFemaleCollege,
                    MaleUniversity = item.fMaleUniversity,
                    FemaleUniversity = item.fFemaleUniversity,
                });
            }
           return  enterpriseInfoLists.AsQueryable();
        }
    }
}
