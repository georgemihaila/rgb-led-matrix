using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Options
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct InternalRGBLedMatrixOptions
    {
        public IntPtr hardware_mapping;
        public int rows;
        public int cols;
        public int chain_length;
        public int parallel;
        public int pwm_bits;
        public int pwm_lsb_nanoseconds;
        public int pwm_dither_bits;
        public int brightness;
        public int scan_mode;
        public int row_address_type;
        public int multiplexing;
        public IntPtr led_rgb_sequence;
        public IntPtr pixel_mapper_config;
        public IntPtr panel_type;
        public byte disable_hardware_pulsing;
        public byte show_refresh_rate;
        public byte inverse_colors;
        public int limit_refresh_rate_hz;
    };
}
