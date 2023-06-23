using Session2.Models;

namespace Session2.Repository
{
    public interface IUserRepository
    {
        public bool AddUser(User user);
        public User GetUserById(int userId);
        public bool UpdateUser(User model);
        public bool DeleteUser(int userId);
        public List<User> GetAllUsers();
    }
}
