using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Data.Interface;
using AlmadenApi.Model;

namespace AlmadenApi.Data.Repository
{
    public class UserRepository:RepositoryBase<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        

        
    }
}