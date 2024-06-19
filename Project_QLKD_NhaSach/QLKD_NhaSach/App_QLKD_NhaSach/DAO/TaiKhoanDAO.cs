using App_QLKD_NhaSach.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DAO
{
    class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        internal static TaiKhoanDAO Instance 
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set { instance = value;  } 
        }

        private TaiKhoanDAO(){ }


        public List<TaiKhoan> DanhsachTaiKhoan(string ten = "")
        {
            List<TaiKhoan> listTaiKhoan = new List<TaiKhoan>();
            string text = "";
            if(ten != null) 
            {
                text += " where Ten_NhanVien like N'%" + ten + "%'";
            }
            string query = "select * from NhanVien" + text;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TaiKhoan account = new TaiKhoan(item);
                listTaiKhoan.Add(account);
            }

            return listTaiKhoan; 
        }


        public bool DangNhapTK(string tenTaiKhoan, string matKhau)
        {
            string query = "sp_DangNhap @tenTaiKhoan , @matKhau";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[]{tenTaiKhoan, matKhau});
            
            return result.Rows.Count > 0;
        }

        public bool CapNhatTTNV(string maTK, string tenTK, string MKmoi )
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update NhanVien set Ten_NhanVien = N'" + tenTK + "' ,Mat_Khau = N'" + MKmoi + "' where Tai_Khoan = N'" + maTK + "'");
            return result > 0;
        }

        public bool CapNhatTTNV_Ten(string tenNV, string maTK)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update NhanVien set Ten_NhanVien = N'" + tenNV + "' where Tai_Khoan = N'" + maTK + "'");
            return result > 0;
        }

        public TaiKhoan TaiKhoan_theoTaiKhoan(string taiKhoan)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from NhanVien where Tai_Khoan = N'" + taiKhoan + "'");

            foreach (DataRow item in data.Rows)
            {
                return new TaiKhoan(item);
            }

            return null;
        }

        public int tinhTongDoanhThuNgay(string Tai_Khoan)
        {
            int tongTien = 0;
            DateTime today = DateTime.Today;
            string day = today.ToString("yyyy-MM-dd");
            string query = "select coalesce(sum(TongTien_HD),0) as TongTienNV from HoaDon where Tai_Khoan = N'"+ Tai_Khoan +"' and Ngay_Lap = '"+ day +"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                tongTien = int.Parse(item["TongTienNV"].ToString());
                return tongTien;
            }

            return tongTien;
        }

        public bool ThemTaiKhoan_role(string mk, string tenNV, string sdt, string diaChi, string email, int chucVU)
        {
            string maNV = TaiKhoanDAO.Instance.Getprefix();
            string query = string.Format("insert into NhanVien values (N'" + maNV + "', N'"+ mk +"', N'" + tenNV + "',N'" + sdt + "',N'" + diaChi + "',N'" + email + "','"+ chucVU +"')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateNhanVien_role(string maNV,string mk, string tenNV, string sdt, string diaChi, string email, int chucVu)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("update NhanVien set Ten_NhanVien = N'" + tenNV + "' ,Mat_Khau = N'"+ mk +"' , SDT = N'" + sdt + "' , DiaChi = N'" + diaChi + "', Email = N'" + email + "', Ma_ChucVu = '"+ chucVu +"' where Tai_Khoan = N'" + maNV + "'");
            return result > 0;
        }
        public bool DeleteNhanVien(string maNV)
        {
            string query = string.Format("Delete NhanVien where Tai_Khoan = N'" + maNV + "'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool TestNhamVien(string maNV)
        {
            string query = "select * from HoaDon where Tai_Khoan = N'" + maNV + "'";
            DataTable datas = DataProvider.Instance.ExecuteQuery(query);
            if (datas.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string Getprefix()
        {
            string query = "select * from NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "TK01";
            }
            else
            {
                int k;
                g = "TK";
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
