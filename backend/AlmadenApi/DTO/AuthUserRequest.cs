using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmadenApi.DTO
{
    public record AuthUserRequest
    (
        string userName,
        string password
    );
}