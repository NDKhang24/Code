using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    internal class ThongKe
    {
        public ThongKe(string ma_HD, string ma_KH, string tenKhachHang, string tenNhanVien, DateTime ngay, string khuyenMai, int tienKM, int tongTien)
        {
            this.Ma_HD = ma_HD;
            this.Ma_KH = ma_KH;
            this.TenKhachHang = tenKhachHang;
            this.TenNhanVien = tenNhanVien;
            this.Ngay = ngay;
            this.KhuyenMai = khuyenMai;
            this.TienKM = tienKM;
            this.TongTien = tongTien;
        }
        public ThongKe(DataRow row)
        {
            this.Ma_HD = row["Ma_HD"].ToString().Trim();
            this.Ma_KH = row["Ma_KH"].ToString().Trim();
            this.TenKhachHang = row["Ten_KH"].ToString().Trim();
            this.TenNhanVien = row["Ten_NhanVien"].ToString().Trim();
            this.Ngay = (DateTime)row["Ngay_Lap"];
            this.KhuyenMai = row["Khuyen_Mai"].ToString().Trim();
            this.TienKM = (int)row["TongTien_KM"];
            this.TongTien = (int)row["TongTien_HD"];
        }
        private string ma_HD;
        public string Ma_HD
        {
            get { return ma_HD; }
            set { ma_HD = value; }
        }

        private string ma_kh;
        public string Ma_KH
        {
            get { return ma_kh; }
            set { ma_kh = value; }
        }

        private string tenKhachHang;
        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }


        private string tenNhanVien;
        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set { tenNhanVien = value; }
        }

        private DateTime ngay;

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        private string khuyenMai;
        public string KhuyenMai
        {
            get { return khuyenMai; }
            set { khuyenMai = value; }
        }
        private int tienKM;
        public int TienKM
        {
            get { return tienKM; }
            set { tienKM = value; }
        }
        private int tongTien;
        public int TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
    }
}
