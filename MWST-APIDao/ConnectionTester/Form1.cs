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
using Domain;

namespace ConnectionTester
{
    public partial class Form1 : Form
    {
        List<string> query;
        UserModel user;
        public Form1()
        {
            InitializeComponent();
        }
        #region
        private void Form1_Load(object sender, EventArgs e)
        {
            user = new UserModel();
            query = new List<string>();
            #region Query selecter
            query.Add("Select");
            query.Add("Insert");
            query.Add("Update");
            query.Add("Delete");
            #endregion

            comboBox1.DataSource = query;
            comboBox1.SelectedItem = "Select";
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == "Select")
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Text = "Default";
                }
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Text = "Default";
                }
                user.LoginUser(textBox1.Text, textBox2.Text);                
            }
            if(comboBox1.Text == "Insert")
            {
                // Do Something
            }
            if(comboBox1.Text == "Update")
            {
                // Do something
            }
            if(comboBox1.Text == "Delete")
            {
                // Do something
            }
        }
    }
}
