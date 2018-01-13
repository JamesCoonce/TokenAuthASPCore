using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenAuthASPCore.Models;

namespace TokenAuthASPCore.Areas.v1.Models.UserViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ProfileViewModel()
        {

        }

        public ProfileViewModel(ApplicationUser user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        public static IEnumerable<ProfileViewModel> GetUserProfiles(IEnumerable<ApplicationUser> users)
        {
            var profiles = new List<ProfileViewModel> { };
            foreach (ApplicationUser user in users)
            {
                profiles.Add(new ProfileViewModel(user));
            }

            return profiles;
        }
    }
}
