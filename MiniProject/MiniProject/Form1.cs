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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection s = new SqlConnection(DBConnection.Conn);
            s.Open();
            string dob = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string q = "Insert into Person (FirstName, LastName, Contact, Email, DateOfBirth, Gender) "+ 
                "Values ('"+ textBox1.Text + "', '"+ textBox7.Text +"','"+ textBox3.Text + "','" +textBox2.Text+"','"+dob+
                "',1)";
            SqlCommand sqlCommand = new SqlCommand(q, s);
            sqlCommand.ExecuteNonQuery();
            q = "select @@identity as Id from Person  ";
            sqlCommand = new SqlCommand(q, s);
            SqlDataReader r = sqlCommand.ExecuteReader();
            string id = "0";
            if (r.Read())
            {
                id = (r["Id"].ToString());
            }
            q = "Insert into Student (Id, RegistrationNo) " +
                "Values ("+id+",'" + textBox6.Text+ "')";
            SqlCommand Command = new SqlCommand(q, s);
            Command.ExecuteNonQuery();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Adviser a = new Adviser();
            a.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddProject a = new AddProject();
            a.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateGroup a = new CreateGroup();
            a.Show();
            this.Hide();

        }
    }
}
