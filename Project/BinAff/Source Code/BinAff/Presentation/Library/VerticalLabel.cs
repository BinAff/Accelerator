using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BinAff.Presentation.Library
{

    public class VerticalLabel : System.Windows.Forms.Label
    {

        private Boolean isFlipped = true;

        public VerticalLabel()
        {
            this.MinimumSize = new Size(24, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                Trimming = StringTrimming.None,
                FormatFlags = StringFormatFlags.DirectionVertical,
            };

            Matrix storedState = g.Transform;
            if (this.isFlipped)
            {
                g.RotateTransform(180f);
                g.TranslateTransform(-ClientRectangle.Width, -ClientRectangle.Height);
            }

            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), ClientRectangle, stringFormat);
            g.Transform = storedState;
        }

        [Description("When this parameter is true, the VLabel flips 180 degrees."), Category("Appearance")]
        public Boolean IsFlipped
        {
            get
            {
                return this.isFlipped;
            }
            set
            {
                this.isFlipped = value;
                this.Invalidate();
            }
        }

    }

}