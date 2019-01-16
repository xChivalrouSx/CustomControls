using CustomControls.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls.Controls
{
    public partial class CustomButton : Button
    {

        #region [ - Custom Properties - ]

        private Color _BackColor_custom = CommonClass.COLOR_BUTTON_BLUE;
        [Description("Change the Custom Button BackColor"), Category("_Custom")]
        public Color BackColor_custom
        {
            get { return _BackColor_custom; }
            set { _BackColor_custom = value; this.Invalidate(); }
        }

        private Color _BorderColor_custom = CommonClass.COLOR_BUTTON_BLUE_DARK;
        [Description("Change the Custom Button BorderColor"), Category("_Custom")]
        public Color BorderColor_custom
        {
            get { return _BorderColor_custom; }
            set { _BorderColor_custom = value; this.Invalidate(); }
        }

        private int _BorderSize_custom = 0;
        [Description("Change the Custom Button BorderSize"), Category("_Custom")]
        public int BorderSize_custom
        {
            get { return _BorderSize_custom; }
            set { _BorderSize_custom = value; this.Invalidate(); }
        }

        private bool _RoundedCorner_custom = true;
        [Description("Set Is Button has rounded corner or not"), Category("_Custom")]
        public bool RoundedCorner_custom
        {
            get { return _RoundedCorner_custom; }
            set
            {
                _RoundedCorner_custom = value;
                RoundValue_custom = _RoundValue_custom;
                //this.Invalidate();
            }
        }

        private int _RoundValue_custom = 15;
        [Description("Set button corner round value"), Category("_Custom")]
        public int RoundValue_custom
        {
            get { return _RoundValue_custom; }
            set
            {
                if (_RoundedCorner_custom)
                {
                    _RoundValue_custom = value;
                }
                else
                {
                    _RoundValue_custom = 0;
                }

                this.Invalidate();
            }
        }

        #endregion


        #region [ - Public Methods - ]

        public CustomButton()
        {
            InitializeComponent();
        }

        #endregion


        #region [ - Override Methods - ]

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Draw Border if exist
            pe.Graphics.FillRegion(
                new SolidBrush(_BorderColor_custom),
                Region.FromHrgn(CommonClass.CreateRoundRectangleRegion(0, 0, Width, Height, _RoundValue_custom, _RoundValue_custom))
                );

            // Fill Button region
            pe.Graphics.FillRegion(
                new SolidBrush(_BackColor_custom),
                Region.FromHrgn(CommonClass.CreateRoundRectangleRegion(
                    _BorderSize_custom,
                    _BorderSize_custom,
                    Width - _BorderSize_custom,
                    Height - _BorderSize_custom,
                    _RoundValue_custom,
                    _RoundValue_custom
                    )));

            // Set text
            pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), ClientRectangle, CommonClass.GetStringFormatCenter());
        }

        #endregion

    }
}
