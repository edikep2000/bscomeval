using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.OpenAccess;
using TestApp.Service;

namespace TestApp.Controllers
{
    public class HomeController : BaseController
    {

        private readonly FileService _fileService;
        private readonly EntityService _entityService;
        public HomeController(OpenAccessContext context, FileService fileService, EntityService entityService) : base(context)
        {
            _fileService = fileService;
            _entityService = entityService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}