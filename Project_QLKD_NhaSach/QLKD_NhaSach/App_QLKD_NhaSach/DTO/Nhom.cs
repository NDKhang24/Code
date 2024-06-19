using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DTO
{
    internal class Nhom
    {
        public Nhom(string maNhom, string tenNhom) 
        { 
            this.MaNhom = maNhom;
            this.TenNhom = tenNhom;
        }

        public Nhom(DataRow row)
        {
            this.MaNhom = row["Ma_Nhom"].ToString().Trim();
            this.TenNhom = row["Ten_Nhom"].ToString().Trim();
        }

        private string maNhom;
        public string MaNhom 
        { 
            get {  return maNhom; } 
            set {  maNhom = value; } 
        }
        private string tenNhom;
        public string TenNhom
        {
            get { return tenNhom; }
            set { tenNhom = value; }
        }




    }
}
