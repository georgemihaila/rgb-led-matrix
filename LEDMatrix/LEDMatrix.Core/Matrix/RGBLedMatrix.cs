using LEDMatrix.Core.Canvas;
using LEDMatrix.Core.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Matrix
{
    public class RGBLedMatrix : IRGBLEDMatrix, IDisposable
    {
        #region DLLImports
        [DllImport("librgbmatrix.so")]
        internal static extern IntPtr led_matrix_create(int rows, int chained, int parallel);

        [DllImport("librgbmatrix.so", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr led_matrix_create_from_options_const_argv(
            ref InternalRGBLedMatrixOptions options,
            int argc,
            string[] argv);

        [DllImport("librgbmatrix.so")]
        internal static extern void led_matrix_delete(IntPtr matrix);

        [DllImport("librgbmatrix.so")]
        internal static extern IntPtr led_matrix_create_offscreen_canvas(IntPtr matrix);

        [DllImport("librgbmatrix.so")]
        internal static extern IntPtr led_matrix_swap_on_vsync(IntPtr matrix, IntPtr canvas);

        [DllImport("librgbmatrix.so")]
        internal static extern IntPtr led_matrix_get_canvas(IntPtr matrix);

        [DllImport("librgbmatrix.so")]
        internal static extern byte led_matrix_get_brightness(IntPtr matrix);

        [DllImport("librgbmatrix.so")]
        internal static extern void led_matrix_set_brightness(IntPtr matrix, byte brightness);
        #endregion

        public RGBLedMatrix(int rows, int chained, int parallel)
        {
            matrix = led_matrix_create(rows, chained, parallel);
        }

        public RGBLedMatrix(RGBLedMatrixOptions options)
        {
            var opt = new InternalRGBLedMatrixOptions();

            try
            {
                // pass in options to internal data structure
                opt.chain_length = options.ChainLength;
                opt.rows = options.Rows;
                opt.cols = options.Cols;
                opt.hardware_mapping = options.HardwareMapping != null ? Marshal.StringToHGlobalAnsi(options.HardwareMapping) : IntPtr.Zero;
                opt.inverse_colors = (byte)(options.InverseColors ? 1 : 0);
                opt.led_rgb_sequence = options.LedRgbSequence != null ? Marshal.StringToHGlobalAnsi(options.LedRgbSequence) : IntPtr.Zero;
                opt.pixel_mapper_config = options.PixelMapperConfig != null ? Marshal.StringToHGlobalAnsi(options.PixelMapperConfig) : IntPtr.Zero;
                opt.panel_type = options.PanelType != null ? Marshal.StringToHGlobalAnsi(options.PanelType) : IntPtr.Zero;
                opt.parallel = options.Parallel;
                opt.multiplexing = options.Multiplexing;
                opt.pwm_bits = options.PwmBits;
                opt.pwm_lsb_nanoseconds = options.PwmLsbNanoseconds;
                opt.pwm_dither_bits = options.PwmDitherBits;
                opt.scan_mode = options.ScanMode;
                opt.show_refresh_rate = (byte)(options.ShowRefreshRate ? 1 : 0);
                opt.limit_refresh_rate_hz = options.LimitRefreshRateHz;
                opt.brightness = options.Brightness;
                opt.disable_hardware_pulsing = (byte)(options.DisableHardwarePulsing ? 1 : 0);
                opt.row_address_type = options.RowAddressType;

                string[] cmdline_args = Environment.GetCommandLineArgs();

                // Because gpio-slowdown is not provided in the options struct,
                // we manually add it.
                // Let's add it first to the command-line we pass to the
                // matrix constructor, so that it can be overridden with the
                // users' commandline.
                // As always, as the _very_ first, we need to provide the
                // program name argv[0], so this is why our slowdown_arg
                // array will have these two elements.
                //
                // Given that we can't initialize the C# struct with a slowdown
                // that is not 0, we just override it here with 1 if we see 0
                // (zero only really is usable on super-slow vey old Rpi1,
                // but for everyone else, it would be a nuisance. So we use
                // 0 as our sentinel).
                string[] slowdown_arg = new string[] { cmdline_args[0], "--led-slowdown-gpio=" + (options.GpioSlowdown == 0 ? 1 : options.GpioSlowdown) };

                string[] argv = new string[2 + cmdline_args.Length - 1];

                // Progname + slowdown arg first
                slowdown_arg.CopyTo(argv, 0);

                // Remaining args (excluding program name) then. This allows
                // the user to not only provide any of the other --led-*
                // options, but also override the --led-slowdown-gpio arg on
                // the commandline.
                Array.Copy(cmdline_args, 1, argv, 2, cmdline_args.Length - 1);

                int argc = argv.Length;

                matrix = led_matrix_create_from_options_const_argv(ref opt, argc, argv);
            }
            finally
            {
                if (options.HardwareMapping != null) Marshal.FreeHGlobal(opt.hardware_mapping);
                if (options.LedRgbSequence != null) Marshal.FreeHGlobal(opt.led_rgb_sequence);
                if (options.PixelMapperConfig != null) Marshal.FreeHGlobal(opt.pixel_mapper_config);
                if (options.PanelType != null) Marshal.FreeHGlobal(opt.panel_type);
            }
        }

        private IntPtr matrix;

        public IRGBLEDCanvas CreateOffscreenCanvas()
        {
            var canvas = led_matrix_create_offscreen_canvas(matrix);
            return new RGBLedCanvas(canvas);
        }

        public IRGBLEDCanvas GetCanvas()
        {
            var canvas = led_matrix_get_canvas(matrix);
            return new RGBLedCanvas(canvas);
        }

        public IRGBLEDCanvas SwapOnVsync(IRGBLEDCanvas canvas)
        {
            canvas._canvasPtr = led_matrix_swap_on_vsync(matrix, canvas._canvasPtr);
            return canvas;
        }

        public byte Brightness
        {
            get { return led_matrix_get_brightness(matrix); }
            set { led_matrix_set_brightness(matrix, value); }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                led_matrix_delete(matrix);
                disposedValue = true;
            }
        }
        ~RGBLedMatrix()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
