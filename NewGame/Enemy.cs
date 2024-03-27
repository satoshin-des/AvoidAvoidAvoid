using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGame
{
    internal class Enemy
    {
        public float X, Y, R, SpdX, SpdY;
        public Enemy(float EnemyX, float EnemyY, float EnemySpeedX, float EnemySpeedY, float EnemyRadius)
        {
            this.X = EnemyX;
            this.Y = EnemyY;
            this.R = EnemyRadius;
            this.SpdX = EnemySpeedX;
            this.SpdY = EnemySpeedY;
        }
    }
}
