using LEDMatrix.Core.Canvas;

namespace LEDMatrix.Core
{
    public interface IRGBLEDMatrix<TCanvas>
        where TCanvas : IRGBLEDCanvas
    {
        public byte Brightness { get; set; }
        public TCanvas CreateOffscreenCanvas();
        public TCanvas GetCanvas();
        public TCanvas SwapOnVsync(TCanvas canvas);
    }
}
