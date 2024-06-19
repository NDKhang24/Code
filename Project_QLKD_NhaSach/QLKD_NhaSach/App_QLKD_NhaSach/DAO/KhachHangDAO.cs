using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App_QLKD_NhaSach.DAO
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }
        private KhachHangDAO() { }

        public List<KhachHang> DanhsachKH(string ten = "") 
        {
            List<KhachHang> listkh = new List<KhachHang>();
            string text = "";
            if (ten != "")
            {
                text += " where Ten_KH like N'%"+ ten +"%' or SDT like N'%"+ ten +"%'";
            }
            string query = "select * from KhachHang" + text;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhachHang kh = new KhachHang(item);
                listkh.Add(kh);
            }
            return listkh;
        }

        public KhachHang DS_KhachHang_SDT(string sdt) 
        {
            KhachHang kh = null;
            string query = "select * from KhachHang where SDT = '" + sdt + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                kh = new KhachHang(item);
                return kh;
            }
            return kh;
        }


        public KhachHang DS_KhachHang_ID(string Ma_KH)
        {
            KhachHang kh = null;
            string query = "select * from KhachHang where Ma_KH = N'"+ Ma_KH +"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                kh = new KhachHang(item);
                return kh;
            }
            return kh;
        }

        public bool ThemKhachHang(string tenKH, string gioiTinh, string sdt, string diaChi, string email)
        {
            string id = KhachHangDAO.Instance.Getprefix();
            string query = string.Format("insert into KhachHang values ('" + id + "',N'" + tenKH + "',N'" + gioiTinh + "',N'" + sdt + "',N'" + diaChi + "',N'" + email + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateKhachHang(string maKH, string tenKH, string gioiTinh, string sdt, string diaChi, string email)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("update KhachHang set Ten_KH = N'" + tenKH + "' , SDT = N'" + sdt + "' , DiaChi = N'" + diaChi + "', Gioi_Tinh = N'" + gioiTinh + "', Email = N'" + email + "' where Ma_KH = '" + maKH + "'");
            return result > 0;
        }
        public bool DeleteKhachHang(string maKH)
        {
            string query = string.Format("Delete KhachHang where Ma_KH = N'" + maKH + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool TestKhachHang(string maKH)
        {
            string query = "select * from HoaDon where Ma_KH = '" + maKH + "'";
            DataTable datas = DataProvider.Instance.ExecuteQuery(query);
            if (datas.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public string Getprefix()

        {
            string query = "select * from KhachHang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "KH01";
            }
            else
            {
                int k;
                g = "KH";
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
