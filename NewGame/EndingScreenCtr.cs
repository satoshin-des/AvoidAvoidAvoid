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
    public partial class EndingScreenCtr : UserControl
    {
        public EndingScreenCtr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AvoidAvoidAvoid.play1.Visible = false;
            AvoidAvoidAvoid.opening.Visible = true;
            AvoidAvoidAvoid.stage.Visible = false;
            AvoidAvoidAvoid.result.Visible = false;
            AvoidAvoidAvoid.ending.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void EndingScreenCtr_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Properties.Resources.lattice_chan;
        }
    }
}
