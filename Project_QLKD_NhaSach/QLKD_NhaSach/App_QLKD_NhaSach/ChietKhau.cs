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
    public partial class ChietKhau : Form
    {
        public ChietKhau()
        {
            InitializeComponent();
        }
        private void button1_xnChietKhau_Click(object sender, EventArgs e)
        {
            KhuyenMai.discount = Int32.Parse(textBox_phantram.Text);
            this.Close();
        }

        private void textBox_phantram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            int number;
            if (int.TryParse(textBox_phantram.Text, out number))
            {
                if (number <= 10)
                {
                    //in range
                }
                else
                {
                    textBox_phantram.Text = "";
                }
            }
        }

        private void textBox_phantram_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChietKhau_Load(object sender, EventArgs e)
        {
            textBox_phantram.Text = KhuyenMai.discount.ToString();
        }
    }
}
