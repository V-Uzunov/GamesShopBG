namespace GamesShopBG.Web.Areas.Admin.Controllers
{
    using GamesShopBG.Data;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Web.Areas.Admin.Models;
    using GamesShopBG.Web.Infrastructure.Extensions;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Web.Mvc;

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;

        public UsersController(IAdminUserService users,
            GamesShopBGDbContext dbContext) : base(dbContext)
        {
            this.users = users;
        }


        //GET: /Admin/Users/
        public ActionResult Index()
        {
            var users = this.users.All();
            var roles = this.users
                .GetAllRoles()
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id
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
        [ValidateAntiForgeryToken]
        public ActionResult AddToRole(AddUserToRoleFormModel model)
        {
            var user = this.userManager.FindById(model.UserId);
            var role = this.users.GetRoles(model.Role);

            var userExists = user != null;
            var roleExists = role != null;
            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            this.userManager.AddToRole(user.Id, role.Name);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to the {role.Name} role.");
            return RedirectToAction(nameof(Index));
        }
        //GET: /Admin/Users/DeleteUser/{id}
        [Route("/{userId}")]
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
                Email = findUser.Email
            });
        }

        //POST: /Admin/Users/DeleteUser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            var findUser = this.userManager.FindById(id);

            if (findUser == null)
            {
                return HttpNotFound();
            }

            this.users.Delete(findUser.Id);

            TempData.AddSuccessMessage($"User {findUser.UserName} successfully deleted ");

            return RedirectToAction(nameof(Index));
        }
    }
}