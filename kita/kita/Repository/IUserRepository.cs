using kita.Model;

namespace kita.Repository;

public interface IUserRepository
{
    void addUser(User user);
    void deleteUser(int id);
    User? getUserByEmail(string email);
    User? getUserById(int id);
    List<User> getAllUsers();
    void updateUser(User user);
    
    User? isAccountValid(string Email, string password);
    
    
}