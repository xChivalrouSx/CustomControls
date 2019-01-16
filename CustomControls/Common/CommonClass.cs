using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Common
{
    static class CommonClass
    {
        #region [ - DLLs - ]

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectangleRegion
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        #endregion


        #region [ - Colors - ]

        public static readonly Color COLOR_BUTTON_BLUE = Color.FromArgb(255, 3, 169, 244);
        public static readonly Color COLOR_BUTTON_BLUE_DARK = Color.FromArgb(255, 0, 122, 193);
        public static readonly Color COLOR_BUTTON_BLUE_LIGHT = Color.FromArgb(255, 103, 218, 255);

        #endregion


        #region [ - Methods - ]

        public static StringFormat GetStringFormatCenter()
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;

            return stringFormat;
        }

        #endregion

    }
}
