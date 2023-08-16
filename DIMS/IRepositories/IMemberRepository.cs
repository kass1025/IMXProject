using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface IMemberRepository
    {
        Task<int> AddNewMemberAsync(Member member); 
        Task<IEnumerable<Member>> GetAllMemberAsync();
        Task<int> CheckMemberDuplication(Member member); 


    }
}
