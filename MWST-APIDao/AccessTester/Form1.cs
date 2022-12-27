﻿using System;
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
    }
}
