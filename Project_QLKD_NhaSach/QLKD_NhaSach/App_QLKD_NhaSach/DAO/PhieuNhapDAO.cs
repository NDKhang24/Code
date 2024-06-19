using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DAO
{
    class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;

        public static PhieuNhapDAO Instance
        {
            get { if (instance == null) instance = new PhieuNhapDAO(); return instance; }
            private set { instance = value; }
        }
        private PhieuNhapDAO() { }


        public PhieuNhap PhieuNhap_ID(string mapn)
        {
            PhieuNhap pn = null;

            string query = "select * from PhieuNhap where Ma_PN = N'" + mapn + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                pn = new PhieuNhap(item);
                return pn;
            }
            return pn;
        }
        public List<CT_PhieuNhapSach> CTPhieuNhap_ID(string maPN)
        {
            List<CT_PhieuNhapSach> list = new List<CT_PhieuNhapSach>();

            string query = "select s.Ma_Sach, s.Ten_Sach, ct.SoLuong, ct.DonGia from CT_PhieuNhap ct, Sach s where ct.Ma_Sach = s.Ma_Sach and ct.Ma_PN = N'"+ maPN +"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int dem = 0;
            foreach (DataRow item in data.Rows)
            {
                dem++;
                CT_PhieuNhapSach import = new CT_PhieuNhapSach(dem, item["Ma_Sach"].ToString(), item["Ten_Sach"].ToString(), int.Parse(item["SoLuong"].ToString()), int.Parse(item["DonGia"].ToString()), (int.Parse(item["SoLuong"].ToString()) * int.Parse(item["DonGia"].ToString())));
                list.Add(import);
            }
            return list;
        }

        public List<PhieuNhap> DanhSachPhieuNhap(string Ma_Phieu = "", string ngayBD = "", string ngayKT = "")
        {
            List<PhieuNhap> listPN = new List<PhieuNhap>();
            string text = "  ";
            if (Ma_Phieu != "")
            {
                text += " where ";

                text += "  Ma_PN like N'%" + Ma_Phieu + "%' and  ";

            }
            if (ngayBD != "")
            {
                if (Ma_Phieu == "")
                {
                    text += " where ";
                }
                text += " NgayLap >= '" + ngayBD + "' ";
            }
            if (ngayKT != "")
            {
                text += " and NgayLap <= '" + ngayKT + "' ";
            }
            string query = "select * from PhieuNhap " + text;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PhieuNhap pn = new PhieuNhap(item);
                listPN.Add(pn);
            }

            return listPN;

        }


        public bool InsertPhieuNhap(List<CT_PhieuNhapSach> list, string manv, string mancc,  string makho)
        {
            string id = PhieuNhapDAO.Instance.Getprefix();
            string query = string.Format("insert into PhieuNhap values (N'" + id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + 0 + "', N'Chưa Duyệt', N'" + manv + "', N'" + mancc + "', N'" + makho + "')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            int tienNhap = 0;
            foreach (var item in list)
            {
                query = string.Format("insert into CT_PhieuNhap values (N'" + id + "',N'" + item.MaSach + "','" + item.SoLuong + "','" + item.DonGia + "')");
                DataProvider.Instance.ExecuteNonQuery(query);
                tienNhap += item.TongTien;
            }
            DataProvider.Instance.ExecuteNonQuery("update PhieuNhap set TongTien_Nhap = '" + tienNhap + "' where Ma_PN = '" + id + "'");
            return result > 0;
        }
        public bool deletePhieuNhap(string maPN)
        {
            string query2 = string.Format("Delete CT_PhieuNhap where Ma_PN = '" + maPN + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query2);
            string query1 = string.Format("delete PhieuNhap where Ma_PN = '" + maPN + "'");
            DataProvider.Instance.ExecuteNonQuery(query1);
            return result > 0;
        }

        public bool Comfirm_PhieuNhap(string maPN, string type)
        {

            string query = "select SoLuong, Ma_Sach from CT_PhieuNhap where Ma_PN = '" + maPN + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                if (type == "nhap")
                {
                    DataProvider.Instance.ExecuteNonQuery("update Sach set So_Luong = (So_Luong + '" + item["SoLuong"] + "') where Ma_Sach = '" + item["Ma_Sach"] + "'");
                }
                else
                {
                    DataProvider.Instance.ExecuteNonQuery("update Sach set So_Luong = (So_Luong - '" + item["SoLuong"] + "') where Ma_Sach = '" + item["Ma_Sach"] + "'");
                }
            }
            if (type == "nhap")
            {
                DataProvider.Instance.ExecuteNonQuery("update PhieuNhap set TrangThai = N'Đã Duyệt' where Ma_PN = '" + maPN + "'");
            }
            else
            {
                DataProvider.Instance.ExecuteNonQuery("update PhieuNhap set TrangThai = N'Chưa Duyệt' where Ma_PN = '" + maPN + "'");

            }
            return true;
        }


        public string Getprefix()

        {
            string query = "select * from PhieuNhap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "PN01";
            }
            else
            {
                int k;
                g = "PN";
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
