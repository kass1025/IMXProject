using DIMS.DIMSDataContext;
using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Repositories
{
    public class GroupTypeRepository : IGroupTypeRepository
    {
        private readonly DIMSDbContext _dbContext;
        public GroupTypeRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewGroupTypeAsync(GroupType groupType)
        {
            var NewGroupType = new GroupType()
            {
                GroupTypeName = groupType.GroupTypeName,
                Description = groupType.Description,
            };
            await _dbContext.GroupTypes.AddAsync(NewGroupType);
            await _dbContext.SaveChangesAsync();
            return NewGroupType.Id;
        }

        public async Task<List<GroupType>> GetAllGroupTypeAsync()
        {
            return await _dbContext.GroupTypes.ToListAsync();
        }

        public async Task<int> CheckGroupTypeDuplication(GroupType groupType)
        {
            List<GroupType> _groupTypes = await (from m in _dbContext.GroupTypes
                                                                where m.GroupTypeName == groupType.GroupTypeName
                                                                select m).ToListAsync();
            return _groupTypes.Count;
        }
    }
}
