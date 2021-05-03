using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStorage.Storage;

namespace WebStorage.Controllers
{
    public class HomeController : Controller
    {
        IStorage storage=new StorageAzure();

        
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

        public ActionResult Todos()
        {
            
            var files = storage.AllFiles();
            return View(files);
        }

        public ActionResult Subir()
        {
            return View();
        }
        

            [HttpPost]
        public ActionResult Subir(HttpPostedFileBase file) {

            var fil = file.InputStream;
            storage.UploadFile(file.FileName, fil);
            ViewBag.Mensaje = "se subio correctamente";
            return View();
        }
    }
}