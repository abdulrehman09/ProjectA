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
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection s = new SqlConnection(DBConnection.Conn);
            s.Open();
            
            string q = "Insert into Project (Title, Description) " +
                "Values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
            SqlCommand sqlCommand = new SqlCommand(q, s);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
