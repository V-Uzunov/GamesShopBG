namespace GamesShopBG.Web.Areas.Admin.Controllers
{
    using GamesShopBG.Data;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Web.Areas.Admin.Models;
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

            return this.View(users);
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