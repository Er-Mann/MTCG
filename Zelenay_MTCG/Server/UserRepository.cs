using System.Collections.Concurrent;
using MonsterCardGame.Models.User;

namespace MonsterCardGame.Server.Repository
{
    public class UserRepository
    {
        private readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();  //daweil so dann datenbank

        public bool AddUser(User user)
        {
            if (DoesUserExist(user.Username))
            {
                return false;
            }
            return _users.TryAdd(user.Username, user);
        }

        public bool DoesUserExist(string username)
        {
            return _users.ContainsKey(username);
        }

        public bool CheckUserCredentials(string username, string password)
        {
            if (_users.TryGetValue(username, out var user))
            {
                return user.Password == password;
            }
            return false;
        }

        public User GetUserByToken(string token)
        {
            return _users.Values.FirstOrDefault(u => u.AuthenticationToken == token);
        }
    }
}
