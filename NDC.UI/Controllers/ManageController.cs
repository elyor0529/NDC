using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NDC.UI.ViewModels;

namespace NDC.UI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
  
        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //
        // GET: /Manage/Index
        public ActionResult Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess
                    ? "Your password has been changed."
                    : message == ManageMessageId.SetPasswordSuccess
                        ? "Your password has been set."
                        : message == ManageMessageId.Error
                            ? "An error has occurred."
                            : "";

            ViewBag.HasPassword = HasPassword();

            return View();
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _userManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword,model.NewPassword);

            if (result.Succeeded)
            {
                var user = _userManager.FindById(User.Identity.GetUserId());

                if (user != null)
                    _signInManager.SignIn(user, false, false);

                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userManager?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error);
        }

        private bool HasPassword()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());

            return user?.PasswordHash != null;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            Error
        }

        #endregion
    }
}