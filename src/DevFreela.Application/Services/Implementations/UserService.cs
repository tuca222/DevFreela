using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewUserCreateModel inputModel)
        {
            User user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);

            return user.Id;
        }

        public UserViewModel GetById(int id)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return null;

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
