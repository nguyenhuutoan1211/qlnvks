using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanCaPhaKaFa
{
    internal class KetNoi
    {
        private string con_str = "Data Source=DESKTOP-O03B34K;Initial Catalog=QLKSTMA;Integrated Security=True";

        public DataSet LayDuLieu(string query, string table_name)
        {
            try
            {
                //B1: Tạo Kết Nối Đến Cơ Sở Dữ Liệu
                SqlConnection conn = new SqlConnection(con_str);
                //B2: Tạo Ra SqlDataadapter
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //B3: Tạo DataSet Để chứa dữ liệu đổ về từ query
                DataSet ds = new DataSet();
                //B4: Đổ dữ liệu và DataSet thông qua fill()
                da.Fill(ds, table_name);
                return ds;

            }
            catch
            {
            }
            return null;
        }



        public bool ThucThi(string query)
        {
            try
            {
                //B1: Tạo Kết Nối Đến CSDL
                SqlConnection conn = new SqlConnection(con_str);
                //B2: Mở Kết Nối
                conn.Open();
                //B3: Tạo Đối Tượng Thực Thi Truy Vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                //B4: Thực Thi Truy Vấn
                int soluong = cmd.ExecuteNonQuery();
                //B5: Đóng Kết Nối
                conn.Close();
                return soluong > 0;

            }
            catch
            {
            }

            return false;
        }
    }
}
