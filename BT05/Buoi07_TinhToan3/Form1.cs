using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            txtKq.ReadOnly = true;               //ô kết quả chỉ được phép đọc
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Lưu ý", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            //kiểm tra giá trị ô thứ nhất có phải là số không
            bool isNumber1 = decimal.TryParse(txtSo1.Text, out decimal n1);
            //kiểm tra giá trị ô thứ hai có phải là số không
            bool isNumber2 = decimal.TryParse(txtSo2.Text, out decimal n2);

            if (txtSo1.Text == "")
            {
                dr = MessageBox.Show("Số thứ nhất không được phép để trống", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Select();
                }
            }

            else if (txtSo2.Text == "")
            {
                dr = MessageBox.Show("Số thứ hai không được phép để trống", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Select();
                }
            }
            else if (!isNumber1)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Clear();
                    txtSo1.Select();
                }
            }

            else if (!isNumber2)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }

            else if (radChia.Checked && txtSo2.Text == "0")
            {
                dr = MessageBox.Show("Vui lòng nhập số thứ hai khác 0", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }
            else
            {
                //lấy giá trị của 2 ô số
                decimal so1, so2, kq = 0;

                so1 = decimal.Parse(txtSo1.Text);
                so2 = decimal.Parse(txtSo2.Text);

                //Thực hiện phép tính dựa vào phép toán được chọn
                if (radCong.Checked) kq = so1 + so2;
                else if (radTru.Checked) kq = so1 - so2;
                else if (radNhan.Checked) kq = so1 * so2;
                else if (radChia.Checked) kq = so1 / so2;

                //Hiển thị kết quả lên trên ô kết quả
                txtKq.Text = kq.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            DialogResult dr;

            if (txtSo1.Text == "")
            {
                dr = MessageBox.Show("Số thứ nhất không được phép để trống", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Select();
                }
            }

            else if (txtSo2.Text == "")
            {
                dr = MessageBox.Show("Số thứ hai không được phép để trống", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Select();
                }
            }
        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            bool isNumber = decimal.TryParse(txtSo2.Text, out decimal n);

            if (txtSo2.Text == "")
            {
                dr = MessageBox.Show("Số thứ hai không được phép để trống", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Select();
                }
            }

            else if (!isNumber)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }

            else txtSo1.SelectAll();
        }

        private void txtSo2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            bool isNumber = decimal.TryParse(txtSo1.Text, out decimal n);

            if (txtSo1.Text == "")
            {
                dr = MessageBox.Show("Số thứ nhất không được phép để trống", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Select();
                }
            }

            else if (!isNumber)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Clear();
                    txtSo1.Select();
                }
            }
            else txtSo2.SelectAll();
        }


        private void radCong_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            bool isNumber1 = decimal.TryParse(txtSo1.Text, out decimal n1);
            bool isNumber2 = decimal.TryParse(txtSo2.Text, out decimal n2);
            if (!isNumber1)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Clear();
                    txtSo1.Select();
                }
            }

            else if (!isNumber2)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }
        }

        private void radTru_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            bool isNumber1 = decimal.TryParse(txtSo1.Text, out decimal n1);
            bool isNumber2 = decimal.TryParse(txtSo2.Text, out decimal n2);
            if (!isNumber1)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Clear();
                    txtSo1.Select();
                }
            }

            else if (!isNumber2)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }
        }

        private void radNhan_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            bool isNumber1 = decimal.TryParse(txtSo1.Text, out decimal n1);
            bool isNumber2 = decimal.TryParse(txtSo2.Text, out decimal n2);
            if (!isNumber1)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Clear();
                    txtSo1.Select();
                }
            }

            else if (!isNumber2)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }
        }

        private void radChia_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            bool isNumber1 = decimal.TryParse(txtSo1.Text, out decimal n1);
            bool isNumber2 = decimal.TryParse(txtSo2.Text, out decimal n2);
            if (!isNumber1)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo1.Clear();
                    txtSo1.Select();
                }
            }

            else if (!isNumber2)
            {
                dr = MessageBox.Show("Vui lòng nhập ký tự là số", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }
            else if (txtSo2.Text == "0")
            {
                dr = MessageBox.Show("Vui lòng nhập số thứ hai khác 0", "Lưu ý", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    txtSo2.Clear();
                    txtSo2.Select();
                }
            }
        }
    }
}
