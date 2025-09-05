using kita.Data;
using kita.Model;

namespace kita.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public void addUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public void deleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null) return;

        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public User? getUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }
    
    public User? getUserById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }
    public List<User> getAllUsers()
    {
        return _context.Users.ToList();
    }

    public void updateUser(User user)
    {
        var existing = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (existing is null) return;
        existing.Username = user.Username;
        existing.Email = user.Email;
        existing.FullName = user.FullName;
        existing.Password = user.Password;
        existing.Role = user.Role;
        _context.SaveChanges();
    }

    public User? isAccountValid(string email, string password)
    {
        User? existUser = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        return existUser;
    }

}