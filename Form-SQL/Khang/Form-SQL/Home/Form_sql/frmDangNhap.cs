using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form_sql
{
    public partial class DangNhap : Form
    {
        private DangKy DangKy;
        string connectionString = "Data Source=KHANG;Initial Catalog=StudentDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public bool isLoggedIn { get; private set; } = false;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DangKy != null && !DangKy.IsDisposed)
            {
                DangKy.Close();
            }
            else
            {
                DangKy = new DangKy();
                DangKy.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox1.Text;

            // Kiểm tra thông tin đăng nhập
            if (CheckLogin(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!");
                isLoggedIn = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.");
                isLoggedIn = false;
            }
        }

        private bool CheckLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
        }
    }
}
