using websiteSach.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websiteSach.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        MyDataDataContext data = new MyDataDataContext();
        [HttpGet]
        /*public ActionResult KQTimKiem(string keys)
        {
            var lstSP = data.SanPhams.Where(n => n.tensp.Contains(keys));
            return View(lstSP.OrderBy(n => n.giaban));
        }*/
        public ActionResult KQTimKiem(int? page, string search)
        {
            if (page == null) page = 1;
            var lstSP = data.SanPhams.Where(n => n.tensp.Contains(search));
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(lstSP.ToPagedList(pageNum, pageSize));
        }
    }
}