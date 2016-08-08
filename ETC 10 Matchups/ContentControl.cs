using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ETC10Matchups
{
    public partial class ContentControl : UserControl
    {
        public ContentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When this control is loaded, sync the background image with the parents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentControl_Load(object sender, EventArgs e)
        {
            PictureBox imgBackground = null;

            //Get the background image on this control
            foreach (Control control in this.Controls)
            {
                if (control.Name == "imgBackground")
                {
                    imgBackground = (PictureBox)control;
                    break;
                }
            }

            //Make sure we found the background control
            if (imgBackground == null)
                return;

            //Set this image to be in the same position as the parents
            foreach (Control control in Parent.Controls)
            {
                if (control.Name == "imgBackground")
                {
                    PictureBox pic = (PictureBox)control;

                    int xVal = 0 - this.Left + pic.Left;
                    int yVal = 0 - this.Top + pic.Top;

                    imgBackground.Location = new Point(xVal, yVal);
                    break;
                }
            }
        }
    }
}
