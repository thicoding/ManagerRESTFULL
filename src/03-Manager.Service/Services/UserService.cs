namespace _02_Manager.Services
{
    using _02_Manager.Domain.Entities;
    using _04_Manager.Data.Repository;
    using System.Collections.Generic;

    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public User AddUser(User user)
        {
           
            return _userRepository.Add(user);
        }

        
        public User GetUserById(int id)
        {
            return _userRepository.GetId(id);
        }

        
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        
        public void UpdateUser(User user)
        {
            
            _userRepository.Update(user);
        }

        
        public void RemoveUser(int id)
        {
            _userRepository.Remover(id);
        }
    }
}
