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
    public partial class AvoidAvoidAvoid : Form
    {

        public static OpeningScreenCtr opening;
        public static PlayScreenCtr play1;
        public static StagePrintScreenCtr stage;
        public static ResultCtr result;
        public static EndingScreenCtr ending;

        public static int Stage = 1;
        public AvoidAvoidAvoid()
        {
            InitializeComponent();

            opening = new OpeningScreenCtr();
            play1 = new PlayScreenCtr();
            stage = new StagePrintScreenCtr();
            result = new ResultCtr();
            ending = new EndingScreenCtr();

            // パネルにコントロールを追加
            panel1.Controls.Add(opening);
            panel1.Controls.Add(play1);
            panel1.Controls.Add(stage);
            panel1.Controls.Add(result);
            panel1.Controls.Add(ending);

            opening.Visible = true;
            play1.Visible = false;
            stage.Visible = false;
            result .Visible = false;
            ending.Visible = false;
        }

        private void MainGameForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
