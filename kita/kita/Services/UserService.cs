using kita.Model;
using kita.Repository;
    
namespace kita.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User? isAccountValid(string username, string password)
    {
        var user = _userRepository.isAccountValid(username, password);
        return user;
    }

    public bool addUser(User user)
    {
        var existingUser = _userRepository.getUserByEmail(user.Email);
        if (existingUser != null)
        {
            return false; 
        }
        _userRepository.addUser(user);
        return true;
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.getAllUsers();
    }
    // public User? getUser(string email,string password)
    // {
    //     return _userRepository.getUserByEmail(username);
    // }

}