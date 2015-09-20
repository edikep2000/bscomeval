using System.Collections.Generic;
using System.Web;
using Mvc.Mailer;
using TestApp.Models;

namespace TestApp.Mailers
{ 
    public interface IFileMailer
    {
			MvcMailMessage FileUploaded(string recipient, IEnumerable<HttpPostedFileBase> files, string transactionNumber);
	}
}