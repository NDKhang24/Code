using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace App_QLKD_NhaSach.DAO
{
    public class TTHoaDonDAO
    {
        private static TTHoaDonDAO instance;

        public static TTHoaDonDAO Instance 
        {
            get { if (instance == null) instance = new TTHoaDonDAO(); return instance; }
            private set { instance = value; }
        }


        private TTHoaDonDAO() { }
        public bool ThemHoaDon(List<HoaDon> list, TaiKhoan tkDangNhap, KhachHang khachHangs)
        {
            int discount = KhuyenMai.discount;
            string kh = khachHangs.MaKH ;
            string ma_NV = tkDangNhap.Tai_Khoan;

            string ma_HD = TTHoaDonDAO.Instance.Getprefix();
            string query = "insert into HoaDon values (N'" + ma_HD + "',N'" + DateTime.Now.ToString("yyyy-MM-dd") + "',N'" + kh + "',N'" + ma_NV + "',N'" + discount + "',0,0)";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            int total = 0;
            foreach (var item in list)
            {
                query = "insert into CT_HoaDon values (N'" +  ma_HD + "',N'" + item.Ma_SP + "'," + item.SoLuong + "," + item.Price + "," + (item.SoLuong * item.Price) + ")";
                DataProvider.Instance.ExecuteNonQuery(query);

                DataProvider.Instance.ExecuteNonQuery("update Sach set So_Luong = (So_Luong - " + item.SoLuong + ") where Ma_Sach = N'" + item.Ma_SP + "'");

                total += item.SoLuong * item.Price;
            }
            int discountpos = (int)(((total * (discount / 100f))));
            total = total - discountpos;
            DataProvider.Instance.ExecuteNonQuery("update HoaDon set TongTien_HD = '" + total + "',TongTien_KM = " + discountpos + " where Ma_HD = N'" + ma_HD + "'");
            return result > 0;
        }

        public bool DSHoaDon_MaHD(string ma_HD)
        {
            string query = "select * from HoaDon where Ma_HD = N'" + ma_HD + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            Console.WriteLine(data.Rows.Count);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public List<HoaDon> DS_CTHD(string ma_HD)
        {
            List<HoaDon> list = new List<HoaDon>();
            string query = "select hd.Ma_HD, s.Ma_Sach, s.Ten_Sach, n.Ten_Nhom, s.The_Loai, cthd.SoLuong, cthd.DonGia from HoaDon hd, CT_HoaDon cthd, Sach s, Nhom n where cthd.Ma_HD = hd.Ma_HD  and cthd.Ma_Sach = s.Ma_Sach and s.Ma_Nhom = n.Ma_Nhom and hd.Ma_HD = N'"+ ma_HD +"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int dem = 1;
            foreach (DataRow item in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(dem, item["MA_Sach"].ToString(), item["Ten_Sach"].ToString(), item["Ten_Nhom"].ToString(), item["The_Loai"].ToString(), int.Parse(item["SoLuong"].ToString()), int.Parse(item["DonGia"].ToString()));
                dem++;
                list.Add(hoaDon);
            }
            return list;
        }



        public string Getprefix()

        {
            string query = "select * from HoaDon";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string g = "";

            if ((data.Rows.Count <= 0))
            {
                return "HD01";
            }
            else
            {
                int k;
                g = "HD";
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
