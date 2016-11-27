using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeJS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            POSDBEntities1 db = new POSDBEntities1();
            var supplier =    db.TBLSUPPLIERs.ToList();
            var product = db.TBLPRODUCTs.ToList();
             // hi i am sabid 
            // this is for testing github
           // ssfgsd 
            return View();
        }
    }
}