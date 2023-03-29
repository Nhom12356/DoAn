using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websiteSach.Models;

namespace DOANWEB.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MyDataDataContext data = new MyDataDataContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListDonHang()
        {
            var all_sanpham = from ss in data.DonHangs select ss;
            return View(all_sanpham);
        }


        public ActionResult Listchitiet()
        {
            var all_chitietdonhang = from ss in data.ChiTietDonHangs select ss;
            return View(all_chitietdonhang);
        }


        public ActionResult Listsp()
        {
            var all_sanpham = from ss in data.SanPhams select ss;
            return View(all_sanpham);
        }

        public ActionResult Listloaihanghoa()
        {
            var all_loaisp = from ss in data.LoaiSps select ss;
            return View(all_loaisp);
        }
        public ActionResult Detail(int id)
        {
            var D_sanpham = data.SanPhams.Where(m => m.masp == id).First();
            return View(D_sanpham);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham sp)
        {
            var E_tensanpham = collection["tensp"];
            var E_mota = collection["mota"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_tensanpham))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sp.tensp = E_tensanpham.ToString();
                sp.mota = E_mota.ToString();
                sp.hinh = E_hinh.ToString();
                sp.giaban = E_giaban;
                sp.ngaycapnhat = E_ngaycapnhat;
                sp.soluongton = E_soluongton;

                data.SanPhams.InsertOnSubmit(sp);
                data.SubmitChanges();
                return RedirectToAction("Listsp");
            }
            return this.Create();
        }

        public ActionResult Edit(int id)
        {
            var E_sanpham = data.SanPhams.First(m => m.masp == id);
            return View(E_sanpham);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sanpham = data.SanPhams.First(m => m.masp == id);
            var E_tensanpham = collection["tensp"];
            var E_mota = collection["mota"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_sanpham.masp= id;
            if (string.IsNullOrEmpty(E_tensanpham))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sanpham.tensp= E_tensanpham;
                E_sanpham.mota = E_mota;
                E_sanpham.hinh = E_hinh;
                E_sanpham.giaban = E_giaban;
                E_sanpham.ngaycapnhat = E_ngaycapnhat;
                E_sanpham.soluongton = E_soluongton;

                UpdateModel(E_sanpham);
                data.SubmitChanges();
                return RedirectToAction("Listsp","Admin");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_sanpham = data.SanPhams.First(m => m.masp == id);
            return View(D_sanpham);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sanpham = data.SanPhams.Where(m => m.masp == id).First();
            data.SanPhams.DeleteOnSubmit(D_sanpham);
            data.SubmitChanges();
            return RedirectToAction("Listsp","Admin");
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

    
        public ActionResult CreateLoai()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLoai(FormCollection collection, LoaiSp lsp)
        {
            var E_tenloai = collection["tenloaisp"];

            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                lsp.tenloaisp = E_tenloai.ToString();
                data.LoaiSps.InsertOnSubmit(lsp);
                data.SubmitChanges();
                return RedirectToAction("Listloaihanghoa", "Admin");
            }
            return this.CreateLoai();
        }

        public ActionResult EditLoai(int id)
        {
            var E_lsanpham = data.LoaiSps.First(m => m.maloaisp == id);
            return View(E_lsanpham);
        }
        [HttpPost]
        public ActionResult EditLoai(int id, FormCollection collection)
        {
            var E_sanpham = data.LoaiSps.First(m => m.maloaisp == id);
            var E_tenloai = collection["tenloaisp"];

            E_sanpham.maloaisp = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sanpham.tenloaisp = E_tenloai;
                UpdateModel(E_sanpham);
                data.SubmitChanges();
                return RedirectToAction("Listloaihanghoa", "Admin");
            }
            return this.EditLoai(id);
        }

        public ActionResult DeleteLoai(int id)
        {
            var D_sanpham = data.LoaiSps.First(m => m.maloaisp == id);
            return View(D_sanpham);
        }
        [HttpPost]
        public ActionResult DeleteLoai(int id, FormCollection collection)
        {
            var D_Loaisp = data.LoaiSps.Where(m => m.maloaisp == id).First();
            data.LoaiSps.DeleteOnSubmit(D_Loaisp);
            data.SubmitChanges();
            return RedirectToAction("Listloaihanghoa", "Admin");
        }
    }



}
