namespace GamesShopBG.Web.Areas.Admin.Controllers
{
    using GamesShopBG.Data;
<<<<<<< HEAD
    using GamesShopBG.Data.Models;
=======
>>>>>>> 7ddd3470b491433b80f2f7c7338892e6de3fa740
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Web.Areas.Admin.Models;
    using GamesShopBG.Web.Infrastructure.Extensions;
    using Microsoft.AspNet.Identity;
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
<<<<<<< HEAD
            var roles = this.users
                .GetAllRoles()
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
        [ValidateAntiForgeryToken]
        public ActionResult AddToRole(AddUserToRoleFormModel model)
        {
            var user = this.userManager.FindById(model.UserId);
            var roles = this.users.GetRoles(model.Role);

            var userExists = user != null;
            var roleExists = roles != null;
            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            this.userManager.AddToRole(user.Id, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to the {model.Role} role.");
            return RedirectToAction(nameof(Index));
=======

            return this.View(users);
>>>>>>> 7ddd3470b491433b80f2f7c7338892e6de3fa740
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