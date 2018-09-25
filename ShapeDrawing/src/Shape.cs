using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        private bool _selected;

        public Shape() : this(Color.Yellow) { }

        public Shape(Color clr)
        {
            _color = clr;
        }

        public Color Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }

        }

        public float Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }

        }

        public bool Selected { get => _selected; set => _selected = value; }

        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(Color.ToArgb());
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }
    }
}
