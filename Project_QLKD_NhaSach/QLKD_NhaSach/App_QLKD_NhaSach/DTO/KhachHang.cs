using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    public class KhachHang
    {
        public KhachHang(string maKH, string tenKH, string gioitinh, string sdt, string diachi, string email) 
        { 
        
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.Gioitinh = gioitinh;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Email = email;
        }
        public KhachHang(DataRow row) 
        {
            this.MaKH = row["Ma_KH"].ToString().Trim();
            this.TenKH = row["Ten_KH"].ToString().Trim();
            this.Gioitinh = row["Gioi_Tinh"].ToString().Trim();
            this.Sdt = row["SDT"].ToString().Trim();
            this.Diachi = row["DiaChi"].ToString().Trim();
            this.Email = row["Email"].ToString().Trim();


        }

        private string maKH;
        public string MaKH 
        { 
            get { return maKH; } 
            set {  maKH = value; } 
        }
        private string tenKH;
        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }
        private string gioitinh;
        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private string sdt;
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string diachi;
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
