using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteSach.Models;

namespace websiteSach.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult head()
        {
            return View();
        }

        public ActionResult Index1()
        {
            var all_sanpham = from ss in data.SanPhams select ss;
            return View(all_sanpham);
        }

    }
}