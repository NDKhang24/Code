using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_sql
{
    public partial class DangKy : Form
    {
        string connectionString = "Data Source=KHANG;Initial Catalog=StudentDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public DangKy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox1.Text;
            string confirmPassword = textBox3.Text;

            if (CheckRegistration(username) && password == confirmPassword)
            {
                if (RegisterAccount(username, password))
                {
                    MessageBox.Show("Đăng ký thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi đăng ký tài khoản. Vui lòng thử lại sau.");
                }
            }
            else
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp hoặc tên người dùng đã tồn tại. Vui lòng kiểm tra lại thông tin đăng ký.");
            }
        }
        private bool CheckRegistration(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
        }
        private bool RegisterAccount(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@username, @password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
