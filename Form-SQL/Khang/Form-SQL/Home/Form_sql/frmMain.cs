using System;
using System.Windows.Forms;

namespace Form_sql
{
    public partial class frmMain : Form
    {
        private DangNhap DangNhap;
        private DangKy DangKy;
        private DoiMatKhau DoiMatKhau;
        public static bool isLoggedIn = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Disable all function buttons initially
            DisableFunctionButtons();

            // Show login form
            DangNhap = new DangNhap();
            DangNhap.FormClosed += DangNhap_FormClosed;
            DangNhap.ShowDialog();
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            isLoggedIn = DangNhap.isLoggedIn;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (isLoggedIn)
            {
                EnableFunctionButtons();
            }
            else
            {
                DisableFunctionButtons();
            }
        }

        private void EnableFunctionButtons()
        {
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            thôngTinSinhViênToolStripMenuItem.Enabled = true;
            danhMụcKhoaToolStripMenuItem.Enabled = true;
            danhMụcMônHọcToolStripMenuItem.Enabled = true;
            nhậpĐiểmToolStripMenuItem.Enabled = true;
            xemĐiểmToolStripMenuItem.Enabled = true;
            thốngKêKhoaToolStripMenuItem.Enabled = true;
        }

        private void DisableFunctionButtons()
        {
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            toolStripButton6.Enabled = false;
            thôngTinSinhViênToolStripMenuItem.Enabled = false;
            danhMụcKhoaToolStripMenuItem.Enabled = false;
            danhMụcMônHọcToolStripMenuItem.Enabled = false;
            nhậpĐiểmToolStripMenuItem.Enabled = false;
            xemĐiểmToolStripMenuItem.Enabled = false;
            thốngKêKhoaToolStripMenuItem.Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            SinhVien nd = new SinhVien { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            SinhVien nd = new SinhVien { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            Khoa nd = new Khoa { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void danhMụcKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            Khoa nd = new Khoa { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            MonHoc nd = new MonHoc { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void danhMụcMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            MonHoc nd = new MonHoc { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            NhapDiem nd = new NhapDiem { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void nhậpĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            NhapDiem nd = new NhapDiem { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            XemDiem nd = new XemDiem { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void xemĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            XemDiem nd = new XemDiem { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            ThongKeSvTheoKhoa nd = new ThongKeSvTheoKhoa { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void thốngKêKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllMdiChildren();
            ThongKeSvTheoKhoa nd = new ThongKeSvTheoKhoa { MdiParent = this, StartPosition = FormStartPosition.Manual };
            nd.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DangKy != null && !DangKy.IsDisposed)
            {
                DangKy.Close();
            }

            if (DangNhap == null || DangNhap.IsDisposed)
            {
                DangNhap = new DangNhap();
                DangNhap.FormClosed += new FormClosedEventHandler(DangNhap_FormClosed);
                DangNhap.Show();
            }
            else
            {
                DangNhap.BringToFront();
            }
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DangNhap != null && !DangNhap.IsDisposed)
            {
                DangNhap.Close();
            }

            if (DangKy == null || DangKy.IsDisposed)
            {
                DangKy = new DangKy();
                DangKy.Show();
            }
            else
            {
                DangKy.BringToFront();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (DangNhap != null && !DangNhap.IsDisposed)
            {
                DangNhap.Close();
            }

            if (DangKy != null && !DangKy.IsDisposed)
            {
                DangKy.Close();
            }

            if (DoiMatKhau == null || DoiMatKhau.IsDisposed)
            {
                DoiMatKhau = new DoiMatKhau();
                DoiMatKhau.ShowDialog();
            }
            else
            {
                DoiMatKhau.BringToFront();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isLoggedIn = false;
                UpdateUI();
                DangNhap = new DangNhap();
                DangNhap.FormClosed += DangNhap_FormClosed;
                DangNhap.ShowDialog();
            }
        }

        private void CloseAllMdiChildren()
        {
            foreach (var f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
