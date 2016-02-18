namespace RecruitYourself.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using RecruitYourself.Data.Common.Contracts;
    using RecruitYourself.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User, string> users;

        public UsersService(IDbRepository<User, string> users)
        {
            this.users = users;
        }

        public void Add(User model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
