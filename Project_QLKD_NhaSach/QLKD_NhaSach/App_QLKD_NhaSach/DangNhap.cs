using App_QLKD_NhaSach.DAO;
using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QLKD_NhaSach
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void ButtonDangNhap_Click(object sender, EventArgs e)
        {   
            string tenTaiKhoan = textBoxTaiKhoan.Text;
            string matKhau = textBoxMatKhau.Text;   
            if (DangNhapTK(tenTaiKhoan, matKhau))
            {
                TaiKhoan tk = TaiKhoanDAO.Instance.TaiKhoan_theoTaiKhoan(textBoxTaiKhoan.Text);
                this.Hide();
                PhanMemQuanLy phanMemQuanLy = new PhanMemQuanLy(tk);
                phanMemQuanLy.ShowDialog();     //Dialog chỉ xử lí trên nó khi nào thực hiện xong trên form dialog thì mới thao tác trên form khác
                this.Show();
            }
            else
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác");
        }

        bool DangNhapTK(string tenTaiKhoan, string matKhau)
        {
            return TaiKhoanDAO.Instance.DangNhapTK(tenTaiKhoan, matKhau);
        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình !!!", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) 
            { 
                e.Cancel = true; 
            }
        }
    }
}
