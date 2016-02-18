namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        void Add(User model);
    }
}
