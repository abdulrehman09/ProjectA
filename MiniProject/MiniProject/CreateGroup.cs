using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MiniProject
{
    public partial class CreateGroup : Form
    {
        public CreateGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> students = new List<string>();
            SqlConnection s = new SqlConnection(DBConnection.Conn);
            s.Open();

            string q = "Select * from Student where RegistrationNo = '" + textBox1.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(q, s);
            SqlDataReader r = sqlCommand.ExecuteReader();
            if (r.Read())
            {
                string id = r["Id"].ToString();
                students.Add(id);
            }
            foreach (string st in students)
            {
                dataGridView1.Rows.Add(st);
            }
        }
    }
}
