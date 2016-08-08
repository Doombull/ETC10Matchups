using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ETC10Matchups
{
    public partial class VerticalLabel : Control
    {
        #region Members

        private string _text;
        private System.Drawing.ContentAlignment _textAlign = ContentAlignment.BottomCenter;

        #endregion

        #region Properties

        [Category("VerticalLabel"), Description("Text is displayed vertically in container")]
        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                Invalidate();
            }
        }

        [Category("VerticalLabel"), Description("Text Alignment")]
        public System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return _textAlign;
            }
            set
            {
                _textAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        public VerticalLabel()
        {
            InitializeComponent();
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            float sngControlWidth;
            float sngControlHeight;
            float sngTransformX;
            float sngTransformY;
            Color labelColor = this.BackColor;
            Pen labelBorderPen = new Pen(labelColor, 0);
            SolidBrush labelBackColorBrush = new SolidBrush(labelColor);
            SolidBrush labelForeColorBrush = new SolidBrush(base.ForeColor);

            base.OnPaint(e);

            sngControlWidth = this.Size.Width;
            sngControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, sngControlWidth, sngControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, sngControlWidth, sngControlHeight);
            sngTransformX = 0;
            sngTransformY = sngControlHeight;
            e.Graphics.TranslateTransform(sngTransformX, sngTransformY);
            e.Graphics.RotateTransform(270);

            #region figure out offset to achieve the desired alignment

            //default to bottom left alignment
            float leftOffset = 0;
            float topOffset = 0;             

            //handle top alignment
            if (this.TextAlign == System.Drawing.ContentAlignment.TopCenter ||
                this.TextAlign == System.Drawing.ContentAlignment.TopCenter ||
                this.TextAlign == System.Drawing.ContentAlignment.TopCenter)
            {
                System.Drawing.SizeF sf = e.Graphics.MeasureString(this.Text, Font);
                leftOffset = this.Size.Height - sf.Width;
            }

            //handle middle alignment
            if (this.TextAlign == System.Drawing.ContentAlignment.MiddleCenter ||
                this.TextAlign == System.Drawing.ContentAlignment.MiddleLeft ||
                this.TextAlign == System.Drawing.ContentAlignment.MiddleRight)
            {
                System.Drawing.SizeF sf = e.Graphics.MeasureString(this.Text, Font);
                leftOffset = (this.Size.Height - sf.Width) / 2;
            }

            //handle center alignment
            if (this.TextAlign == System.Drawing.ContentAlignment.BottomCenter ||
                this.TextAlign == System.Drawing.ContentAlignment.MiddleCenter ||
                this.TextAlign == System.Drawing.ContentAlignment.TopCenter)
            {
                System.Drawing.SizeF sf = e.Graphics.MeasureString(this.Text, Font);
                topOffset = (this.Size.Width - sf.Height) / 2;
            }

            //handle right alignment
            if (this.TextAlign == System.Drawing.ContentAlignment.BottomRight ||
                this.TextAlign == System.Drawing.ContentAlignment.MiddleRight ||
                this.TextAlign == System.Drawing.ContentAlignment.TopRight)
            {
                System.Drawing.SizeF sf = e.Graphics.MeasureString(this.Text, Font);
                topOffset = this.Size.Width - sf.Height;
            }
            #endregion

            e.Graphics.DrawString(Text, Font, labelForeColorBrush, leftOffset, topOffset);
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

    }
}
