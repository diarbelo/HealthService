using Contracts;
using Entities;
using Entities.Models;
using JWTService.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<User> GetUserByNameAndPasswordAsync(string userMail, string userPassword)
        {
            //var passwordHash = Encrypt.GetSHA256(userPassword);
            return await FindByCondition(user => user.UserMail.Equals(userMail) && user.UserPassword.Equals(Encrypt.GetSHA256(userPassword)))
                .FirstOrDefaultAsync();
        }
    }
}
