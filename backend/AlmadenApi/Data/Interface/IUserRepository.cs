using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Data.Repository;
using AlmadenApi.DTO;
using AlmadenApi.Model;

namespace AlmadenApi.Data.Interface
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        Task<User> AuthenticateAsync(AuthUserRequest request);
     
    }
}