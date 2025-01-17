using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Data.Repository;
using AlmadenApi.Model;

namespace AlmadenApi.Data.Interface
{
    public interface ILastPassCardRepository:IRepositoryBase<LastPassCard>
    {
        IEnumerable<LastPassCard> GetByUserId(int userId);
        
    }
}