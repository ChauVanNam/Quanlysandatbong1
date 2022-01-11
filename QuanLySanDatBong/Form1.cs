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
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPCN-DUYHN\DUYSQLSERVER;Initial Catalog=QLDatSanBongDa;User ID=sa;Password=123";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from SanBong";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSan.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaSan.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtDiaChi.Text!= "" && txtMaSan.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into SanBong values ('" + txtMaSan.Text + "',N'" + txtDiaChi.Text + "')";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Thêm sân bóng thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thiếu thông tin\n Yêu cầu nhập đầy đủ", "Thông báo");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from SanBong where MaSanBong = '" + txtMaSan.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Xóa thành công","Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text != "" && txtMaSan.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update SanBong set DiaChiSanBong = N'" + txtDiaChi.Text + "'where MaSanBong = '" + txtMaSan.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã cập nhật","Thông báo");
            }
            else
            {
                MessageBox.Show("Thiếu thông tin\n Yêu cầu nhập đầy đủ","Thông báo");
            }

        }

        private void btnQlsdb_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}
