using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcFileUploader;
using Telerik.OpenAccess;
using TestApp.Helpers;
using TestApp.Mailers;
using TestApp.Models;
using TestApp.Service;

namespace TestApp.Controllers
{
    public class MultiFileUploadController : BaseController
    {

        private readonly FileService _fileService;
        private readonly EntityService _entityService;
        private readonly IFileMailer _fileMailer;

        // GET: MultiFileUpload
        public MultiFileUploadController(OpenAccessContext context, FileService fileService, EntityService entityService, IFileMailer fileMailer) : base(context)
        {
            _fileService = fileService;
            _entityService = entityService;
            _fileMailer = fileMailer;
        }

        public ActionResult UploadFile( string fullName, string emailAddress) 
        {

            if (fullName.IsNullOrWhiteSpace() || emailAddress.IsNullOrWhiteSpace())
            {
                return Json(new {message = "You cannot upload files without specifying a name and or an email address", status = false});
            }

            var person =
                _entityService.GetAll().FirstOrDefault(j => j.EmailAddress == emailAddress.Trim());
            if (person == null)
            {
                var entity = new Entity()
                {
                    DateCreated = DateTime.Now.ToString(),
                    EmailAddress = emailAddress.Trim(),
                    Name = fullName,
                    UniqueId = CodeGenerator.GetUniqueKey(5)
                };
                _entityService.Add(entity);
                this.CurrentContext.SaveChanges();
                this.CurrentContext = new EntitiesModel();
                person = entity;
            }
            int fileCount = Request.Files.Count;
            List<HttpPostedFileBase> fileList = new List<HttpPostedFileBase>();
            for (var i = 0; i < Request.Files.Count; i++)
            {
                var file = new Files {UserId = person.Id, FileName = Request.Files[i].FileName};
                file.FileTitle = Path.GetFileNameWithoutExtension(file.FileName);
                file.FileId = Guid.NewGuid().ToString();
                var st = FileSaver.StoreFile(x =>
                {
                    x.File = Request.Files[i];
                    x.DeleteUrl = Url.Action("DeleteFile", new { entityId = 1 });
                    x.StorageDirectory = Server.MapPath("~/Content/uploads");
                    x.UrlPrefix = "~/Content/uploads";// this is used to generate the relative url of the file
                    file.FilePath = "~/Content/Uploads" + file.FileName;
                    file.FileSize = Request.Files[i].ContentLength.ToString("N0");
                    file.DateUploaded = DateTime.Now.ToUniversalTime().ToLongDateString();
                    _fileService.Add(file);
                    x.FileName = Request.Files[i].FileName;
                    fileList.Add(Request.Files[i]);
                    x.ThrowExceptions = true;
                });
            }
            _fileMailer.FileUploaded(emailAddress, fileList, person.UniqueId).Send();
            string message = String.Format("Files uploaded successfully for {0} with Transaction Number: {1}",  person.EmailAddress, person.UniqueId);
            return Json(new {status = true, message});
        }
        //here i am receving the extra info injected
        [HttpPost] // should accept only post
        public ActionResult DeleteFile(int? entityId, string fileUrl)
        {
            var filePath = Server.MapPath("~" + fileUrl);

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            var viewresult = Json(new { error = String.Empty });
            //for IE8 which does not accept application/json
            if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                viewresult.ContentType = "text/plain";

            return viewresult; // trigger success
        }


        public ActionResult DownloadFile(string fileUrl, string mimetype)
        {
            var filePath = Server.MapPath("~" + fileUrl);

            if (System.IO.File.Exists(filePath))
                return File(filePath, mimetype);
            else
            {
                return new HttpNotFoundResult("File not found");
            }
        }


    }
}