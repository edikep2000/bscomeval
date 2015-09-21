using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TestApp.Service;

namespace TestApp.Controllers
{
    public class FilesController : Controller
    {
        private readonly EntityService _entityService;
        private readonly FileService _fileService;

        public FilesController(EntityService entityService, FileService fileService)
        {
            _entityService = entityService;
            _fileService = fileService;
        }

        public ActionResult List(string emailAddress, string transId, int? page)
        {
            if (String.IsNullOrEmpty(emailAddress) || String.IsNullOrEmpty(transId))
            {
                ViewBag.Message = "Email Address and Transaction Id is required!";
                return View();
            }
            else
            {
                var pageNumber = page ?? 1;
                const int pageSize = 15;
                var entity =
                    _entityService.Find(i => i.EmailAddress == emailAddress && i.UniqueId == transId).FirstOrDefault();
                if (entity == null)
                {
                    ViewBag.Message = "We could not find any records to the specified username and Transaction Id";
                    return View();
                }
                else
                {
                    var files = entity.Files.ToPagedList(pageNumber, pageSize);
                    return View(files);
                }
           
            
         }
        }



        public FileResult DownloadFile(long id)
        {
            var file = _fileService.GetSingle(id);

            var filePath = Server.MapPath(file.FilePath);
            return File(filePath,  MimeMapping.GetMimeMapping(Path.GetFileName(filePath)));
           
        }
    }
}