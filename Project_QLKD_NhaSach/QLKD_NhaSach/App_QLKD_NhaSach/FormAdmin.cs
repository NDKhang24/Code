using App_QLKD_NhaSach.DAO;
using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App_QLKD_NhaSach
{
    public partial class FormAdmin : Form
    {
        private TaiKhoan tkDangNhap;

        internal TaiKhoan TkDangNhap
        {
            get => tkDangNhap;
            set
            {
                tkDangNhap = value;
            }
        }
        public FormAdmin(TaiKhoan tk)
        {
            InitializeComponent();
            this.TkDangNhap = tk;
            LoadForm();
        }

        BindingSource DS_Danhthu = new BindingSource();
        BindingSource DS_Nhom = new BindingSource();
        BindingSource DS_Sach = new BindingSource();
        BindingSource DS_NhanVien = new BindingSource();
        BindingSource DS_KhachHang = new BindingSource();
        BindingSource DS_PhieuNhap = new BindingSource();
        BindingSource DS_NCC = new BindingSource();
        BindingSource DS_Kho = new BindingSource();

        void LoadForm()
        {
            dataGridView_ThongKeDoanhThu.DataSource = DS_Danhthu;
            dataGridView_Sach.DataSource = DS_Sach;
            dataGridView_TK.DataSource = DS_NhanVien;
            dataGridView_NCC.DataSource = DS_NCC;
            dataGridView_NhapKho.DataSource = DS_PhieuNhap;
            dataGridView_KH.DataSource = DS_KhachHang;
            dataGridView_Nhom.DataSource = DS_Nhom;
            dataGridView_kho.DataSource = DS_Kho;

            LoadDS();

            AddSachbinding();
            AddNhanVienbinding();
            AddKhachHangbinding();
            AddNhombinding();
            AddKhobinding();
            AddNhaCungCapbinding();
        }

        void LoadDS()
        {
            LoadDSDoanhthu();
            LoadDSSach();
            LoadDSNhanVien();
            LoadDSNhaCungCap();
            LoadDSNhom();
            LoadDSKhachHang();
            LoadDSPhieuNhap();
            LoadDSKho();
        }

        void LoadDSNhanVien()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            DataRow row = dt.NewRow();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            row["ID"] = "AD";
            row["Name"] = "Admin";
            dt.Rows.Add(row);
            DataRow rows = dt.NewRow();
            rows["ID"] = "NV";
            rows["Name"] = "Nhân Viên";
            dt.Rows.Add(rows);
            comboBox_CVNV.DataSource = dt;
            comboBox_CVNV.DisplayMember = "Name";
            DS_NhanVien.DataSource = TaiKhoanDAO.Instance.DanhsachTaiKhoan();
            this.dataGridView_TK.Columns["MatKhau"].Visible = false;

        }
        void AddNhanVienbinding()
        {
            textBox_TK.DataBindings.Add(new Binding("Text", dataGridView_TK.DataSource, "Tai_Khoan", true, DataSourceUpdateMode.Never));
            textBox_TenNV.DataBindings.Add(new Binding("Text", dataGridView_TK.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            textBox_SDTNV.DataBindings.Add(new Binding("Text", dataGridView_TK.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            textBox_DiachiNV.DataBindings.Add(new Binding("Text", dataGridView_TK.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            textBox_EmailNV.DataBindings.Add(new Binding("Text", dataGridView_TK.DataSource, "Email", true, DataSourceUpdateMode.Never));
        }
        void LoadDSKhachHang()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            DataRow row = dt.NewRow();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            row["ID"] = "Nam";
            row["Name"] = "Nam";
            dt.Rows.Add(row);
            DataRow rows = dt.NewRow();
            rows["ID"] = "Nữ";
            rows["Name"] = "Nữ";
            dt.Rows.Add(rows);
            comboBox_gioitinhKH.DataSource = dt;
            comboBox_gioitinhKH.DisplayMember = "Name";
            dataGridView_KH.DataSource = KhachHangDAO.Instance.DanhsachKH();
        }
        void AddKhachHangbinding()
        {
            textBox_MaKH.DataBindings.Add(new Binding("Text", dataGridView_KH.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            textBox_TenKH.DataBindings.Add(new Binding("Text", dataGridView_KH.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            textBox_SDTKH.DataBindings.Add(new Binding("Text", dataGridView_KH.DataSource, "Sdt", true, DataSourceUpdateMode.Never));
            textBox_DiachiKH.DataBindings.Add(new Binding("Text", dataGridView_KH.DataSource, "Diachi", true, DataSourceUpdateMode.Never));
            textBox_emailKH.DataBindings.Add(new Binding("Text", dataGridView_KH.DataSource, "Email", true, DataSourceUpdateMode.Never));
        }
        void LoadDSDoanhthu()
        {
            dataGridView_ThongKeDoanhThu.DataSource = ThongKeDAO.Instance.ListDoanhThu();
            comboBox_NVHD.DataSource = TaiKhoanDAO.Instance.DanhsachTaiKhoan();
            comboBox_NVHD.DisplayMember = "TenNV";
            comboBox_NVHD.ValueMember = "Tai_Khoan";
        }

        void LoadDSSach()
        {
            dataGridView_Sach.DataSource = SachDAO.Instance.DanhSachSach();
        }
        void AddSachbinding()
        {
            textBox_Masach.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "MaSach", true, DataSourceUpdateMode.Never));
            textBox_Tensach.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "TenSach", true, DataSourceUpdateMode.Never));
            textBox_Theloai.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "TheLoai", true, DataSourceUpdateMode.Never));
            textBox_Tacgia.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "TacGia", true, DataSourceUpdateMode.Never));
            textBox_Nhaxuatban.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "NhaXuatBan", true, DataSourceUpdateMode.Never));
            textBox_slSach.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            textBox_Giaban.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "GiaBan", true, DataSourceUpdateMode.Never));
            textBox_maKhoS.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "MaKho", true, DataSourceUpdateMode.Never));
            textBox_maNCCS.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            textBox_maNhomS.DataBindings.Add(new Binding("Text", dataGridView_Sach.DataSource, "MaNhom", true, DataSourceUpdateMode.Never));
        }
        void LoadDSNhaCungCap()
        {
            dataGridView_NCC.DataSource = NhaCungCapDAO.Instance.ListNhaCungCap();

        }
        void AddNhaCungCapbinding()
        {
            textBox_MaNCC.DataBindings.Add(new Binding("Text", dataGridView_NCC.DataSource, "Ma_NCC", true, DataSourceUpdateMode.Never));
            textBox_TenNCC.DataBindings.Add(new Binding("Text", dataGridView_NCC.DataSource, "Ten_NCC", true, DataSourceUpdateMode.Never));
            textBox_SDTNCC.DataBindings.Add(new Binding("Text", dataGridView_NCC.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            textBox_DiachiNCC.DataBindings.Add(new Binding("Text", dataGridView_NCC.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
        }
        void LoadDSNhom()
        {
            dataGridView_Nhom.DataSource = NhomDAO.Instance.DanhSachNhom();
        }
        void AddNhombinding()
        {
            textBox_maNhom.DataBindings.Add(new Binding("Text", dataGridView_Nhom.DataSource, "MaNhom", true, DataSourceUpdateMode.Never));
            textBox_tenNhom.DataBindings.Add(new Binding("Text", dataGridView_Nhom.DataSource, "TenNhom", true, DataSourceUpdateMode.Never));
        }
        void LoadDSPhieuNhap()
        {
            dataGridView_NhapKho.AutoGenerateColumns = false;
            DS_PhieuNhap.DataSource = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao Tác";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.DisplayIndex = 7;
            btn.UseColumnTextForButtonValue = true;
            int columnIndex = 7;
            if (dataGridView_NhapKho.Columns["btn"] == null)
            {
                dataGridView_NhapKho.Columns.Insert(columnIndex, btn);
            }
        }

        void LoadDSKho()
        {
            dataGridView_kho.DataSource = KhoDAO.Instance.DanhsachKho();
        }
        void AddKhobinding()
        {
            textBox_maKho.DataBindings.Add(new Binding("Text", dataGridView_kho.DataSource, "MaKho", true, DataSourceUpdateMode.Never));
            textBox_tenKho.DataBindings.Add(new Binding("Text", dataGridView_kho.DataSource, "TenKho", true, DataSourceUpdateMode.Never));
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void textBox_Masach_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_KTNhap_Click(object sender, EventArgs e)
        {

        }
        private void DongFromPN(object sender, FormClosedEventArgs e)
        {
            LoadDSPhieuNhap();
            dataGridView_NhapKho.Update();
            dataGridView_NhapKho.Refresh();
        }
        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button_HuyTK_Click(object sender, EventArgs e)
        {
            dataGridView_ThongKeDoanhThu.DataSource = ThongKeDAO.Instance.ListDoanhThu();
            textBox_DoanhThu.Text = "";
        }

        private void button_xemCTHD_Click(object sender, EventArgs e)
        {
            int id = dataGridView_ThongKeDoanhThu.CurrentCell.RowIndex;
            string mahd = dataGridView_ThongKeDoanhThu.Rows[id].Cells[0].Value.ToString();
            string km = dataGridView_ThongKeDoanhThu.Rows[id].Cells[5].Value.ToString();
            string makh = dataGridView_ThongKeDoanhThu.Rows[id].Cells[1].Value.ToString();

            if (TTHoaDonDAO.Instance.DSHoaDon_MaHD(mahd) == false)
            {
                MessageBox.Show("Hóa đơn không tồn tại");
            }
            else
            {
                XemCT_HoaDon cthd = new XemCT_HoaDon(mahd, km, makh);
                cthd.ShowDialog();
            }
        }
        private void button_TKNhom_Click(object sender, EventArgs e)
        {
            string tenNhom = textBox_TKNhom.Text;
            dataGridView_Nhom.DataSource = NhomDAO.Instance.TimNhom(tenNhom);
        }
        private void button_huytkNhom_Click(object sender, EventArgs e)
        {
            dataGridView_Nhom.DataSource = NhomDAO.Instance.DanhSachNhom();
        }
        private void button_themNhom_Click(object sender, EventArgs e)
        {
            string tenNhom = textBox_tenNhom.Text;
            if (NhomDAO.Instance.InsertNhom(tenNhom))
            {
                MessageBox.Show("Thêm nhóm sách thành công");
                LoadDSNhom();
                dataGridView_Nhom.Update();
                dataGridView_Nhom.Refresh();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhóm sách");
            }
        }

        private void button_suaNhom_Click(object sender, EventArgs e)
        {
            string tenNhom = textBox_tenNhom.Text;
            string maNhom = textBox_maNhom.Text;

            if (NhomDAO.Instance.UpdateNhom(maNhom, tenNhom))
            {
                MessageBox.Show("Sửa nhóm thành công");
                LoadDSNhom();
                dataGridView_Nhom.Update();
                dataGridView_Nhom.Refresh();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh nhóm");
            }
        }

        private void button_xoaNhom_Click(object sender, EventArgs e)
        {
            string maNhom = textBox_maNhom.Text;
            if (MessageBox.Show("Bạn có muốn xóa nhóm", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!NhomDAO.Instance.TestNhom(maNhom))
                {
                    if (NhomDAO.Instance.DeleteNhom(maNhom))
                    {
                        MessageBox.Show("Xóa nhóm thành công");
                        LoadDSNhom();
                        dataGridView_Nhom.Update();
                        dataGridView_Nhom.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa nhóm");
                    }
                }
                else
                {
                    MessageBox.Show("Nhóm đang được sử dụng không thể xóa");
                }
            }
        }

        private void button_tkKho_Click(object sender, EventArgs e)
        {
            string tenKho = textBox_tkKho.Text;
            dataGridView_kho.DataSource = KhoDAO.Instance.TimKho(tenKho);
        }

        private void button_huytkKho_Click(object sender, EventArgs e)
        {
            LoadDSKho();
        }

        private void button_themKho_Click(object sender, EventArgs e)
        {
            string tenKho = textBox_tenKho.Text;
            if (KhoDAO.Instance.InsertKho(tenKho))
            {
                MessageBox.Show("Thêm Kho sách thành công");
                LoadDSKho();
                dataGridView_kho.Update();
                dataGridView_kho.Refresh();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm kho sách");
            }
        }

        private void button_suaKho_Click(object sender, EventArgs e)
        {
            string tenKho = textBox_tenKho.Text;
            string maKho = textBox_maKho.Text;

            if (KhoDAO.Instance.UpdateKho(maKho, tenKho))
            {
                MessageBox.Show("Sửa kho thành công");
                LoadDSKho();
                dataGridView_kho.Update();
                dataGridView_kho.Refresh();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa kho");
            }
        }

        private void button_xoaKho_Click(object sender, EventArgs e)
        {
            string maKho = textBox_maKho.Text;
            if (MessageBox.Show("Bạn có muốn xóa kho", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!KhoDAO.Instance.TestKho(maKho))
                {
                    if (KhoDAO.Instance.DeleteKho(maKho))
                    {
                        MessageBox.Show("Xóa kho thành công");
                        LoadDSKho();
                        dataGridView_kho.Update();
                        dataGridView_kho.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa kho");
                    }
                }
                else
                {
                    MessageBox.Show("Kho đang được sử dụng không thể xóa");
                }
            }
        }

        private void button_ThemKH_Click(object sender, EventArgs e)
        {
            if (textBox_SDTKH.Text == "" || textBox_TenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng hoặc số điện thoại khách hàng");
            }
            else
            {
                if (KhachHangDAO.Instance.DS_KhachHang_SDT(textBox_SDTKH.Text) == null)
                {
                    if (KhachHangDAO.Instance.ThemKhachHang(textBox_TenKH.Text, comboBox_gioitinhKH.Text, textBox_SDTKH.Text, textBox_DiachiKH.Text, textBox_emailKH.Text))
                    {
                        MessageBox.Show("Thêm khách hàng thành công");
                        LoadDSKhachHang();
                        dataGridView_KH.Update();
                        dataGridView_KH.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại đã tồn tại");
                }
            }
        }

        private void button_SuaKH_Click(object sender, EventArgs e)
        {
            if (textBox_SDTKH.Text == "" || textBox_TenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng hoặc số điện thoại");
                return;
            }
            if (KhachHangDAO.Instance.UpdateKhachHang(textBox_MaKH.Text, textBox_TenKH.Text, comboBox_gioitinhKH.Text, textBox_SDTKH.Text, textBox_DiachiKH.Text, textBox_emailKH.Text))
            {
                MessageBox.Show("Sửa khách hàng thành công");
                LoadDSKhachHang();
                dataGridView_KH.Update();
                dataGridView_KH.Refresh();
            }
            else
            {
                MessageBox.Show("Sửa khách hàng không thành công");
            }
        }

        private void button_XoaKH_Click(object sender, EventArgs e)
        {
            string maKH = textBox_MaKH.Text;
            if (MessageBox.Show("Bạn có muốn xóa khách hàng", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!KhachHangDAO.Instance.TestKhachHang(maKH))
                {
                    if (KhachHangDAO.Instance.DeleteKhachHang(maKH))
                    {
                        MessageBox.Show("Xóa khách hàng thành công");

                        LoadDSKhachHang();
                        dataGridView_KH.Update();
                        dataGridView_KH.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa khách hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Khách hàng đã mua hàng không thể xóa");
                }
            }
        }

        private void button_TimKH_Click(object sender, EventArgs e)
        {
            string tenKH = textBox_TimKH.Text;
            dataGridView_KH.DataSource = KhachHangDAO.Instance.DanhsachKH(tenKH);
        }

        private void button_HuyTKKH_Click(object sender, EventArgs e)
        {
            dataGridView_KH.DataSource = KhachHangDAO.Instance.DanhsachKH();
        }

        private void button_ThemNCC_Click(object sender, EventArgs e)
        {
            if (textBox_MaNCC.Text == "" || textBox_TenNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hoặc số điện thoại nhà cung cấp");
            }
            else
            {
                if (NhaCungCapDAO.Instance.NhaCungCap_SDT(textBox_SDTNCC.Text) == null)
                {
                    if (NhaCungCapDAO.Instance.ThemNhaCungCap(textBox_TenNCC.Text, textBox_SDTNCC.Text, textBox_DiachiNCC.Text))
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công");
                        LoadDSNhaCungCap();
                        dataGridView_NCC.Update();
                        dataGridView_NCC.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhà cung cấp không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại nhà cung cấp đã tồn tại");
                }
            }

        }

        private void button_TKDoanhThu_Click(object sender, EventArgs e)
        {
            string kh = textBox_timKHHD.Text;
            string nv = comboBox_NVHD.SelectedValue.ToString();
            string ngayBD = dateTimePicker_NgayBD.Value.ToString("yyyy-MM-dd");
            string ngayKT = dateTimePicker_NgayKT.Value.ToString("yyyy-MM-dd");
            dataGridView_ThongKeDoanhThu.DataSource = ThongKeDAO.Instance.ListDoanhThu(kh, nv, ngayBD, ngayKT);


            List<ThongKe> listDoanhThu = ThongKeDAO.Instance.ListDoanhThu(kh, nv, ngayBD, ngayKT);
            decimal totalRevenue = 0;
            foreach (ThongKe thongKe in listDoanhThu)
            {
                totalRevenue += thongKe.TongTien;
            }
            textBox_DoanhThu.Text = totalRevenue.ToString();
        }

        private void button_SuaNCC_Click(object sender, EventArgs e)
        {
            if (textBox_TenNCC.Text == "" || textBox_SDTNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hoặc số điện thoại nhà cung cấp");
                return;
            }
            if (NhaCungCapDAO.Instance.UpdateNhaCungCap(textBox_MaNCC.Text, textBox_TenNCC.Text, textBox_SDTNCC.Text, textBox_DiachiNCC.Text))
            {
                MessageBox.Show("Sửa nhà cung cấp thành công");
                LoadDSNhaCungCap();
                dataGridView_NCC.Update();
                dataGridView_NCC.Refresh();
            }
            else
            {
                MessageBox.Show("Sửa nhà cung cấp không thành công");
            }
        }

        private void button_XoaNCC_Click(object sender, EventArgs e)
        {
            string maNCC = textBox_MaNCC.Text;
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!NhaCungCapDAO.Instance.TestNhaCungCap(maNCC))
                {
                    if (NhaCungCapDAO.Instance.DeleteNhaCungCap(maNCC))
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công");
                        LoadDSNhaCungCap();
                        dataGridView_NCC.Update();
                        dataGridView_NCC.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa nhà cung cấp");
                    }
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp đang hợp tác không thể xóa");
                }
            }
        }

        private void button_TimNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = textBox_TimNCC.Text;
            dataGridView_NCC.DataSource = NhaCungCapDAO.Instance.ListNhaCungCap(tenNCC);
        }

        private void button_huyTKNCC_Click(object sender, EventArgs e)
        {
            dataGridView_NCC.DataSource = NhaCungCapDAO.Instance.ListNhaCungCap();
        }

        private void button_ThemSach_Click(object sender, EventArgs e)
        {
            if (textBox_Tensach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sách");
                return;
            }
            if (textBox_Giaban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá sách");
                return;
            }
            if (textBox_maKhoS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã kho chứa sách");
                return;
            }
            if (textBox_maNCCS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp sách");
                return;
            }
            if (textBox_maNhomS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp sách");
                return;
            }
            if (SachDAO.Instance.InsertSach(textBox_Tensach.Text, textBox_Theloai.Text, textBox_Tacgia.Text, textBox_Nhaxuatban.Text, int.Parse(textBox_slSach.Text), int.Parse(textBox_Giaban.Text), textBox_maKhoS.Text, textBox_maNCCS.Text, textBox_maNhomS.Text))
            {
                LoadDSSach();
                dataGridView_Sach.Update();
                dataGridView_Sach.Refresh();
                MessageBox.Show("Thêm sách thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi sách");
            }
        }

        private void button_XoaSach_Click(object sender, EventArgs e)
        {
            string maSach = textBox_Masach.Text;
            if (MessageBox.Show("Bạn có muốn xóa sách", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!SachDAO.Instance.TestSach(maSach))
                {
                    if (SachDAO.Instance.DeleteSach(maSach))
                    {
                        MessageBox.Show("Xóa sách thành công");
                        LoadDSSach();
                        dataGridView_Sach.Update();
                        dataGridView_Sach.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa sách");
                    }
                }
                else
                {
                    MessageBox.Show("Sách đã được sử dụng không thể xóa");
                }
            }
        }

        private void button_TimKiemSach_Click(object sender, EventArgs e)
        {
            string timSach = textBox_TimKiemSach.Text;
            dataGridView_Sach.DataSource = SachDAO.Instance.DanhSachSach(timSach);
        }

        private void button_huyTKS_Click(object sender, EventArgs e)
        {
            dataGridView_Sach.DataSource = SachDAO.Instance.DanhSachSach();
        }

        private void button_SuaSach_Click(object sender, EventArgs e)
        {
            if (textBox_Tensach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sách");
                return;
            }
            if (textBox_Giaban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá sách");
                return;
            }
            if (textBox_maKhoS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã kho chứa sách");
                return;
            }
            if (textBox_maNCCS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp sách");
                return;
            }
            if (textBox_maNhomS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp sách");
                return;
            }
            if (SachDAO.Instance.UpdateSach(textBox_Masach.Text, textBox_Tensach.Text, textBox_Theloai.Text, textBox_Tacgia.Text, textBox_Nhaxuatban.Text, int.Parse(textBox_Giaban.Text), textBox_maKhoS.Text, textBox_maNCCS.Text, textBox_maNhomS.Text))
            {
                LoadDSSach();
                dataGridView_Sach.Update();
                dataGridView_Sach.Refresh();
                MessageBox.Show("Sửa sách thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa sách");
            }

        }

        private void button_ThemTK_Click(object sender, EventArgs e)
        {
            if (textBox_TenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
                return;
            }
            if (textBox_matKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu nhân viên");
                return;
            }
            int selectedIndex = comboBox_CVNV.SelectedIndex;
            int selectedValue = 2;
            if (selectedIndex == 0)
            {
                selectedValue = 1;
            }
            {
                if (TaiKhoanDAO.Instance.ThemTaiKhoan_role(textBox_matKhau.Text, textBox_TenNV.Text, textBox_SDTNV.Text, textBox_DiachiNV.Text, textBox_EmailNV.Text, selectedValue))
                {
                    LoadDSNhanVien();
                    dataGridView_TK.Update();
                    dataGridView_TK.Refresh();
                    MessageBox.Show("Thêm tài khoản thành công");
                }
            }

        }

        private void button_SuaTk_Click(object sender, EventArgs e)
        {
            if (textBox_TenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
                return;
            }
            if (textBox_matKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu nhân viên");
                return;
            }
            int selectedIndex = comboBox_CVNV.SelectedIndex;
            int selectedValue = 2;
            if (selectedIndex == 0)
            {
                selectedValue = 1;
            }
            if (textBox_matKhau.Text != "" && textBox_matKhau.Text != null)
            {
                if (TaiKhoanDAO.Instance.UpdateNhanVien_role(textBox_TK.Text, textBox_matKhau.Text, textBox_TenNV.Text, textBox_SDTNV.Text, textBox_DiachiNV.Text, textBox_EmailNV.Text, selectedValue))
                {
                    LoadDSNhanVien();
                    dataGridView_TK.Update();
                    dataGridView_TK.Refresh();
                    MessageBox.Show("Cập nhật thành công");

                }
            }
        }

        private void button_XoaTK_Click(object sender, EventArgs e)
        {
            string taikhoan = textBox_TK.Text;
            if (taikhoan == tkDangNhap.Tai_Khoan)
            {
                MessageBox.Show("Bạn không thể xóa bản thân");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa tài khoản", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (!TaiKhoanDAO.Instance.TestNhamVien(taikhoan))
                {
                    if (TaiKhoanDAO.Instance.DeleteNhanVien(taikhoan))
                    {
                        MessageBox.Show("Xóa tài khoản thành công");
                        LoadDSNhanVien();
                        dataGridView_TK.Update();
                        dataGridView_TK.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("Xảy ra lỗi khi xóa tài khoản");
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên đã có trong hóa đơn không thể xóa");
                }
            }
        }

        private void button_TimTK_Click(object sender, EventArgs e)
        {
            string tenTK = textBox_TimTK.Text;
            dataGridView_TK.DataSource = TaiKhoanDAO.Instance.DanhsachTaiKhoan(tenTK);
        }

        private void button_huytimTK_Click(object sender, EventArgs e)
        {
            dataGridView_TK.DataSource = TaiKhoanDAO.Instance.DanhsachTaiKhoan();
        }

        private void button_ThemPNhap_Click(object sender, EventArgs e)
        {
            CT_PhieuNhap ctpn = new CT_PhieuNhap("0", "", tkDangNhap);
            ctpn.FormClosed += DongFromPN;
            ctpn.ShowDialog();
        }

        private void button_XemPNhap_Click(object sender, EventArgs e)
        {
            int id = dataGridView_NhapKho.CurrentCell.RowIndex;
            string maphieu = dataGridView_NhapKho.Rows[id].Cells[0].Value.ToString();
            CT_PhieuNhap ct = new CT_PhieuNhap("3", maphieu, tkDangNhap);
            ct.ShowDialog();
        }

        private void button_TimPNhap_Click(object sender, EventArgs e)
        {
            string maPN = textBox_MaPNhap.Text;
            string ngayBD = dateTimePicker_BDNhap.Value.ToString("yyyy-MM-dd");
            string ngayKT = dateTimePicker_KTNhap.Value.ToString("yyyy-MM-dd");
            dataGridView_NhapKho.AutoGenerateColumns = false;
            DS_PhieuNhap.DataSource = PhieuNhapDAO.Instance.DanhSachPhieuNhap(maPN, ngayBD, ngayKT);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao Tác";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.DisplayIndex = 7;
            btn.UseColumnTextForButtonValue = true;
            int columnIndex = 7;
            if (dataGridView_NhapKho.Columns["btn"] == null)
            {
                dataGridView_NhapKho.Columns.Insert(columnIndex, btn);
            }
        }

        private void dataGridView_NhapKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string id = dataGridView_NhapKho.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string idd = dataGridView_NhapKho.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (id == "Chưa Duyệt")
                {
                    if (MessageBox.Show("Xác nhận có muốn duyệt phiếu nhập", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (PhieuNhapDAO.Instance.Comfirm_PhieuNhap(idd, "nhap"))
                        {
                            MessageBox.Show("Duyệt thành công");
                            LoadDSPhieuNhap();
                            dataGridView_NhapKho.Update();
                            dataGridView_NhapKho.Refresh();

                            LoadDSSach();
                            dataGridView_Sach.Update();
                            dataGridView_Sach.Refresh();

                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi xác nhận");
                        }
                    }
                }
                if (id == "Đã Duyệt")
                {
                    if (MessageBox.Show("Xác nhận muốn bỏ duyệt phiếu", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (PhieuNhapDAO.Instance.Comfirm_PhieuNhap(idd, "huy"))
                        {
                            MessageBox.Show("Bỏ xác nhận phiếu nhập thành công");
                            LoadDSPhieuNhap();
                            dataGridView_NhapKho.Update();
                            dataGridView_NhapKho.Refresh();

                            LoadDSSach();
                            dataGridView_Sach.Update();
                            dataGridView_Sach.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi hủy duyệt phiếu nhập");
                        }
                    }
                }


            }
            if (e.ColumnIndex == 7)
            {
                string trangThai = dataGridView_NhapKho.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (trangThai == "Đã Duyệt")
                {
                    MessageBox.Show("Phiếu nhập hàng đã duyệt không thể xóa phiếu");
                }
                else
                {
                    if (MessageBox.Show("Xác nhận xóa phiếu", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string maPN = dataGridView_NhapKho.Rows[e.RowIndex].Cells[0].Value.ToString();
                        if (PhieuNhapDAO.Instance.deletePhieuNhap(maPN))
                        {
                            MessageBox.Show("Xóa phiếu nhập thành công");
                            LoadDSPhieuNhap();
                            dataGridView_NhapKho.Update();
                            dataGridView_NhapKho.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi xóa phiếu nhập");
                        }
                    }
                }
            }
        }

        private void button_HuyPNhap_Click(object sender, EventArgs e)
        {
            dataGridView_NhapKho.AutoGenerateColumns = false;
            DS_PhieuNhap.DataSource = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Tác vụ";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.DisplayIndex = 7;
            btn.UseColumnTextForButtonValue = true;
            int columnIndex = 7;
            if (dataGridView_NhapKho.Columns["btn"] == null)
            {
                dataGridView_NhapKho.Columns.Insert(columnIndex, btn);
            }
        }

        private void textBox_TongTien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

