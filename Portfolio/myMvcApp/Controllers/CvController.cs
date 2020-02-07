using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using myMvcApp.Models;

namespace myMvcApp.Controllers
{
    public class CvController : Controller
    {
        // POST: /Cv/DownlaodCV
        [HttpGet]
        public FileResult DownloadCv()
        {
            return File(Server.MapPath("~/Content/myCV/GaryMcHugh_cv.pdf"), "application/pdf", "GaryMcHugh_cv.pdf");
        }

    }
}