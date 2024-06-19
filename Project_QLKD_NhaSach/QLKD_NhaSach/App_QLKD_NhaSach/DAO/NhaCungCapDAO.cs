using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DAO
{
    class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            private set { instance = value; }
        }
        private NhaCungCapDAO() { }


        public List<NhaCungCap> ListNhaCungCap(string tenNCC = "")
        {
            List<NhaCungCap> listncc = new List<NhaCungCap>();
            string text = "";
            if (tenNCC != "")
            {
                text += " where Ten_NCC like N'%" + tenNCC + "%' or Ma_NCC like N'%"+ tenNCC +"%'";
            }
            string query = "select * from NhaCungCap " + text;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                listncc.Add(ncc);
            }
            return listncc;

        }
        public NhaCungCap NhaCungCap_SDT(string sdt)
        {
            NhaCungCap kh = null;
            string query = "select * from NhaCungCap where SDT = N'" + sdt + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                kh = new NhaCungCap(item);
                return kh;
            }
            return kh;
        }
        public bool ThemNhaCungCap(string tenNCC, string sdt, string diaChi)
        {
            string maNCC = NhaCungCapDAO.Instance.Getprefix();
            string query = string.Format("insert into NhaCungCap values (N'" + maNCC + "',N'" + tenNCC + "',N'" + sdt + "',N'" + diaChi + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("update NhaCungCap set Ten_NCC = N'" + tenNCC + "' , SDT = N'" + sdt + "' , DiaChi = N'" + diaChi + "' where Ma_NCC = N'" + maNCC + "'");
            return result > 0;
        }
        public bool DeleteNhaCungCap(string maNCC)
        {
            string query = string.Format("Delete NhaCungCap where Ma_NCC = N'" + maNCC + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool TestNhaCungCap(string maNCC)
        {
            string query = "select * from Sach where Ma_NCC = N'" + maNCC + "'";
            DataTable datas = DataProvider.Instance.ExecuteQuery(query);
            if (datas.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public string Getprefix()
        {
            string query = "select * from NhaCungCap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "CC01";
            }
            else
            {
                int k;
                g = "CC";
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
