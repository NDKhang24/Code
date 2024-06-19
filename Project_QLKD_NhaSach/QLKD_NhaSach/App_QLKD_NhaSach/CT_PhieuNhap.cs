using App_QLKD_NhaSach.DAO;
using App_QLKD_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace App_QLKD_NhaSach
{
    public partial class CT_PhieuNhap : Form
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


        string check = "0";
        string id = "0";
        public CT_PhieuNhap(string edit, string ids, TaiKhoan tk)
        {
            check = edit;
            id = ids;
            this.tkDangNhap = tk;
            InitializeComponent();
        }
        List<CT_PhieuNhapSach> lists = new List<CT_PhieuNhapSach>();
        Sach sach;
        int idsp = 1;
        void LoadF()
        {
            textBox_NVnhap.Text = tkDangNhap.Tai_Khoan;
            BindingSource source = new BindingSource();
            source.DataSource = lists;
            dataGridView_CTPN.DataSource = source;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao tác";
            btn.Text = "Xóa";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            int columnIndex = 0;
            if (dataGridView_CTPN.Columns["btn"] == null)
            {
                dataGridView_CTPN.Columns.Insert(columnIndex, btn);
            }
            dataGridView_CTPN.Refresh();

        }
        private void LoadDSS()
        {
            List<Sach> s = new List<Sach>();
            s = SachDAO.Instance.DanhSachSach();
            foreach (var item in s)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(item.MaSach);
                lvi.SubItems.Add(item.TenSach);
                lvi.SubItems.Add(item.TheLoai);
                listView_Sach.Items.Add(lvi);
            }
        }
        private void CT_PhieuNhap_Load(object sender, EventArgs e)
        {
            listView_Sach.View = View.Details;
            listView_Sach.Columns.Add("",0);
            listView_Sach.Columns.Add("Ma_Sach", 100);
            listView_Sach.Columns.Add("Ten Sach", 100);
            listView_Sach.FullRowSelect = true;
            if (check == "3")
            {
                listView_Sach.Enabled = false;
                button_luuPN.Enabled = false;
            }
            LoadDSS();
            if (check == "3")
            {
                PhieuNhap phieuNhap = PhieuNhapDAO.Instance.PhieuNhap_ID(id);
                if (phieuNhap == null)
                {
                    MessageBox.Show("Phieu nhap khong ton tai");
                    this.Close();
                }
                else
                {
                    lists = PhieuNhapDAO.Instance.CTPhieuNhap_ID(id);
                }
            }
            LoadF();
        }

        private void button_thoatPN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ThemS_Click(object sender, EventArgs e)
        {
            if (textBox_giaS.Text == "" || textBox_slS.Text == "" || listView_Sach.SelectedItems.Count == 0)
            {
                MessageBox.Show("Cần thêm số lượng hoặc giá nhập và sách");

            }
            else
            {
                String chonSach = listView_Sach.SelectedItems[0].SubItems[1].Text;
                sach = SachDAO.Instance.SachByMa_Sach(chonSach);
                if (sach != null)
                {
                    CT_PhieuNhapSach pn = new CT_PhieuNhapSach(idsp, sach.MaSach, sach.TenSach, int.Parse(textBox_slS.Text), int.Parse(textBox_giaS.Text), (int.Parse(textBox_slS.Text) * int.Parse(textBox_giaS.Text)));
                    textBox_giaS.Text = "";
                    textBox_slS.Text = "";
                    lists.Add(pn);
                    LoadF();
                    idsp++;
                }
            }
        }

        private void button_luuPN_Click(object sender, EventArgs e)
        {

            if (PhieuNhapDAO.Instance.InsertPhieuNhap(lists, TkDangNhap.Tai_Khoan, textBox_nhapNCC.Text, textBox_nhapKho.Text ))
            {
                MessageBox.Show("Thêm nhập hàng thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhập hàng");
            }
        }
    }
}
