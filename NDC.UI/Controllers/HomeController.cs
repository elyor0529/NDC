using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NDC.Common.ViewModels;
using NDC.UI.SoapServiceReference;

namespace NDC.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPersonService _client;

        public HomeController(IPersonService client)
        {
            _client = client;
        }

        public ActionResult Index()
        {
            var model = new SearchModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SearchModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _client.Search(User.Identity.Name, new SearchModel
                    {
                        MaxAge = model.MaxAge ?? 0,
                        MaxHeigth = model.MaxHeigth,
                        MaxWeight = model.MaxWeight,
                        MinAge = model.MinAge,
                        MinHeigth = model.MinHeigth,
                        MinWeight = model.MinWeight,
                        Names = model.Names,
                        Nationality = model.Nationality,
                        Gender = model.Gender
                    });

                    if (result > 0)
                    {
                        ViewBag.Success = string.Format("Found {0} result(s) of your query,please check your email.", result);
                    }
                    else
                    {
                        ViewBag.Warning = "Not found result(s)";
                    }
                }
                catch (Exception exp)
                {
                    ViewBag.Danger = exp.Message.Replace(Environment.NewLine, "<br/>");
                }
            }

            return View(model);
        }
    }
}