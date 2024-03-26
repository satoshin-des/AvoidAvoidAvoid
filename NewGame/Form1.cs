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
    public partial class Form1 : Form
    {
        Player player;
        Enemy enemy;

        public Form1()
        {
            InitializeComponent();

            this.player = new Player(10, 10);

            // 位置と半径
            this.enemy = new Enemy(10, 10, (float)-3.0, (float)-3.0, 10);

            Timer timer = new Timer();
            timer.Interval = 17; // 約60fps
            timer.Tick += new EventHandler(Move1);
            timer.Start();
        }

        private void KeyDowned(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.player.X += 10;
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.player.X -= 10;
            }
            else if(e.KeyCode == Keys.Up)
            {
                this.player.Y -= 10;
            }else if(e.KeyCode == Keys.Down)
            {
                this.player.Y += 10;
            }
        }

        // =============
        // 敵弾の挙動
        // =============
        private void Move1(object sender, EventArgs e)
        {
            this.enemy.X += this.enemy.SpdX;
            this.enemy.Y += this.enemy.SpdY;

            // 左右でバウンド
            if (this.enemy.X + 2 * this.enemy.R > this.Bounds.Width || this.enemy.X - this.enemy.R < 0)
            {
                this.enemy.SpdX = Math.Min((float)-1.01 * this.enemy.SpdX, (float)10.0);
            }

            // 上下でバウンド
            if (this.enemy.Y + 4 * this.enemy.R > this.Bounds.Height || this.enemy.Y - this.enemy.R < 0)
            {
                this.enemy.SpdY = Math.Min((float)-1.01 * this.enemy.SpdY, (float)10.0);
            }

            // 再描画
            Invalidate();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.HotPink);
            SolidBrush grayBrush = new SolidBrush(Color.DimGray);

            e.Graphics.FillEllipse(brush, this.enemy.X, this.enemy.Y, this.enemy.R, this.enemy.R);
            e.Graphics.FillEllipse(grayBrush, this.player.X, this.player.Y, 10, 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
