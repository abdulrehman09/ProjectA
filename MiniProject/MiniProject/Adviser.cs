﻿using System;
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
    public partial class Adviser : Form
    {
        public Adviser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection s = new SqlConnection(DBConnection.Conn);
            s.Open();
            string dob = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string q = "Insert into Person (FirstName, LastName, Contact, Email, DateOfBirth, Gender) " +
                "Values ('" + textBox1.Text + "', '" + textBox7.Text + "','"+textBox3.Text+ "','" + textBox2.Text + "','" + dob +
                "',1 )";
            SqlCommand sqlCommand = new SqlCommand(q, s);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
