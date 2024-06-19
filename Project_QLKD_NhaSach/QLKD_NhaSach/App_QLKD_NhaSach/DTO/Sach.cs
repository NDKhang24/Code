using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    class Sach
    {
        public Sach(string maSach, string tenSach, string theLoai, string tacGia, string nhaXuatBan, int soLuong, int giaBan, string maKho, string maNCC, string maNhom) 
        { 
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.TheLoai = theLoai;
            this.TacGia = tacGia;
            this.NhaXuatBan = nhaXuatBan;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
            this.MaKho = maKho;
            this.MaNCC = maNCC;
            this.MaNhom = maNhom;
        }

        public Sach(DataRow row)
        {
            this.MaSach = row["Ma_Sach"].ToString().Trim();
            this.TenSach = row["Ten_Sach"].ToString().Trim();
            this.TheLoai = row["The_Loai"].ToString().Trim();
            this.TacGia = row["Tac_Gia"].ToString().Trim();
            this.NhaXuatBan = row["Nha_XB"].ToString().Trim();
            this.SoLuong = (int)row["So_Luong"];
            this.GiaBan = (int)row["Gia_Ban"];
            this.MaKho = row["Ma_Kho"].ToString().Trim();
            this.MaNCC = row["Ma_NCC"].ToString().Trim();
            this.MaNhom = row["Ma_Nhom"].ToString().Trim();
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
        private string theLoai;
        public string TheLoai
        {
            get { return theLoai; }
            set { theLoai = value; }
        }
        private string tacGia;
        public string TacGia
        {
            get { return tacGia; }
            set { tacGia = value; }
        }
        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private int giaBan;
        public int GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }
        private string nhaXuatBan;
        public string NhaXuatBan
        {
            get { return nhaXuatBan; }
            set { nhaXuatBan = value; }
        }

        private string maKho;
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        private string maNCC;
        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }
        private string maNhom;
        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }
    }
}
