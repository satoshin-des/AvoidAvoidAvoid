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
            MainGameForm.play1.Visible = false;
            MainGameForm.opening.Visible = true;
            MainGameForm.stage.Visible = false;
            MainGameForm.result.Visible = false;
            MainGameForm.ending.Visible = false;
        }
    }
}
