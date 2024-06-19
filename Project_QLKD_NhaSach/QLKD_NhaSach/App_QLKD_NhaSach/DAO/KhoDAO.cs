using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DAO
{
    internal class KhoDAO
    {
        private static KhoDAO instance;

        public static KhoDAO Instance
        {
            get { if (instance == null) instance = new KhoDAO(); return instance; }
            private set { instance = value; }
        }
        private KhoDAO() { }

        public List<Kho> DanhsachKho(string tenKho = "")
        {
            List<Kho> listkho = new List<Kho>();
            string text = "";
            if (tenKho != "")
            {
                text += "where Ten_Kho like N'%" + tenKho + "%'";
            }
            string query = "select * from Kho" + text;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Kho kho = new Kho(item);
                listkho.Add(kho);
            }
            return listkho;
        }
        public List<Kho> TimKho(string tenKho = "")
        {
            List<Kho> list = new List<Kho>();
            string text = "";
            if (tenKho != "")
            {
                text += " where Ten_Kho like N'%" + tenKho + "%' or Ma_Kho like N'%" + tenKho + "%'";
            }
            string query = "select * from Kho " + text;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Kho kho = new Kho(item);
                list.Add(kho);
            }
            return list;
        }

        public bool UpdateKho(string maKho, string tenKho)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update Kho set Ten_Kho = N'" + tenKho + "' where Ma_Kho = N'" + maKho + "'");
            return result > 0;
        }
        public bool InsertKho(string tenKho)
        {
            string maKho = KhoDAO.Instance.Getprefix();
            string query = string.Format("insert into Kho values (N'" + maKho + "',N'" + tenKho + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteKho(string maKho)
        {
            string query = string.Format("delete Kho where Ma_Kho = N'" + maKho + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool TestKho(string maKho)
        {
            string query = "select * from Sach where Ma_Kho = N'" + maKho + "'";
            DataTable datas = DataProvider.Instance.ExecuteQuery(query);
            if (datas.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string Getprefix()
        {
            string query = "select * from Kho";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "Ko01";
            }
            else
            {
                int k;
                g = "Ko";
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

