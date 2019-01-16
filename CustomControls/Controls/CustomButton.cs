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

        #region [ - Fields - ]

        private int _hoverBorderSize = 0;
        private Color _keepBackColor;

        #endregion


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
            set
            {
                int control = (Width <= Height) ? Width / 3 : Height / 3;

                if (value < 0) { value = 0; }
                else if (value > control) { value = control; }

                _BorderSize_custom = value;
                this.Invalidate();
            }
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
                if (_RoundedCorner_custom && value > 0)
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

        private int _HoverValue_custom = 15;
        [Description("Set button hover density"), Category("_Custom")]
        public int HoverValue_custom
        {
            get { return _HoverValue_custom; }
            set { _HoverValue_custom = value; this.Invalidate(); }
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

            // if no image setted than draw button
            if (this.BackgroundImage == null && this.Image == null)
            {
                // Draw Border if exist
                pe.Graphics.FillRegion(
                    new SolidBrush(_BorderColor_custom),
                    Region.FromHrgn(CommonClass.CreateRoundRectangleRegion(
                        _hoverBorderSize, 
                        _hoverBorderSize, 
                        Width - _hoverBorderSize, 
                        Height - _hoverBorderSize, 
                        _RoundValue_custom, _RoundValue_custom
                        )));

                // Fill Button region
                pe.Graphics.FillRegion(
                    new SolidBrush(_BackColor_custom),
                    Region.FromHrgn(CommonClass.CreateRoundRectangleRegion(
                        _BorderSize_custom + _hoverBorderSize,
                        _BorderSize_custom + _hoverBorderSize,
                        Width - _BorderSize_custom - _hoverBorderSize,
                        Height - _BorderSize_custom - _hoverBorderSize,
                        _RoundValue_custom,
                        _RoundValue_custom
                        )));

                // Set text
                pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), ClientRectangle, CommonClass.GetStringFormatCenter());
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            this.BackColor = this.Parent.BackColor;
            this.Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            _keepBackColor = _BackColor_custom;
            _BackColor_custom = GetNewHoverColor(_BackColor_custom);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _BackColor_custom = _keepBackColor;
        }

        #endregion


        #region [ - Private Methods - ]

        private Color GetNewHoverColor(Color color)
        {
            int r, g, b;
            r = g = b = 0;

            // Set new values to R, G, B
            r = color.R - _HoverValue_custom;
            g = color.G - _HoverValue_custom;
            b = color.B - _HoverValue_custom;

            // Check R for is valid
            r = (r > 255) ? 255 : r;
            r = (r < 0) ? 0 : r;

            // Check G for is valid
            g = (g > 255) ? 255 : g;
            g = (g < 0) ? 0 : g;
            
            // Check B for is valid
            b = (b > 255) ? 255 : b;
            b = (b < 0) ? 0 : b;

            return Color.FromArgb(r, g, b);
        }

        #endregion
    }
}
