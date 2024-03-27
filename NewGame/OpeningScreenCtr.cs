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
            MainGameForm.opening.Visible = false;
            MainGameForm.play1.Visible = false;
            MainGameForm.stage.Visible = true;
        }
    }
}
