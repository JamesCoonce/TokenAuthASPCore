using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TokenAuthASPCore.Areas.v1.Models.UserViewModels;
using TokenAuthASPCore.Data;
using TokenAuthASPCore.Models;

namespace TokenAuthASPCore.Areas.v1.Controllers
{
    [Area("v1")]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userMgr)
        {
            _context = context;
            _userManager = userMgr;
        }
        [HttpGet]
        [Route("/users")]
        public IEnumerable<ProfileViewModel> GetUsers()
        {
            var users = _userManager.Users;
            var profiles = ProfileViewModel.GetUserProfiles(_userManager.Users);
            return profiles;
        }

        [HttpGet]
        [Route("/userclaims")]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

    }
}