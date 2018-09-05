using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle
        }

        public static void Main()
        {

            ShapeKind kindToAdd;

            kindToAdd = ShapeKind.Rectangle;
            // Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            // SwinGame.ShowSwinGameSplashScreen();

            Drawing drawing = new Drawing();
            
            

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                // Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                // Clear the screen and draw the framerate
                SwinGame.ClearScreen(drawing.Background);
                drawing.Draw();
                SwinGame.DrawFramerate(0, 0);

                // Sets shape type based on user input
                if (Input.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (Input.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                // Sets shapes position from mouse click
                if (Input.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape = new Shape();

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        Circle circle = new Circle();
                        myShape = circle;
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        Rectangle rect = new Rectangle();
                        myShape = rect;
                    }

                    myShape.X = SwinGame.MouseX();
                    myShape.Y = SwinGame.MouseY();

                    drawing.AddShape(myShape);
                }


                if (Input.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SwinGame.RandomRGBColor(255);
                }

                if (Input.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SwinGame.MousePosition());
                }

                if (Input.KeyTyped(KeyCode.DeleteKey))
                {
                    drawing.RemoveShapes();
                }
                // Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}