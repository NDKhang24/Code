using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    public class TaiKhoan
    {
        public TaiKhoan(string tai_Khoan, string matKhau, string tenNV, string sdt, string diaChi, string email, int chucVu) 
        {
            this.Tai_Khoan = tai_Khoan;
            this.MatKhau = matKhau;
            this.TenNV = tenNV;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
            this.Email = email;
            this.ChucVu = chucVu;

        }   

        public TaiKhoan(DataRow row) 
        {
            this.Tai_Khoan = row["Tai_Khoan"].ToString().Trim();
            this.MatKhau = row["Mat_Khau"].ToString().Trim();
            this.TenNV = row["Ten_NhanVien"].ToString().Trim();
            this.Sdt = row["SDT"].ToString().Trim();
            this.DiaChi = row["DiaChi"].ToString().Trim();
            this.Email = row["Email"].ToString().Trim();
            this.ChucVu = (int)row["Ma_ChucVu"];
        }

        private string tai_Khoan;
        public string Tai_Khoan 
        { 
            get { return tai_Khoan; } 
            set {  tai_Khoan = value; } 
        }
        private string matKhau;
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        private string tenNV;
        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }
        private string sdt;
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int chucVu;
        public int ChucVu
        { 
            get { return chucVu; }
            set { chucVu = value; }
        }


    }
}
