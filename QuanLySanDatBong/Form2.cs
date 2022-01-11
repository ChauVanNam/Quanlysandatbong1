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

namespace QuanLySanDatBong
{
    public partial class Form2 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPCN-DUYHN\DUYSQLSERVER;Initial Catalog=QLDatSanBongDa;User ID=sa;Password=123";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select MaSuat, HoTenKhachHang, SoDienThoai, GiaTien, NgaySuDung, SuatDa, DiaChiSanBong from SanBong inner join SuatDatBong on SuatDatBong.MaSanBong = SanBong.MaSanBong";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            string sql = "select * from SanBong";
            cbDiaChi.DataSource = Database.Singleton.loadCB(sql);
            cbDiaChi.DisplayMember = "DiaChiSanBong";
            cbDiaChi.ValueMember = "MaSanBong";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSuat.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaSuat.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtKhach.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSoDT.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtGiaTien.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimeSD.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtSuatDa.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cbDiaChi.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtGiaTien.Text != "" && txtKhach.Text != "" && txtMaSuat.Text != "" && txtSoDT.Text != "" && txtSuatDa.Text != "" && cbDiaChi.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into SuatDatBong values ('" + txtMaSuat.Text + "', N'" + txtKhach.Text + "','" + txtSoDT.Text + "','" + txtGiaTien.Text + "', '" + dateTimeSD.Text + "', N'" + txtSuatDa.Text + "', N'" + Convert.ToString(cbDiaChi.SelectedValue) + "')";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Thêm suất bóng thành công", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from SuatDatBong where MaSuat = '" + txtMaSuat.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Xóa thành công", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtGiaTien.Text != "" && txtKhach.Text != "" && txtMaSuat.Text != "" && txtSoDT.Text != "" && txtSuatDa.Text != "" && cbDiaChi.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update SuatDatBong set HoTenKhachHang = N'" + txtKhach.Text + "',SoDienThoai ='" + txtSoDT.Text + "',GiaTien ='" + txtGiaTien.Text + "',NgaySuDung ='" + dateTimeSD.Text + "',SuatDa = N'" + txtSuatDa.Text + "',MaSanBong = N'" + Convert.ToString(cbDiaChi.SelectedValue) + "' where MaSuat = '" + txtMaSuat.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã cập nhật", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thiếu thông tin\n Yêu cầu nhập đầy đủ", "Thông báo");
            }
        }
    }
}
