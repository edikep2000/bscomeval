using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Hosting;
using Microsoft.Ajax.Utilities;
using Mvc.Mailer;
using TestApp.Models;
using WebGrease.Css.Extensions;

namespace TestApp.Mailers
{ 
    public class FileMailer : MailerBase, IFileMailer 	
	{
		public FileMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage FileUploaded(string recipient, IEnumerable<HttpPostedFileBase> files, string transactionNumber )
		{
            
			var mail = Populate(x =>
			{
				x.Subject = String.Format("Files uploaded successfully. Your Transaction Number is : {0}", transactionNumber);
				x.ViewName = "FileUploaded";
				x.To.Add(recipient);
                x.CC.Add("edikep2000@yahoo.com");
                x.From = new MailAddress("notifications@bscomeval.com");
			});

		    if (files.Any())
		    {
                foreach (var filese in files)
                {
                  mail.Attachments.Add(new Attachment(filese.InputStream, filese.FileName, filese.ContentType.ToString()));
                }
		    }
		    return mail;
		}
 	}
}