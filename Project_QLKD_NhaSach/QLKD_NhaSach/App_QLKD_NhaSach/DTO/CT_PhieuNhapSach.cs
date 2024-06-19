using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    internal class CT_PhieuNhapSach
    {
        public CT_PhieuNhapSach(int id, string maSach, string tenSach, int soLuong, int donGia, int tongTien) 
        {
            this.ID = id;
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.TongTien = tongTien;
        }

        private int iD;
        public int ID 
        { 
            get { return iD; }
            set { iD = value; }
        }
        private string maSach;
        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        private string tenSach;
        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }
        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private int donGia;
        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private int tongTien;
        public int TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
    }
}
