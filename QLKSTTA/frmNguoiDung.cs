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
    public partial class frmNguoiDung : Form
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmHeThong frm = new frmHeThong();
            frm.Show();
            this.Hide();
        }
        KetNoi kn = new KetNoi();
        public void getData()
        {
            string query = "select * from NguoiDung";
            DataSet ds = kn.LayDuLieu(query, "NguoiDung");
            dgvNguoiDung.DataSource = ds.Tables["NguoiDung"];
        }
        public void clearData()
        {
            txtIDNguoiDung.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";


            txtIDNguoiDung.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into NguoiDung(Id,TaiKhoan,MatKhau)Values('{0}','{1}','{2}')",
    txtIDNguoiDung.Text, txtTaiKhoan.Text, txtMatKhau.Text);
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Thành Công");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format("update NguoiDung set TaiKhoan = '{1}', MatKhau = '{2}' where Id = '{0}'",
    txtIDNguoiDung.Text, txtTaiKhoan.Text, txtMatKhau.Text);
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa Thành Công");
                getData();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("delete from NguoiDung where Id = '{0}'", txtIDNguoiDung.Text);
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành Công");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại");
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from NguoiDung where TaiKhoan like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "NguoiDung");
            dgvNguoiDung.DataSource = ds.Tables["NguoiDung"];
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtIDNguoiDung.Text = dgvNguoiDung.Rows[row].Cells["Id"].Value.ToString();
                txtTaiKhoan.Text = dgvNguoiDung.Rows[row].Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = dgvNguoiDung.Rows[row].Cells["MatKhau"].Value.ToString();


                txtIDNguoiDung.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                btnTaoMoi.Enabled = true;
            }
        }
    }
}
