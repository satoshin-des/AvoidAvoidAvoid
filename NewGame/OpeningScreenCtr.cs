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
    public partial class OpeningScreenCtr : UserControl
    {
        public OpeningScreenCtr()
        {
            InitializeComponent();
        }

        private void EasyStartBottun_Click(object sender, EventArgs e)
        {
            AvoidAvoidAvoid.opening.Visible = false;
            AvoidAvoidAvoid.play1.Visible = false;
            AvoidAvoidAvoid.stage.Visible = true;
            AvoidAvoidAvoid.result.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
