using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
    class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this (Color.White)
        {

        }

        public Color Background { get { return _background; } set { _background = value; } }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();

                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }

                return result;
            }
        }
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public virtual void Draw()
        {
            SwinGame.ClearScreen(_background);
            for (int i = 0; i < _shapes.Count; i++)
            {
                _shapes[i].Draw();
            }
        }
        public virtual void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShapes()
        {
            foreach (Shape s in SelectedShapes)
            {
                _shapes.Remove(s);
            }
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(".../.../" + filename, true);

            writer.WriteLine(Background.ToArgb());
            writer.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
        }
    }
}
