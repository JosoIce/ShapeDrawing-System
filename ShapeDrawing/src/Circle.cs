using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Circle : Shape
    {
        private int _radius;

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public Circle()
        {
            _radius = 50;
        }

        public override void Draw()
        {
            if (Selected) DrawOutline();
            SwinGame.FillCircle(Color, X, Y, _radius);
        }
        
        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, (_radius + 2));
        }
    }
}

