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
    public class MemberRepository : IMemberRepository
    {
        private readonly DIMSDbContext _dbContext = null;
        public MemberRepository(DIMSDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<Member>> GetAllMemberAsync()
        {
            return await _dbContext.Members
                                   .Include(x=>x.Title)
                                   .Include(x=>x.Gender)
                                   .Include(x=>x.Enterprise)
                                   .Include(x=>x.MemberType)
                                   .Include(x=>x.Disability)
                                   .ToListAsync();
        }
        public async Task<int> AddNewMemberAsync(Member member)
        {
            var newMember = new Member()
            {
                FirstName = member.FirstName,
                MiddleName = member.MiddleName,
                LastName = member.LastName,
                IsDisable = member.IsDisable,
                TitleId = member.TitleId,
                GenderId= member.GenderId,
                EnterpriseId = member.EnterpriseId,
                MemberTypeId = member.MemberTypeId,
                DisabilityId = member.DisabilityId,
                Role = member.Role,
                DateOfJoing = member.DateOfJoing,
                BirthDate = member.BirthDate,
                Description = member.Description,
                IsFounder = member.IsFounder,
            };
            await _dbContext.Members.AddAsync(newMember);
            await _dbContext.SaveChangesAsync();
            return newMember.Id;
        }

        public async Task<int> CheckMemberDuplication(Member member)
        {
            List<Member> _members  = await (from m in _dbContext.Members
                                       //where m.PhoneNumber == member.PhoneNumber || m.HouseNumber== enterpriseAddress.HouseNumber
                                       select m
                                       ).ToListAsync();
            return _members.Count();

        }
    }
}
