using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QLKD_NhaSach.DAO
{
    class ThongKeDAO
    {
        private static ThongKeDAO instance;

        internal static ThongKeDAO Instance 
        { 
            get { if (instance == null) instance = new ThongKeDAO(); return ThongKeDAO.instance; }
            set { ThongKeDAO.instance = value; } 
        }

        private ThongKeDAO() { }



        public List<ThongKe> ListDoanhThu(string Ten_KH = "", string Ten_NV = "", string ngayBD = "", string ngayKT = "")
        {
            List<ThongKe> list = new List<ThongKe>();
            string text = "";
            if (Ten_KH != "")
            {
                text += " and (kh.Ten_KH like N'%" + Ten_KH + "%' or kh.SDT like N'%" + Ten_KH + "%') ";
            }
            if (Ten_NV != "")
            {
                text += " and nv.Tai_Khoan = N'" + Ten_NV + "' ";
            }
            if (ngayBD != "")
            {
                text += " and hd.Ngay_Lap >= '" + ngayBD + "' ";
            }
            if (ngayKT != "")
            {
                text += " and hd.Ngay_Lap <= '" + ngayKT + "' ";
            }
            string query = "select hd.Ma_HD, kh.Ma_KH, kh.Ten_KH, nv.Ten_NhanVien, hd.Ngay_Lap, hd.Khuyen_Mai, hd.TongTien_KM, hd.TongTien_HD from HoaDon hd,KhachHang kh,NhanVien nv where hd.Tai_Khoan = nv.Tai_Khoan and hd.Ma_KH = kh.Ma_KH " + text;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongKe thongKe = new ThongKe(item);
                list.Add(thongKe);
            }
            return list;
        }

    }
}
