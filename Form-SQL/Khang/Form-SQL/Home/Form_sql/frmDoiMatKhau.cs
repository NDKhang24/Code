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
    public partial class DoiMatKhau : Form
    {

        private string connectionString = "Data Source=KHANG;Initial Catalog=StudentDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string oldPassword = textBox2.Text;
            string newPassword = textBox3.Text;
            string confirmPassword = textBox4.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            if (ChangePassword(username, oldPassword, newPassword))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại! Vui lòng kiểm tra lại thông tin.");
            }
        }
        private bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @newPassword WHERE Username = @username AND Password = @oldPassword";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@oldPassword", oldPassword);
                    command.Parameters.AddWithValue("@newPassword", newPassword);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
