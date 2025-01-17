using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Data.Interface;
using AlmadenApi.Model;

namespace AlmadenApi.Data.Repository
{
    public class LastPassCardRepository : RepositoryBase<LastPassCard>, ILastPassCardRepository
    {
        public LastPassCardRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<LastPassCard> GetByUserId(int userId)
        {
            return _context.LastPassCards
       
                .Where(card => card.Pk_UserId == userId)
                .ToList();
        }
    }
}