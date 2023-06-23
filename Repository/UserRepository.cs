using Session2.AppDbContext;
using Session2.Models;

namespace Session2.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext) 
        {
            _userDbContext = userDbContext;
        }
        public bool AddUser(User user)
        {
            _userDbContext.Users.Add(user);
            return _userDbContext.SaveChanges() == 1 ? true : false;
        }

        public bool DeleteUser(int userId)
        {
            var user = _userDbContext.Users.Find(userId);
            if (user != null)
            {
                _userDbContext.Users.Remove(user);
                _userDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _userDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public bool UpdateUser(User model)
        {
            var user = _userDbContext.Users.FirstOrDefault(u => u.Id == model.Id);

            if (user == null) 
            { 
                return false; 
            }
            else
            {
                user.Name = model.Name;               
                user.Email = model.Email;
                user.Password = model.Password;
                user.Phone = model.Phone;
                user.Address = model.Address;
                _userDbContext.SaveChanges();

                return true;
            }
            
        }
    }
}
