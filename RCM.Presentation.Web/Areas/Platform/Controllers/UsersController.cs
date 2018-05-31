using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCM.CrossCutting.Identity.Models;
using RCM.CrossCutting.Identity.ViewModels;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Presentation.Web.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RCM.Presentation.Web.Areas.Platform.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Platform")]
    public class UsersController : BaseController
    {
        private readonly RCMUserManager _rcmUserManager;
        private readonly RCMSignInManager _rcmSignInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(RCMUserManager rcmUserManager, RCMSignInManager rcmSignInManager, IHttpContextAccessor httpContextAccessor, IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _rcmUserManager = rcmUserManager;
            _rcmSignInManager = rcmSignInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _rcmUserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var users = new List<UserViewModel>();

            foreach (var user in _rcmUserManager.Users)
            {
                if (user == currentUser)
                    continue;

                users.Add(new UserViewModel()
                {
                    User = user,
                    Roles = (List<string>)await _rcmUserManager.GetRolesAsync(user)
                });
            }

            return View(users);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _rcmUserManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var viewModel = new UserViewModel
            {
                User = user,
                Roles = (List<string>)await _rcmUserManager.GetRolesAsync(user)
            };

            return View(viewModel);
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> AddToRole(int id, string role)
        {
            var user = await _rcmUserManager.FindByIdAsync(id.ToString());

            if (user == null)
                return NotFound();
            else
            {
                var result = await _rcmUserManager.AddToRoleAsync(user, role);

                if (result.Succeeded)
                    NotifyCommandResultSuccess();
                else
                    return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Policy = "ActiveUser")]
        public async Task<IActionResult> RemoveFromRole(int id, string role)
        {
            var user = await _rcmUserManager.FindByIdAsync(id.ToString());

            if (user == null || role == "Admin")
                return NotFound();
            else
            {
                var result = await _rcmUserManager.RemoveFromRoleAsync(user, role);

                if (result.Succeeded)
                    NotifyCommandResultSuccess();
                else
                    return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}