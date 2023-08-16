using DIMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.IRepositories
{
    public interface ITitleRepository
    {
        Task<int> AddNewTitleAsync(Title title);
        Task<List<Title>> GetAllTitleAsync();
        Task<int> CheckTitleDuplication(Title title); 
    }
}
