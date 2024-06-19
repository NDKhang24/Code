using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    class NhaCungCap
    {
        public NhaCungCap(string ma_NCC, string ten_NCC, string sdt, string diaChi) 
        {
            this.Ma_NCC = ma_NCC;
            this.Ten_NCC = ten_NCC;
            this.SDT = sdt;
            this.DiaChi = diaChi;
        }

        public NhaCungCap(DataRow row) 
        {
            this.Ma_NCC = row["Ma_NCC"].ToString().Trim();
            this.Ten_NCC = row["Ten_NCC"].ToString().Trim();
            this.SDT = row["SDT"].ToString().Trim();
            this.DiaChi = row["DiaChi"].ToString().Trim();
        }

        private string ma_NCC;
        public string Ma_NCC 
        {
            get { return ma_NCC; }
            set { ma_NCC = value; } 
        }
        private string ten_NCC;
        public string Ten_NCC
        {
            get { return ten_NCC; }
            set { ten_NCC = value; }
        }
        private string sdt;
        public string SDT
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


    }
}
