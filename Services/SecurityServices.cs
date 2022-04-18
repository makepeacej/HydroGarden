using HydroGarden.Models;

namespace HydroGarden.Services
{
    public class SecurityServices
    {
        List<UserModel> knownUsers = new List<UserModel>();

        public SecurityServices()
        {
            knownUsers.Add(new UserModel { Id = 0, Username = "jon", Password = "jonpass" });
            knownUsers.Add(new UserModel { Id = 1, Username = "Marissa", Password = "marpass" });
            knownUsers.Add(new UserModel { Id = 2, Username = "jeff", Password = "jeffpass" });

        }

        public bool IsValid(UserModel user)
        {
            return knownUsers.Any(x => x.Username == user.Username && x.Password == user.Password);
        }
    }
}
