using Session2.Models;
using Session2.Repository;

namespace Session2.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public bool AddUser(User user)
        {
            var userExists = _userRepository.GetUserById(user.Id);
            if (userExists == null)
            {
                return _userRepository.AddUser(user);
            }
            else 
            { 
                return false; 
            }
            
        }

        public bool DeleteUser(int Id)
        {
            return _userRepository.DeleteUser(Id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUser(int Id)
        {
            return _userRepository.GetUserById(Id);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
