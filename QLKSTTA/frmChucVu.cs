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
    public partial class frmChucVu : Form
    {
        public frmChucVu()
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
            string query = "select * from ChucVu";
            DataSet ds = kn.LayDuLieu(query, "ChucVu");
            dgvChucVu.DataSource = ds.Tables["ChucVu"];
        }
        public void clearData()
        {
            txtIDChucVu.Text = "";
            txtTenChucVu.Text = "";




            txtIDChucVu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void frmChucVu_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into ChucVu(IdChucVu,TenChucVu)Values('{0}','{1}')",
txtIDChucVu.Text, txtTenChucVu.Text);
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
            string query = string.Format("update ChucVu set TenChucVu = '{1}' where IdChucVu = '{0}'",
txtIDChucVu.Text, txtTenChucVu.Text);
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
            string query = string.Format("delete from ChucVu where IdChucVu = '{0}'", txtIDChucVu.Text);
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
            string query = string.Format("select * from ChucVu where TenChucVu like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "ChucVu");
            dgvChucVu.DataSource = ds.Tables["ChucVu"];
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtIDChucVu.Text = dgvChucVu.Rows[row].Cells["IdChucVu"].Value.ToString();
                txtTenChucVu.Text = dgvChucVu.Rows[row].Cells["TenChucVu"].Value.ToString();


                txtIDChucVu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                btnTaoMoi.Enabled = true;
            }
        }
    }
}
