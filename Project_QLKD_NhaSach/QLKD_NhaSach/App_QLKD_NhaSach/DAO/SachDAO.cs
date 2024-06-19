
using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DAO
{
    class SachDAO
    {
        private static SachDAO instance;

        public static SachDAO Instance
        {
            get { if (instance == null) instance = new SachDAO(); return instance; }
            private set { instance = value; }
        }
        private SachDAO() { }

        public List<Sach> DanhSachSach(string Ma_Sach = "") 
        {
            List<Sach> list = new List<Sach>();
            string text = "";
            if (Ma_Sach != "")
            {
                text += " where Ten_Sach like N'%" + Ma_Sach + "%' or Ma_Sach like N'"+ Ma_Sach +"' ";
            }
            string query = "select Ma_Sach, Ten_Sach, The_Loai, Tac_Gia, Nha_XB, So_Luong, Gia_Ban, Ma_Kho, Ma_NCC, Ma_Nhom from Sach " + text;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {

                Sach s = new Sach(item);
                list.Add(s);
            }
            return list;

        }
        public Sach SachByMa_Sach(string Ma_Sach)
        {
            Sach items = null;

            string query = "select * from Sach where Ma_Sach = '" + Ma_Sach + "' or Ten_Sach like N'%"+ Ma_Sach +"%' ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                items = new Sach(item);
                return items;
            }

            return items;
        }


        public List<Sach> DanhsachSachByName(string Ten_Sach)
        {
            List<Sach> list = new List<Sach>();

            string query = "select Ma_Sach, Ten_Sach, The_Loai, Tac_Gia, Nha_XB, So_Luong, Gia_Ban, Ma_Kho, Ma_NCC, Ma_Nhom where Ten_Sach like N'%" + Ten_Sach + "%' or Ma_Sach like N'%"+ Ten_Sach +"%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Sach s = new Sach(item);
                list.Add(s);
            }

            return list;
        }

        public bool InsertSach(string tenSach, string theLoai, string tacGia, string nXB, int soLuong, int gia, string maKho, string maNCC, string maNhom)
        {
            string id = SachDAO.Instance.Getprefix();
            string query = "insert into Sach values (N'" + id + "',N'" + tenSach + "',N'"+ theLoai +"',N'" + tacGia + "',N'" + nXB + "',0,'" + gia + "',N'"+ maKho +"',N'" + maNCC + "',N'"+ maNhom +"')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateSach(string maSach,string tenSach, string theLoai, string tacGia, string nXB, int gia, string maKho, string maNCC, string maNhom)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update Sach set Ten_Sach = N'" + tenSach + "',The_Loai = N'" + theLoai + "',Tac_Gia = N'" + tacGia + "',Nha_XB = N'" + nXB + "',Gia_Ban = '" + gia + "',Ma_kho = N'" + maKho + "',Ma_NCC = N'" + maNCC + "',Ma_Nhom = N'" + maNhom + "' where Ma_Sach = N'"+ maSach +"'");

            return result > 0;
        }

        public bool DeleteSach(string maSach)
        {
            string query = "Delete Sach where Ma_Sach = N'" + maSach + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool TestSach(string maSach)
        {
            string query = "select * from CT_HoaDon where Ma_Sach = N'" + maSach + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public string Getprefix()
        {
            string query = "select * from Sach";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "SA01";
            }
            else
            {
                int k;
                g = "SA";
                k = Convert.ToInt32(data.Rows[data.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k <= 9)
                {
                    g = g + "0";
                    g = g + k.ToString();
                }
                else
                {
                    g = g + k.ToString();
                }
                return g;
            }
        }
    }
}
