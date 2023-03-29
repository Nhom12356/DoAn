using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteSach.Models;
using PagedList;

namespace websiteSach.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: SanPham
        MyDataDataContext data = new MyDataDataContext();

        public ActionResult head()
        {
            return View();
        }
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_sanpham = (from s in data.LoaiSps select s).OrderBy(m => m.maloaisp);
            int pageSize = 6;
            int pageNum = page ?? 1;
            return View(all_sanpham.ToPagedList(pageNum, pageSize));
        }



        public ActionResult Detail(int id)
        {
            var D_sanpham = data.LoaiSps.Where(m => m.maloaisp == id).First();
            return View(D_sanpham);
        }
        public ActionResult Details(int id)
        {
            var D_sanpham = data.LoaiSps.Where(m => m.maloaisp == id).First();
            return View(D_sanpham);
        }
        public ActionResult Edit(int id)
        {
            var E_sach = data.LoaiSps.First(m => m.maloaisp == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sp = data.LoaiSps.First(m => m.maloaisp == id);
            var E_tenlsp = collection["tenlsp"];
            
            if (string.IsNullOrEmpty(E_tenlsp))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sp.tenloaisp = E_tenlsp;
               
                UpdateModel(E_sp);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }



    }
}