using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteSach.Models;
using PagedList;

namespace websiteSach.Controllers
{
    public class SanPhamController : Controller
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
            var all_sanpham = (from s in data.SanPhams select s).OrderBy(m => m.masp);
            int pageSize = 6;
            int pageNum = page ?? 1;
            return View(all_sanpham.ToPagedList(pageNum, pageSize));
        }

       

        public ActionResult Detail(int id)
        {
            var D_sanpham = data.SanPhams.Where(m => m.masp == id).First();
            return View(D_sanpham);
        }
        public ActionResult Details(int id)
        {
            var D_sanpham = data.SanPhams.Where(m => m.masp == id).First();
            return View(D_sanpham);
        }
        public ActionResult Edit(int id)
        {
            var E_sach = data.SanPhams.First(m => m.masp == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sp = data.SanPhams.First(m => m.masp == id);
            var E_tensp = collection["tensp"];
            var E_mota = collection["mota"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_sp.masp = id;
            if (string.IsNullOrEmpty(E_tensp))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sp.tensp = E_tensp;
                E_sp.mota = E_mota;
                E_sp.hinh = E_hinh;
                E_sp.giaban = E_giaban;
                E_sp.ngaycapnhat = E_ngaycapnhat;
                E_sp.soluongton = E_soluongton;
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