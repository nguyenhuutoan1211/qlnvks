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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
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
            string query = "select * from NhanVien";
            DataSet ds = kn.LayDuLieu(query, "NhanVien");
            dgvNhanVien.DataSource = ds.Tables["NhanVien"];
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void clearData()
        {
            txtIDNhanVien.Text = "";
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            txtGioiTinh.Text = "";
            txtNgaySinh.Text = "";
            txtNgayVaoLam.Text = "";
            txtIDChucVu.Text = "";



            txtIDNhanVien.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTaoMoi.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into NhanVien(IdNhanVien,HoTenNhanVien,SoDienThoai,GioiTinh,NgaySinh,NgayVaolam,IdChucVu)Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
    txtIDNhanVien.Text, txtHoTen.Text, txtSoDienThoai.Text,txtGioiTinh.Text, txtNgaySinh.Text, txtNgayVaoLam.Text,txtIDChucVu.Text);
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
            string query = string.Format("update NhanVien set HoTenNhanVien='{1}',SoDienThoai='{2}',GioiTinh='{3}',NgaySinh='{4}',NgayVaolam='{5}',IdChucVu='{6}'  Where IDNhanVien='{0}'",
    txtIDNhanVien.Text, txtHoTen.Text, txtSoDienThoai.Text, txtGioiTinh.Text, txtNgaySinh.Text, txtNgayVaoLam.Text, txtIDChucVu.Text);

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
            string query = string.Format("delete from NhanVien where IdNhanVien = '{0}'", txtIDNhanVien.Text);
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
            string query = string.Format("select * from NhanVien where HoTenNhanVien like '%{0}%'", txtTimKiem.Text);
            DataSet ds = kn.LayDuLieu(query, "NhanVien");
            dgvNhanVien.DataSource = ds.Tables["NhanVien"];
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtIDNhanVien.Text = dgvNhanVien.Rows[row].Cells["IdNhanVien"].Value.ToString();
                txtHoTen.Text = dgvNhanVien.Rows[row].Cells["HoTenNhanVien"].Value.ToString();
                txtSoDienThoai.Text = dgvNhanVien.Rows[row].Cells["SoDienThoai"].Value.ToString();
                txtGioiTinh.Text = dgvNhanVien.Rows[row].Cells["GioiTinh"].Value.ToString();
                txtNgaySinh.Text = dgvNhanVien.Rows[row].Cells["NgaySinh"].Value.ToString();
                txtNgayVaoLam.Text = dgvNhanVien.Rows[row].Cells["NgayVaoLam"].Value.ToString();
                txtIDChucVu.Text = dgvNhanVien.Rows[row].Cells["IdChucVu"].Value.ToString();


                txtIDNhanVien.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnTaoMoi.Enabled = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
