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
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
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
            string query = "select * from LoaiPhong";
            DataSet ds = kn.LayDuLieu(query, "LoaiPhong");
            dgvLoaiPhong.DataSource = ds.Tables["LoaiPhong"];
        }

        public void clearData()
        {
            txtIDLoaiSanPham.Text = "";
            txtTenLoaiSP.Text = "";


            txtIDLoaiSanPham.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from LoaiPhong where TenLoaiPhong like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "LoaiPhong");
            dgvLoaiPhong.DataSource = ds.Tables["LoaiPhong"];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into LoaiPhong(IdLoaiPhong,TenLoaiPhong)Values('{0}','{1}')",
    txtIDLoaiSanPham.Text, txtTenLoaiSP.Text);
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
            string query = string.Format("update LoaiPhong set TenLoaiPhong = '{1}' where IdLoaiPhong = '{0}'",
    txtIDLoaiSanPham.Text, txtTenLoaiSP.Text);
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
            string query = string.Format("delete from LoaiPhong where IdLoaiPhong = '{0}'", txtIDLoaiSanPham.Text);
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

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtIDLoaiSanPham.Text = dgvLoaiPhong.Rows[row].Cells["IdLoaiPhong"].Value.ToString();
                txtTenLoaiSP.Text = dgvLoaiPhong.Rows[row].Cells["TenLoaiPhong"].Value.ToString();


                txtIDLoaiSanPham.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                btnTaoMoi.Enabled = true;
            }
        }

     
    }
}
