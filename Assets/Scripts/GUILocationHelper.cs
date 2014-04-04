using UnityEngine;

namespace Assets.Scripts
{
    public class GUILocationHelper
    {
<<<<<<< HEAD
        public float OriginalWidth = 449f;
        public float OriginalHeigth = 718f;
=======
        public float OriginalWidth = 1149f;
        public float OriginalHeigth = 818f;
>>>>>>> e08f73596904de2a16af8a2358aaa7553a829edb

        public enum Point
        {
            TopLeft,
            TopRigjt,
            BottomLeft,
            BottomRight,
            Center
        }

        public Point PointLocation = Point.TopLeft;
        public Vector2 Offset;
        public Vector2 GuiOffset;

        public void UpdateLocation()
        {
            switch (PointLocation)
            {
                case Point.TopLeft:
                    Offset = new Vector2(0, 0);
                    break;
                case Point.TopRigjt:
                    Offset = new Vector2(OriginalWidth, 0);
                    break;
                case Point.BottomLeft:
                    Offset = new Vector2(0, OriginalHeigth);
                    break;
                case Point.BottomRight:
                    Offset = new Vector2(OriginalWidth, OriginalHeigth);
                    break;
                case Point.Center:
                    Offset = new Vector2(OriginalWidth/2f, OriginalHeigth/2f);
                    break;
            }

            GuiOffset.x = Screen.width/OriginalWidth;
            GuiOffset.y = Screen.height/OriginalHeigth;
        }
    }
}