using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanCaPhaKaFa
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from NguoiDung where TaiKhoan = '{0}' and MatKhau = '{1}'", txtTaiKhoan.Text, txtMatKhau.Text);
            DataSet ds = kn.LayDuLieu(query, "NguoiDung");
            if (ds.Tables["NguoiDung"].Rows.Count == 1)
            {
                MessageBox.Show("Đăng Nhập Thành Công");
                frmHeThong frm = new frmHeThong();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Thất Bai");
            }
        }
    }
}
