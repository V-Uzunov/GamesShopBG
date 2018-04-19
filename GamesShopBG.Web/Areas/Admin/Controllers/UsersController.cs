namespace GamesShopBG.Web.Areas.Admin.Controllers
{
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Web.Areas.Admin.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using System.Web.Mvc;

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(IAdminUserService users,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.users = users;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        //GET: /Admin/Users/
        public ActionResult Index()
        {
            var users = this.users.All();
            var roles = this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();

            return View(new UsersListingViewModel
            {
                Users = users,
                Roles = roles
            });
        }

        //POST: /Admin/Users/AddToRole
        [HttpPost]
        public ActionResult AddToRole(AddUserToRoleFormModel model)
        {
            var user = this.userManager.FindById(model.UserId);
            var roleExists = this.roleManager.RoleExists(model.Role);

            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            this.userManager.AddToRole(user.Id, model.Role);

            //TempData.AddSuccessMessage($"User {user.UserName} successfully added to the {model.Role} role.");
            return RedirectToAction(nameof(Index));
        }

        //GET: /Admin/Users/DeleteUser/{id}
        public ActionResult DeleteUser(string userId)
        {
            var findUser = this.userManager.FindById(userId);

            if (findUser == null)
            {
                return HttpNotFound();
            }

            return View(new UserDeleteForm
            {
                Id = findUser.Id,
                Name = findUser.Name,
                Username = findUser.UserName,
                Birthdate = findUser.Birthdate,
                Email = findUser.Email
            });
        }

        //POST: /Admin/Users/DeleteUser/{id}
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var findUser = this.userManager.FindById(id);

            if (findUser == null)
            {
                return HttpNotFound();
            }

            this.users.Delete(findUser.Id);

            //TempData.AddSuccessMessage($"User {findUser.UserName} successfully deleted ");

            return RedirectToAction(nameof(Index));
        }
    }
}