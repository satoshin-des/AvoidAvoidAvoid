using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGame
{
    public partial class PlayScreenCtr : UserControl
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Right || keyData == Keys.Left ||
                keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Enter)
            {
                return true;
            }

            return base.IsInputKey(keyData);
        }
        
        Player player;
        List<Enemy> enemy, danmaku;
        public static int NumEnemy, S = 0, t = 0, NumDanmaku, t_danmaku = 0, DanmakuPeriod = 0;
        public static Timer timer = new Timer();
        static public Stopwatch PassedTime = new Stopwatch();


        public PlayScreenCtr()
        {
            // MainGameForm.Stage = 4;
            InitializeComponent();

            this.player = new Player(this.Bounds.Width / 2, this.Bounds.Height * 3 / 4);


            // 位置と半径
            NumEnemy = 5; NumDanmaku = 1480;
            var rand = new Random();
            this.enemy = new List<Enemy>();
            this.danmaku = new List<Enemy>();
            for (int i = 0; i < 3 * NumEnemy; ++i)
            {
                // this.enemy = new Enemy(10, 10, (float)-3.0, (float)-3.0, 10);
                this.enemy.Add(new Enemy(rand.Next(minValue: 10, maxValue: this.Bounds.Width - 10), rand.Next(minValue: 10, maxValue: (this.Bounds.Height - 10) / 2), (float)-3.0, (float)-3.0, 10));
            }
            for (int i = 3 * NumEnemy; i < 4 * NumEnemy; ++i)
            {
                // this.enemy = new Enemy(10, 10, (float)-3.0, (float)-3.0, 10);
                this.enemy.Add(new Enemy((float)((i - 3 * NumEnemy) * this.Bounds.Width / 5.0), 0, (float)-3.0, (float)-3.0, 10));
            }

            for(int i = 0; i < NumDanmaku; ++i)
            {
                if(i % 8 == 0)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, 1, 0, 20));
                else if (i % 8 == 1)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, 1 / (float)Math.Sqrt(2), 1 / (float)Math.Sqrt(2), 20));
                else if (i % 8 == 2)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, 0, 1, 20));
                else if (i % 8 == 3)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, -1 / (float)Math.Sqrt(2), 1 / (float)Math.Sqrt(2), 20));
                else if (i % 8 == 4)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, -1, 0, 20));
                else if (i % 8 == 5)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, -1 / (float)Math.Sqrt(2), -1 / (float)Math.Sqrt(2), 20));
                else if (i % 8 == 6)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, 0, -1, 20));
                else if (i % 8 == 7)
                    this.danmaku.Add(new Enemy(this.Bounds.Width / (float)2.0, this.Bounds.Height * (float)1.0 / 6, 1 / (float)Math.Sqrt(2), -1 / (float)Math.Sqrt(2), 20));
            }

            // Timer timer = new Timer();
            timer.Interval = 17; // 約60fps
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }


        // ============
        // 自機の操作
        // ============
        private void KeyDowned(object sender, KeyEventArgs e)
        {
            if (this.player.X < this.Bounds.Width - 10 && e.KeyCode == Keys.Right)
            {
                this.player.X += 10;
            }
            else if (this.player.X > 10 && e.KeyCode == Keys.Left)
            {
                this.player.X -= 10;
            }
            else if (this.player.Y > 10 && e.KeyCode == Keys.Up)
            {
                this.player.Y -= 10;
            }
            else if (this.player.Y < this.Bounds.Height - 10 && e.KeyCode == Keys.Down)
            {
                this.player.Y += 10;
            }
        }


        private void Update(object sender, EventArgs e)
        {
            // ===========
            // クリア条件
            // ===========
            if (t >= 3600)
            {
                t = 0;
                this.player.X = this.Bounds.Width / 2;
                this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                ++MainGameForm.Stage;

                MainGameForm.stage.Visible = true;
                MainGameForm.result.Visible = false;
                MainGameForm.play1.Visible = false;
                MainGameForm.opening.Visible = false;
                MainGameForm.ending.Visible = false;
            }


            // ===========
            // ステージ１
            // ===========
            if (MainGameForm.Stage == 1)
            {
                for (int i = 0; i < NumEnemy; ++i)
                {
                    if ((this.enemy[i].X - this.player.X) * (this.enemy[i].X - this.player.X) + (this.enemy[i].Y - this.player.Y) * (this.enemy[i].Y - this.player.Y) < (this.enemy[i].R + 5) * (this.enemy[i].R + 5))
                    {
                        this.player.X = this.Bounds.Width / 2;
                        this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                        S = 0;

                        MainGameForm.play1.Visible = false;
                        MainGameForm.stage.Visible = false;
                        MainGameForm.opening.Visible = false;
                        MainGameForm.result.Visible = true;
                        MainGameForm.ending.Visible = false;
                    }

                    this.enemy[i].X += this.enemy[i].SpdX;
                    this.enemy[i].Y += this.enemy[i].SpdY;

                    // 左右でバウンド
                    if (this.enemy[i].X + 2 * this.enemy[i].R > this.Bounds.Width || this.enemy[i].X - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdX > 0)
                            this.enemy[i].SpdX = Math.Max((float)-1.01 * this.enemy[i].SpdX, (float)-20.0);
                        else
                            this.enemy[i].SpdX = Math.Min((float)-1.01 * this.enemy[i].SpdX, (float)20.0);
                    }

                    // 上下でバウンド
                    if (this.enemy[i].Y + 2 * this.enemy[i].R > this.Bounds.Height || this.enemy[i].Y - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdY > 0)
                            this.enemy[i].SpdY = Math.Max((float)-1.01 * this.enemy[i].SpdY, (float)-20.0);
                        else
                            this.enemy[i].SpdY = Math.Min((float)-1.01 * this.enemy[i].SpdY, (float)20.0);
                    }
                }
            
                
            // ===========
            // ステージ２
            // ===========
            }
            else if(MainGameForm.Stage == 2)
            {
                for (int i = 0; i < NumEnemy; ++i)
                {
                    // 当たり判定
                    if (MainGameForm.Stage == 2)
                    {
                        if (this.enemy[i].R < 30 && (this.enemy[i].X - this.player.X) * (this.enemy[i].X - this.player.X) + (this.enemy[i].Y - this.player.Y) * (this.enemy[i].Y - this.player.Y) < (this.enemy[i].R + 5) * (this.enemy[i].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                        if (this.enemy[i + NumEnemy].R < 30 && (this.enemy[i + NumEnemy].X - this.player.X) * (this.enemy[i + NumEnemy].X - this.player.X) + (this.enemy[i + NumEnemy].Y - this.player.Y) * (this.enemy[i + NumEnemy].Y - this.player.Y) < (this.enemy[i + NumEnemy].R + 5) * (this.enemy[i + NumEnemy].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                    }

                    // 進める
                    this.enemy[i].X += this.enemy[i].SpdX;
                    this.enemy[i].Y += this.enemy[i].SpdY;

                    // 左右でバウンド
                    if (this.enemy[i].X + 2 * this.enemy[i].R > this.Bounds.Width || this.enemy[i].X - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdX > 0)
                            this.enemy[i].SpdX = Math.Max((float)-1.01 * this.enemy[i].SpdX, (float)-20.0);
                        else
                            this.enemy[i].SpdX = Math.Min((float)-1.01 * this.enemy[i].SpdX, (float)20.0);
                    }

                    // 上下でバウンド
                    if (this.enemy[i].Y + 2 * this.enemy[i].R > this.Bounds.Height || this.enemy[i].Y - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdY > 0)
                            this.enemy[i].SpdY = Math.Max((float)-1.01 * this.enemy[i].SpdY, (float)-20.0);
                        else
                            this.enemy[i].SpdY = Math.Min((float)-1.01 * this.enemy[i].SpdY, (float)20.0);
                    }


                    // クルクル回る
                    this.enemy[i + NumEnemy].SpdX += (float)((i + 1.0) * 0.01);
                    this.enemy[i + NumEnemy].SpdY += (float)((i + 1.0) * 0.01);
                    this.enemy[i + NumEnemy].X = (20 * i + 20) * (float)Math.Cos(this.enemy[i + NumEnemy].SpdX) + (float)(this.Bounds.Width / 5.0) * i;
                    this.enemy[i + NumEnemy].Y = (20 * i + 20) * (float)Math.Sin(this.enemy[i + NumEnemy].SpdY) + (float)(this.Bounds.Height / 2.0);
                }
            }


            // ===========
            // ステージ３
            // ===========
            else if (MainGameForm.Stage == 3)
            {
                for (int i = 0; i < NumEnemy; ++i)
                {
                    // 当たり判定
                    if (MainGameForm.Stage == 3)
                    {
                        if (this.enemy[i].R < 30 && (this.enemy[i].X - this.player.X) * (this.enemy[i].X - this.player.X) + (this.enemy[i].Y - this.player.Y) * (this.enemy[i].Y - this.player.Y) < (this.enemy[i].R + 5) * (this.enemy[i].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                        if (this.enemy[i + NumEnemy].R < 30 && (this.enemy[i + NumEnemy].X - this.player.X) * (this.enemy[i + NumEnemy].X - this.player.X) + (this.enemy[i + NumEnemy].Y - this.player.Y) * (this.enemy[i + NumEnemy].Y - this.player.Y) < (this.enemy[i + NumEnemy].R + 5) * (this.enemy[i + NumEnemy].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                        if (this.enemy[i + 2 * NumEnemy].R < 30 && (this.enemy[i + 2 * NumEnemy].X - this.player.X) * (this.enemy[i + 2 * NumEnemy].X - this.player.X) + (this.enemy[i + 2 * NumEnemy].Y - this.player.Y) * (this.enemy[i + 2 * NumEnemy].Y - this.player.Y) < (this.enemy[i + 2 * NumEnemy].R + 5) * (this.enemy[i + 2 * NumEnemy].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                    }

                    // 進める
                    this.enemy[i].X += this.enemy[i].SpdX;
                    this.enemy[i].Y += this.enemy[i].SpdY;

                    // 左右でバウンド
                    if (this.enemy[i].X + 2 * this.enemy[i].R > this.Bounds.Width || this.enemy[i].X - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdX > 0)
                            this.enemy[i].SpdX = Math.Max((float)-1.01 * this.enemy[i].SpdX, (float)-20.0);
                        else
                            this.enemy[i].SpdX = Math.Min((float)-1.01 * this.enemy[i].SpdX, (float)20.0);
                    }

                    // 上下でバウンド
                    if (this.enemy[i].Y + 4 * this.enemy[i].R > this.Bounds.Height || this.enemy[i].Y - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdY > 0)
                            this.enemy[i].SpdY = Math.Max((float)-1.01 * this.enemy[i].SpdY, (float)-20.0);
                        else
                            this.enemy[i].SpdY = Math.Min((float)-1.01 * this.enemy[i].SpdY, (float)20.0);
                    }


                    // クルクル回る
                    this.enemy[i + NumEnemy].SpdX += (float)((i + 1.0) * 0.01);
                    this.enemy[i + NumEnemy].SpdY += (float)((i + 1.0) * 0.01);
                    this.enemy[i + NumEnemy].X = (this.Bounds.Height / 2) * (float)Math.Cos(this.enemy[i + NumEnemy].SpdX) + (float)(this.Bounds.Width / 5.0) * i;
                    this.enemy[i + NumEnemy].Y = (this.Bounds.Height / 2) * (float)Math.Sin(this.enemy[i + NumEnemy].SpdY) + (float)(this.Bounds.Height / 2.0);

                    // リサジュー曲線
                    this.enemy[i + 2 * NumEnemy].SpdX += (float)((i + 1.0) * 0.001);
                    this.enemy[i + 2 * NumEnemy].SpdY += (float)((i + 1.0) * 0.001);
                    this.enemy[i + 2 * NumEnemy].X = (this.Bounds.Height / 2 + 10 * i) * (float)Math.Sin((i + 1) * this.enemy[i + 2 * NumEnemy].SpdX) + (float)(this.Bounds.Width / 6.0) * i + 40;
                    this.enemy[i + 2 * NumEnemy].Y = (this.Bounds.Height / 2 + 11 * i) * (float)Math.Cos((i + 1) * this.enemy[i + 2 * NumEnemy].SpdY) + this.Bounds.Height / 2;
                }
            }


            // ===========
            // ステージ４
            // ===========
            else if (MainGameForm.Stage == 4)
            {
                for (int i = 0; i < NumEnemy; ++i)
                {
                    // 当たり判定
                    if (MainGameForm.Stage == 4)
                    {
                        if (this.enemy[i].R < 30 && (this.enemy[i].X - this.player.X) * (this.enemy[i].X - this.player.X) + (this.enemy[i].Y - this.player.Y) * (this.enemy[i].Y - this.player.Y) < (this.enemy[i].R + 5) * (this.enemy[i].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                        if (this.enemy[i + NumEnemy].R < 30 && (this.enemy[i + NumEnemy].X - this.player.X) * (this.enemy[i + NumEnemy].X - this.player.X) + (this.enemy[i + NumEnemy].Y - this.player.Y) * (this.enemy[i + NumEnemy].Y - this.player.Y) < (this.enemy[i + NumEnemy].R + 5) * (this.enemy[i + NumEnemy].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                        if (this.enemy[i + 2 * NumEnemy].R < 30 && (this.enemy[i + 2 * NumEnemy].X - this.player.X) * (this.enemy[i + 2 * NumEnemy].X - this.player.X) + (this.enemy[i + 2 * NumEnemy].Y - this.player.Y) * (this.enemy[i + 2 * NumEnemy].Y - this.player.Y) < (this.enemy[i + 2 * NumEnemy].R + 5) * (this.enemy[i + 2 * NumEnemy].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                        if ((this.enemy[i + 2 * NumEnemy].X - this.player.X) * (this.enemy[i + 2 * NumEnemy].X - this.player.X) + (this.enemy[i + 2 * NumEnemy].Y - this.player.Y) * (this.enemy[i + 2 * NumEnemy].Y - this.player.Y) < (this.enemy[i + 2 * NumEnemy].R + 5) * (this.enemy[i + 2 * NumEnemy].R + 5))
                        {
                            this.player.X = this.Bounds.Width / 2;
                            this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                            S = 0;

                            MainGameForm.play1.Visible = false;
                            MainGameForm.stage.Visible = false;
                            MainGameForm.opening.Visible = false;
                            MainGameForm.result.Visible = true;
                            MainGameForm.ending.Visible = false;
                        }
                    }

                    // 進める
                    this.enemy[i].X += this.enemy[i].SpdX;
                    this.enemy[i].Y += this.enemy[i].SpdY;

                    // 左右でバウンド
                    if (this.enemy[i].X + 2 * this.enemy[i].R > this.Bounds.Width || this.enemy[i].X - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdX > 0)
                            this.enemy[i].SpdX = Math.Max((float)-1.01 * this.enemy[i].SpdX, (float)-20.0);
                        else
                            this.enemy[i].SpdX = Math.Min((float)-1.01 * this.enemy[i].SpdX, (float)20.0);
                    }

                    // 上下でバウンド
                    if (this.enemy[i].Y + 2 * this.enemy[i].R > this.Bounds.Height || this.enemy[i].Y - this.enemy[i].R < 0)
                    {
                        if (this.enemy[i].SpdY > 0)
                            this.enemy[i].SpdY = Math.Max((float)-1.01 * this.enemy[i].SpdY, (float)-20.0);
                        else
                            this.enemy[i].SpdY = Math.Min((float)-1.01 * this.enemy[i].SpdY, (float)20.0);
                    }


                    // クルクル回る
                    this.enemy[i + NumEnemy].SpdX += (float)((i + 1.0) * 0.01);
                    this.enemy[i + NumEnemy].SpdY += (float)((i + 1.0) * 0.01);
                    this.enemy[i + NumEnemy].X = (this.Bounds.Height / 2) * (float)Math.Cos(this.enemy[i + NumEnemy].SpdX) + (float)(this.Bounds.Width / 5.0) * i;
                    this.enemy[i + NumEnemy].Y = (this.Bounds.Height / 2) * (float)Math.Sin(this.enemy[i + NumEnemy].SpdY) + (float)(this.Bounds.Height / 2.0);

                    // リサジュー曲線
                    this.enemy[i + 2 * NumEnemy].SpdX += (float)((i + 1.0) * 0.001);
                    this.enemy[i + 2 * NumEnemy].SpdY += (float)((i + 1.0) * 0.001);
                    this.enemy[i + 2 * NumEnemy].X = (this.Bounds.Height / 2 + 10 * i) * (float)Math.Sin((i + 1) * this.enemy[i + 2 * NumEnemy].SpdX) + (float)(this.Bounds.Width / 6.0) * i + 40;
                    this.enemy[i + 2 * NumEnemy].Y = (this.Bounds.Height / 2 + 11 * i) * (float)Math.Cos((i + 1) * this.enemy[i + 2 * NumEnemy].SpdY) + this.Bounds.Height / 2;
                }

                // 弾幕の動き
                ++DanmakuPeriod;
                for (int j = 0; j < NumDanmaku; ++j)
                {
                    // 当たり判定
                    if ((this.danmaku[j].X - this.player.X) * (this.danmaku[j].X - this.player.X) + (this.danmaku[j].Y - this.player.Y) * (this.danmaku[j].Y - this.player.Y) < (this.danmaku[j].R + 5) * (this.danmaku[j].R + 5))
                    {
                        this.player.X = this.Bounds.Width / 2;
                        this.player.Y = (int)(this.Bounds.Height * 3.0 / 4);
                        S = 0;

                        MainGameForm.play1.Visible = false;
                        MainGameForm.stage.Visible = false;
                        MainGameForm.opening.Visible = false;
                        MainGameForm.result.Visible = true;
                        MainGameForm.ending.Visible = false;
                    }


                    if (0 <= j && j < (8 * t_danmaku + 8) % NumDanmaku)
                    //for (int i = 0; i < (8 * t_danmaku + 8) % NumDanmaku; ++i)
                    {
                        this.danmaku[j].X += 2 * this.danmaku[j].SpdX;
                        this.danmaku[j].Y += 2 * this.danmaku[j].SpdY;
                    }

                    if (DanmakuPeriod >= 60)
                    {
                        DanmakuPeriod = 0;
                        ++t_danmaku;
                    }

                    if (t_danmaku >= 185)
                    {
                        if ((8 * t_danmaku) % NumDanmaku <= j && j < (8 * t_danmaku + 8) % NumDanmaku)
                            //for (int i = (8 * t_danmaku) % NumDanmaku; i < (8 * t_danmaku + 8) % NumDanmaku; ++i)
                        {
                            this.danmaku[j].X = this.Bounds.Width / (float)2.0;
                            this.danmaku[j].Y = this.Bounds.Height * (float)5.0 / 6;
                        }
                    }
                }
            }


            // =================
            // 得点の加算と表示
            // =================
            PassedTime.Stop();
            ++S; ++t;
            this.label1.Text = "Score: " + S + ", " + MainGameForm.Stage;
            PassedTime.Start();

            // 再描画
            Invalidate();
        }

        private void PlayScreenCtr_Load(object sender, EventArgs e)
        {

        }

        private void Draw(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.HotPink);
            SolidBrush grayBrush = new SolidBrush(Color.DimGray);

            for (int i = 0; i < NumEnemy; ++i)
                e.Graphics.FillEllipse(brush, this.enemy[i].X, this.enemy[i].Y, this.enemy[i].R * 2, this.enemy[i].R * 2);

            if(MainGameForm.Stage >= 2)
                for (int i = NumEnemy; i < 2 * NumEnemy; ++i)
                    e.Graphics.FillEllipse(brush, this.enemy[i].X, this.enemy[i].Y, this.enemy[i].R * 2, this.enemy[i].R * 2);

            if (MainGameForm.Stage >= 3)
                for (int i = 2 * NumEnemy; i < 3 * NumEnemy; ++i)
                    e.Graphics.FillEllipse(brush, this.enemy[i].X, this.enemy[i].Y, this.enemy[i].R * 2, this.enemy[i].R * 2);

            
            if (MainGameForm.Stage >= 4)
                for(int i = 0; i < NumDanmaku; ++i)
                    e.Graphics.FillEllipse(brush, this.danmaku[i].X, this.danmaku[i].Y, this.danmaku[i].R * 2, this.danmaku[i].R * 2);



            e.Graphics.FillEllipse(grayBrush, this.player.X, this.player.Y, 10, 10);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
