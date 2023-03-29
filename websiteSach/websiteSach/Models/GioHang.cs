using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using websiteSach.Models;

namespace websiteSach.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int MaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string Hinh { get; set; }

        [Display(Name = "Giá bán")]
        public double GiaBan { get; set; }

        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }

        [Display(Name = "Thành tiền")]
        public double dThanhtien
        {
            get { return iSoluong * GiaBan; }
        }
        public GioHang(int id)
        {
            MaSanPham = id;
            SanPham sanpham = data.SanPhams.Single(n => n.masp == MaSanPham);
            TenSanPham = sanpham.tensp;
            Hinh = sanpham.hinh;
            GiaBan = double.Parse(sanpham.giaban.ToString());
            iSoluong = 1;
        }
    }
}