using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Data.Interface;
using AlmadenApi.DTO;
using AlmadenApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AlmadenApi.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<User> AuthenticateAsync(AuthUserRequest request)
        {
            return await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == request.userName&& u.Password == request.password);  
        }



    }
}