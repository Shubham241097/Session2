using Session2.Models;

namespace Session2.Services
{
    public interface IUserService
    {
        public bool AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int Id);
        public User GetUser(int Id);
        public List<User> GetAllUsers();
    }
}
