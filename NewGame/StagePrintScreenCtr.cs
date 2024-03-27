﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace NewGame
{
    public partial class StagePrintScreenCtr : UserControl
    {

        public StagePrintScreenCtr()
        {
            InitializeComponent();
            label1.Text = "Next Stage";
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MainGameForm.play1.Visible = true;
                MainGameForm.opening.Visible = false;
                MainGameForm.stage.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainGameForm.play1.Visible = true;
            MainGameForm.opening.Visible = false;
            MainGameForm.stage.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainGameForm.play1.Visible = true;
            MainGameForm.opening.Visible = false;
            MainGameForm.stage.Visible = false;
        }
    }
}