using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Rectangle : Shape
    {
        private int _width, _height;

        public Rectangle() : this(Color.Green, 0, 0, 100, 100) { }

        public Rectangle(Color clr, float x, float y, int width, int height) : base(clr)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public override void Draw()
        {
            SwinGame.FillRectangle(Color, X, Y, _width, _height);
            if (Selected) DrawOutline();
        }

        public override void DrawOutline()
        {
            if (Selected)
            {
                SwinGame.DrawRectangle(Color.Black, (X - 2), (Y - 2), (_width + 4), (_height + 4));
            }
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, X, Y, Width, Height);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
