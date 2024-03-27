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
        List<Enemy> enemy;
        int NumEnemy;


        public Form1()
        {
            InitializeComponent();

            this.player = new Player(10, 10);

            // 位置と半径
            NumEnemy = 5;
            var rand = new Random();
            this.enemy = new List<Enemy>();
            for(int i = 0; i < NumEnemy; ++i)
            {
                // this.enemy = new Enemy(10, 10, (float)-3.0, (float)-3.0, 10);
                this.enemy.Add(new Enemy(rand.Next(minValue: 10, maxValue: this.Bounds.Width - 10), rand.Next(minValue: 10, maxValue: (this.Bounds.Height - 10) / 2), (float)-3.0, (float)-3.0, 10));
            }

            Timer timer = new Timer();
            timer.Interval = 17; // 約60fps
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }


        // ============
        // 自機の操作
        // ============
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

        
        private void Update(object sender, EventArgs e)
        {
            // =============
            // 敵弾の挙動
            // =============
            for (int i = 0; i < NumEnemy; ++i)
            {
                this.enemy[i].X += this.enemy[i].SpdX;
                this.enemy[i].Y += this.enemy[i].SpdY;

                // 左右でバウンド
                if (this.enemy[i].X + 2 * this.enemy[i].R > this.Bounds.Width || this.enemy[i].X - this.enemy[i].R < 0)
                {
                    this.enemy[i].SpdX = Math.Min((float)-1.01 * this.enemy[i].SpdX, (float)10.0);
                }

                // 上下でバウンド
                if (this.enemy[i].Y + 4 * this.enemy[i].R > this.Bounds.Height || this.enemy[i].Y - this.enemy[i].R < 0)
                {
                    this.enemy[i].SpdY = Math.Min((float)-1.01 * this.enemy[i].SpdY, (float)10.0);
                }
            }
            // 再描画
            Invalidate();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.HotPink);
            SolidBrush grayBrush = new SolidBrush(Color.DimGray);

            for (int i = 0; i < NumEnemy; ++i)
                e.Graphics.FillEllipse(brush, this.enemy[i].X, this.enemy[i].Y, this.enemy[i].R * 2, this.enemy[i].R * 2);
            e.Graphics.FillEllipse(grayBrush, this.player.X, this.player.Y, 10, 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
