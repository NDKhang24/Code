using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TH_6_10
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string chuoiKN = "Data Source=KHANG;Initial Catalog=QLThuVien;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection ketNoi;
        SqlDataAdapter boDocghi;
        void ketNoiCSDL()
        {
            chuoiKN =
                global::TH_6_10.Properties.Settings.Default.QLThuVienConnectionString;
            ketNoi = new SqlConnection(chuoiKN);
            //ketNoi = new SqlConnection(chuoiKN);
        }
        DataTable layDanhSachNhanVien()
        {
            string chuoiLenh = "select * from NhanVien";
            boDocghi = new SqlDataAdapter(chuoiLenh, chuoiKN);
            DataTable bangNhanVien = new DataTable("NhanVien");
            boDocghi.Fill(bangNhanVien);
            return bangNhanVien;
        }
        void LoadListview()
        {
            listView1.Clear();
            listView1.Columns.Add("Mã Nhân Viên");
            listView1.Columns.Add("Họ Tên");
            listView1.Columns.Add("Ngày Sinh");
            listView1.Columns.Add("Địa Chỉ");
            listView1.Columns.Add("Điện Thoại");
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;


            DataTable bangNhanVien = layDanhSachNhanVien();
            for(int i = 0; i < bangNhanVien.Rows.Count; i++)
            {
                ListViewItem lvi=
                listView1.Items.Add(bangNhanVien.Rows[i]["MaNhanVien"].ToString());
                lvi.SubItems.Add(bangNhanVien.Rows[i][1].ToString());
                lvi.SubItems.Add(DateTime.Parse(bangNhanVien.Rows[i][2].ToString()).ToShortDateString());
                lvi.SubItems.Add(bangNhanVien.Rows[i][3].ToString());
                lvi.SubItems.Add(bangNhanVien.Rows[i][4].ToString());
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO NhanVien (Manhanvien, Hoten, Ngaysinh, Diachi, Dienthoai) VALUES (@Manhanvien, @Hoten, @Ngaysinh, @Diachi, @Dienthoai)";

            SqlCommand cmd = new SqlCommand(sql, ketNoi);
            cmd.Parameters.AddWithValue("@Manhanvien", txtMaNhanVien.Text);
            cmd.Parameters.AddWithValue("@Hoten", txtHoTen.Text);
            cmd.Parameters.AddWithValue("@Ngaysinh", dtpNgaySinh.Value);
            cmd.Parameters.AddWithValue("@Diachi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("@Dienthoai", txtDT.Text);

            ketNoi.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadListview();

            ketNoi.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ketNoiCSDL();
            LoadListview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string maNhanVien = listView1.SelectedItems[0].SubItems[0].Text;
                string sql = "UPDATE NhanVien SET Hoten = @Hoten, Ngaysinh = @Ngaysinh, Diachi = @Diachi, Dienthoai = @Dienthoai WHERE Manhanvien = @Manhanvien";

                SqlCommand cmd = new SqlCommand(sql, ketNoi);
                cmd.Parameters.AddWithValue("@Manhanvien", maNhanVien);
                cmd.Parameters.AddWithValue("@Hoten", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@Ngaysinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@Diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Dienthoai", txtDT.Text);

                ketNoi.Open();
                cmd.ExecuteNonQuery();
                ketNoi.Close();

                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadListview();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ResetInputControls()
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtDT.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string maNhanVien = listView1.SelectedItems[0].SubItems[0].Text;

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE FROM NhanVien WHERE Manhanvien = @Manhanvien";

                    SqlCommand cmd = new SqlCommand(sql, ketNoi);
                    cmd.Parameters.AddWithValue("@Manhanvien", maNhanVien);

                    ketNoi.Open();
                    cmd.ExecuteNonQuery();
                    ketNoi.Close();

                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadListview();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
