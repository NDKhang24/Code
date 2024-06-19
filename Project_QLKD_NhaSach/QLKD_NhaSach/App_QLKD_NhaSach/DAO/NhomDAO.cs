using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DAO
{
    class NhomDAO
    {
        private static NhomDAO instance;

        public static NhomDAO Instance
        {
            get { if (instance == null) instance = new NhomDAO(); return instance; }
            private set { instance = value; }
        }
        private NhomDAO() { }

        public List<Nhom> DanhSachNhom(string Ma_Nhom = "")
        {
            List<Nhom> listNhom = new List<Nhom>();
            string text = "";
            if (Ma_Nhom != "")
            {
                text += " where Ten_Nhom LIKE N'%" + Ma_Nhom + "%'";
            }
            string query = "select * from Nhom " + text;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {

                Nhom n = new Nhom(item);
                listNhom.Add(n);
            }
            return listNhom;

        }
        public List<Nhom> TimNhom(string tenNhom = "")
        {
            List<Nhom> list = new List<Nhom>();
            string text = "";
            if (tenNhom != "")
            {
                text += " where Ten_Nhom like N'%" + tenNhom + "%' or Ma_Nhom like N'%" + tenNhom + "%'";
            }
            string query = "select * from Nhom " + text;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Nhom nhom = new Nhom(item);
                list.Add(nhom);
            }
            return list;
        }
        public bool UpdateNhom(string ma_Nhom, string ten_Nhom)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update Nhom set Ten_Nhom = N'" + ten_Nhom + "' where Ma_Nhom = N'" + ma_Nhom + "'");
            return result > 0;
        }

        public bool InsertNhom(string ten_Nhom)
        {
            string id = NhomDAO.Instance.Getprefix();
            string query = string.Format("insert into Nhom values (N'" + id + "',N'" + ten_Nhom + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNhom(string ma_Nhom)
        {
            string query = string.Format("delete Nhom where Ma_Nhom = N'" + ma_Nhom + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool TestNhom(string ma_Nhom)
        {
            string query = "select * from Sach where Ma_Nhom = N'" + ma_Nhom + "'";
            DataTable datas = DataProvider.Instance.ExecuteQuery(query);
            if (datas.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string Getprefix()
        {
            string query = "select * from Nhom";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "NH01";
            }
            else
            {
                int k;
                g = "NH";
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
