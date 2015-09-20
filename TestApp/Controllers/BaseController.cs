using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.OpenAccess;

namespace TestApp.Controllers
{
    public class BaseController : Controller
    {
        private  OpenAccessContext _context;

        public BaseController(OpenAccessContext context)
        {
            _context = context;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (!filterContext.IsChildAction && _context != null && filterContext.Exception == null)
                _context.SaveChanges();
        }

        protected OpenAccessContext CurrentContext
        {
            get
            {
                return _context;
            }
            set { _context = value; }
        }
    }
}