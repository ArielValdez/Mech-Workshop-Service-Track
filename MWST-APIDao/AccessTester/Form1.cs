using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace AccessTester
{
    public partial class Form1 : Form
    {
        UserModel user;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = user.Test();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user = new UserModel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user.RegisterAUser("0", "0", "0", "0", "0", "00000000000", "C", "0", "0");
            dataGridView1.DataSource = user.Test();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user.DeleteUser(3);
            dataGridView1.DataSource = user.Test();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user.UpdateUser(2, "Ariel", "1234", "0", "Ariel", "Valdez", "0", "C", "", "");
            dataGridView1.DataSource = user.Test();
        }
    }
}
