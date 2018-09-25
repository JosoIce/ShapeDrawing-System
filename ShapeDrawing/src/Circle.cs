using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
    class Circle : Shape
    {
        private int _radius;

        public int Radius { get => _radius; set => _radius = value; }

        public Circle() : this(Color.Blue, 0, 0, 50) { }

        public Circle(Color clr, float x, float y, int radius) : base(clr)
        {
            X = x;
            Y = y;
            _radius = radius;
            Color = clr;
        }


        public override void Draw()
        { 
            SwinGame.FillCircle(Color, X, Y, _radius);
            if (Selected) DrawOutline();
        }
        
        public override void DrawOutline()
        {
            if (Selected)
            {
                SwinGame.DrawCircle(Color.Black, X, Y, _radius + 2);
            }
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, X, Y, _radius);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);

            writer.WriteLine(Radius);
        }
    }
}

