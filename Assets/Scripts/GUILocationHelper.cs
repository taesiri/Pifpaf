﻿using UnityEngine;

namespace Assets.Scripts
{
    public class GUILocationHelper
    {
        public float OriginalWidth = 449f;
        public float OriginalHeigth = 718f;


        public float ActualWidth = Screen.width;
        public float ActualHeight = Screen.height;

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
        public Vector2 CenterOfScreen;

        public void UpdateLocation()
        {
            ActualWidth = Screen.width;
            ActualHeight = Screen.height;

            CenterOfScreen = new Vector2(ActualWidth / 2f, ActualHeight / 2f);

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