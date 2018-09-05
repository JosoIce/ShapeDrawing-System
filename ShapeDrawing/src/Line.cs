using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Line : Shape
    {
        private float _endX, _endY;

        public Line() : this(Color.Red, 1, 1) { }

        public Line(Color clr, float startX, float startY) : base(clr)
        {
            X = startX;
            Y = startY;
            _endX = X + 10;
            _endY = Y + 10;
            Color = clr;
        }

        public float EndX { get => _endX; set => _endX = value; }
        public float EndY { get => _endY; set => _endY = value; }

        public override void Draw()
        {
            SwinGame.DrawLine(Color, X, Y, _endX, Y);
            if (Selected) DrawOutline();
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, 1);
            SwinGame.DrawCircle(Color.Black, X, Y, 1);
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointOnLine(pt, X, Y, _endX, _endY);
        }
    }
}
