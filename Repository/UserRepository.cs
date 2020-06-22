using Contracts;
using Entities;
using Entities.Models;
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

        public async Task<User> GetUserByNameAndPasswordAsync(string userName, string userPassword)
        {
            return await FindByCondition(user => user.UserName.Equals(userName) && user.UserPassword.Equals(userPassword))
                .FirstOrDefaultAsync();
        }
    }
}
