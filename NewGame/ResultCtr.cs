using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGame
{
    public partial class ResultCtr : UserControl
    {
        public ResultCtr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AvoidAvoidAvoid.play1.Visible = true;
            AvoidAvoidAvoid.opening.Visible = false;
            AvoidAvoidAvoid.stage.Visible = false;
            AvoidAvoidAvoid.result.Visible = false;
            AvoidAvoidAvoid.ending.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
