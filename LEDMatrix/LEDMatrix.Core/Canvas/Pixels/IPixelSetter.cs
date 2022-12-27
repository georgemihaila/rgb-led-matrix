﻿namespace LEDMatrix.Core.Canvas.Pixels
{
    public interface IPixelSetter
    {
        public void SetPixel(int x, int y, Color color);
        public void SetPixel(Pixel pixel);
    }
}