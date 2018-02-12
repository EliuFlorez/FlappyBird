using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.Helpers
{
    class Collision
    {
        public static bool IsSloppyCollision(Rectangle sprite1Rectangle, Rectangle sprite2Rectangle)
        {
            return sprite1Rectangle.Intersects(sprite2Rectangle);
        }

        public static bool IsPixelCollision(Rectangle sprite1Rectangle, Rectangle sprite2Rectangle, Color[] colorData1, Color[] colorData2)
        {
            bool hasCollided = false;

            if (sprite1Rectangle.Intersects(sprite2Rectangle))
            {
                int _top = Math.Max(sprite1Rectangle.Top, sprite2Rectangle.Top);
                int _bottom = Math.Min(sprite1Rectangle.Bottom, sprite2Rectangle.Bottom);
                int _left = Math.Max(sprite1Rectangle.Left, sprite2Rectangle.Left);
                int _right = Math.Min(sprite1Rectangle.Right, sprite2Rectangle.Right);

                try
                {
                    for (int y = _top; y < _bottom; y++)
                    {
                        // For each pixel in this row
                        for (int x = _left; x < _right; x++)
                        {
                            Color A = colorData1[(y - sprite1Rectangle.Top) * (sprite1Rectangle.Width) + (x - sprite1Rectangle.Left)];
                            Color B = colorData2[(y - sprite2Rectangle.Top) * (sprite2Rectangle.Width) + (x - sprite2Rectangle.Left)];

                            // If both pixels are not completely transparent,
                            if (A.A > 0 && B.A > 0)
                            {
                                // then an intersection has been found
                                hasCollided = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception occured while checking for pixel collision. " + ex.InnerException);
                }
            }

            return hasCollided;
        }
    }
}
