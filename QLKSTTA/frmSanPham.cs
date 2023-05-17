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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
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
            string query = "select * from Phong";
            DataSet ds = kn.LayDuLieu(query, "Phong");
            dgvSanPham.DataSource = ds.Tables["Phong"];
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            getData();
        }

        public void clearData()
        {
            txtIDSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtSoLuong.Text = "";
            txtGiaBan.Text = "";
            txtIDLoaiSP.Text = "";
            txtIDNhanVien.Text = "";
            txtMoTa.Text = "";



            txtIDSanPham.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into Phong(IdPhong,TenPhong,SoLuong,Gia,IdLoaiPhong,IdNhanVien, MoTa)Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
txtIDSanPham.Text, txtTenSanPham.Text, txtSoLuong.Text, txtGiaBan.Text, txtIDLoaiSP.Text, txtIDNhanVien.Text, txtMoTa.Text);
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
            string query = string.Format("update Phong set TenPhong = '{1}', SoLuong = '{2}' , Gia = '{3}', IdLoaiPhong = '{4}', IdNhanVien = '{5}', MoTa = '{6}' where IdPhong = '{0}'",
txtIDSanPham.Text, txtTenSanPham.Text, txtSoLuong.Text, txtGiaBan.Text, txtIDLoaiSP.Text, txtIDNhanVien.Text, txtMoTa.Text);
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
            string query = string.Format("delete from Phong where IdPhong = '{0}'", txtIDSanPham.Text);
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
            string query = string.Format("select * from Phong where TenPhong like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "Phong");
            dgvSanPham.DataSource = ds.Tables["Phong"];
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtIDSanPham.Text = dgvSanPham.Rows[row].Cells["IDPhong"].Value.ToString();
                txtTenSanPham.Text = dgvSanPham.Rows[row].Cells["TenPhong"].Value.ToString();
                txtSoLuong.Text = dgvSanPham.Rows[row].Cells["SoLuong"].Value.ToString();
                txtGiaBan.Text = dgvSanPham.Rows[row].Cells["Gia"].Value.ToString();
                txtIDLoaiSP.Text = dgvSanPham.Rows[row].Cells["IdLoaiPhong"].Value.ToString();
                txtIDNhanVien.Text = dgvSanPham.Rows[row].Cells["IdNhanVien"].Value.ToString();
                txtMoTa.Text = dgvSanPham.Rows[row].Cells["Mota"].Value.ToString();


                txtIDSanPham.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                btnTaoMoi.Enabled = true;
            }
        }
    }
}
