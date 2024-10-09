using System.Text.Json;
using MonsterCardGame.Server.Repository;
using MonsterCardGame.Server.HttpModel;
using MonsterCardGame.Models.User;
namespace MonsterCardGame.Server.Endpoints
{
    public class UserEndpoint
    {
        private UserRepository _userRepository;
        public UserEndpoint(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void HandleRequest(Request request, Response response)
        {
            string jsonText = request.Body;
            var user = JsonSerializer.Deserialize<User>(jsonText);
            if (user == null || string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                response.StatusCode = 400;
                response.ReasonPhrase = "Bad Request";
                response.Body = "Invalid user data. Username and password are required.";
            }
            else if (request.Method == "POST" && request.Path == "/users")
            {
                RegisterUser(request, response, user);
            }
            else if (request.Method == "POST" && request.Path == "/sessions")
            {
                LoginUser(request, response, user);
            }
            else
            {
                response.StatusCode = 404;
                response.ReasonPhrase = "Not Found";
                response.Body = "The requested resource was not found.";
            }
        }

        private void RegisterUser(Request request, Response response, User user)
        {
            if (_userRepository.DoesUserExist(user.Username))
            {
                response.StatusCode = 409;
                response.ReasonPhrase = "Already exists";
                response.Body = "HTTP " + response.StatusCode + " - User already exists\n";
            }
            else
            {
                _userRepository.AddUser(user);
                response.StatusCode = 201;
                response.ReasonPhrase = "Created";
                response.Body = "HTTP " + response.StatusCode + "\n";
            }
        }

        private void LoginUser(Request request, Response response, User user)
        {
            if (!_userRepository.CheckUserCredentials(user.Username, user.Password) && _userRepository.DoesUserExist(user.Username))
            {
                response.StatusCode = 401;
                response.ReasonPhrase = "Unauthorized";
                response.Body = "HTTP " + response.StatusCode + " - Login failed\n";
            }
            else
            {
                user.AuthenticationToken = Guid.NewGuid().ToString();
                response.StatusCode = 200;
                response.ReasonPhrase = "OK";
                response.Body = "HTTP " + response.StatusCode + " " + user.AuthenticationToken + "\n";
            }
        }
    }
}
