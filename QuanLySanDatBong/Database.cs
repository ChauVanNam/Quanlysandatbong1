using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanDatBong
{
    class Database
    {
        private SqlConnection connect;
        private SqlCommandBuilder cmd;
        string str = @"Data Source=LAPCN-DUYHN\DUYSQLSERVER;Initial Catalog=QLDatSanBongDa;User ID=sa;Password=123";
        
        SqlDataAdapter adapter = new SqlDataAdapter();
        private static Database singleton = null;



        public static Database Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new Database();
                }
                return singleton;
            }
        }
        private Database()
        {
            this.connect = new SqlConnection(str);
        }
        ComboBox cb = new ComboBox();
        public DataTable loadCB(string sql)
        {
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(sql, this.connect);
            adapter.Fill(table);
            return table;
        }
    }
}
