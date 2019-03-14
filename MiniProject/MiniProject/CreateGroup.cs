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
        private List<string> Attstudents = new List<string>();
        private List<string> Attstudents_id = new List<string>();

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
                string reg = r["RegistrationNo"].ToString();
                string id = r["Id"].ToString();
                students.Add(reg);
                Attstudents_id.Add(id);
            }
            foreach (string st in students)
            {
                dataGridView1.Rows.Add(st);
            }
            /**********************************/
            Attstudents = students;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection s = new SqlConnection(DBConnection.Conn);
            s.Open();
            string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (s.State == ConnectionState.Open)
            {
                string Insert = "INSERT INTO [dbo].[Group](Created_On) VALUES ('" + sqlFormattedDate + "')";
                SqlCommand cmd = new SqlCommand(Insert, s);
                cmd.ExecuteNonQuery();
            }

            string I = "Select @@identity as id from [Group]";
            SqlCommand cm = new SqlCommand(I, s);

            SqlDataReader reader = cm.ExecuteReader();

            string id = "0";

            if (reader.Read())
            {
                id = (reader["id"].ToString());
                MessageBox.Show(id);
            }

            foreach (string small_s in Attstudents_id)
            {
                string Insert = "Insert into GroupStudent(GroupId, StudentId, Status, AssignmentDate) " +
                    "Values (" + id + "," + small_s.ToString() + ", 3 ,'" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                SqlCommand cmd = new SqlCommand(Insert, s);
                cmd.ExecuteNonQuery();

            }

        }
    } 
}
