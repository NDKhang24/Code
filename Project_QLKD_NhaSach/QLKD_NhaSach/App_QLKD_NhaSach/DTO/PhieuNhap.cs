using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    class PhieuNhap
    {
        public PhieuNhap(string ma_PN, DateTime ngay_PN, int tongTien_PN, string trangThai_PN, string nhanVien_PN, string nhaCungCap_PN, string maKho_PN) 
        {
            this.Ma_PN = ma_PN;
            this.Ngay_PN = ngay_PN;
            this.TongTien_PN = tongTien_PN;
            this.TrangThai_PN = trangThai_PN;
            this.NhanVien_PN = nhanVien_PN;
            this.NhaCungCap_PN = nhaCungCap_PN;
            this.MaKho_PN = maKho_PN;
        }

        public PhieuNhap (DataRow row)
        {
            this.Ma_PN = row["Ma_PN"].ToString().Trim();
            this.Ngay_PN = (DateTime)row["NgayLap"];
            this.TongTien_PN = (int)row["TongTien_Nhap"];
            this.TrangThai_PN = row["TrangThai"].ToString().Trim();
            this.NhanVien_PN = row["Tai_Khoan"].ToString().Trim();
            this.NhaCungCap_PN = row["Ma_NCC"].ToString().Trim();
            this.MaKho_PN = row["Ma_Kho"].ToString().Trim();
        }


        private string ma_PN;
        public string Ma_PN 
        { 
            get {  return ma_PN; }
            set { ma_PN = value; }
        }
        private DateTime ngay_PN;
        public DateTime Ngay_PN
        {
            get { return ngay_PN; }
            set { ngay_PN = value; }
        }
        private int tongTien_PN;
        public int TongTien_PN
        {
            get { return tongTien_PN; }
            set { tongTien_PN = value; }
        }
        private string trangThai_PN;
        public string TrangThai_PN
        {
            get { return trangThai_PN; }
            set { trangThai_PN = value; }
        }
        private string nhanVien_PN;
        public string NhanVien_PN
        {
            get { return nhanVien_PN; }
            set { nhanVien_PN = value; }
        }
        private string nhaCungCap_PN;
        public string NhaCungCap_PN
        {
            get { return nhaCungCap_PN; }
            set { nhaCungCap_PN = value; }
        }
        private string maKho_PN;
        public string MaKho_PN
        {
            get { return maKho_PN; }
            set { maKho_PN = value; }
        }
    }
}
