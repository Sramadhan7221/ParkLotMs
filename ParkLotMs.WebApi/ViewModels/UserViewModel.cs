using ParkLotMs.Core.Entities;

namespace ParkLotMs.WebApi.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set;}
        public string Password { get; set;}
    }

    public class UserRegisterViewModel: UserViewModel
    {
        public string Role { get; set; }
    }
}
