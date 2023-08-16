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
    public class MemberTypeRepository : IMemberTypeRepository
    {
        private readonly DIMSDbContext _dbContext;
        public MemberTypeRepository(DIMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewMemberTypeAsync(MemberType memberType)
        {
            var NewMemberType = new MemberType()
            {
                TypeName = memberType.TypeName,
                Description = memberType.Description,
            };
            await _dbContext.MemberTypes.AddAsync(NewMemberType);
            await _dbContext.SaveChangesAsync();
            return NewMemberType.Id;
        }

        public async Task<List<MemberType>> GetAllMemberTypeAsync()
        {
            return await _dbContext.MemberTypes.ToListAsync();
        }

        public async Task<int> CheckMemberTypeDuplication(MemberType memberType)
        {
            List<MemberType> _memberTypes = await (from m in _dbContext.MemberTypes
                                                 where m.TypeName == memberType.TypeName
                                                 select m).ToListAsync();
            return _memberTypes.Count;
        }
    }
}
