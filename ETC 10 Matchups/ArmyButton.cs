using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ETC10Matchups
{
    public partial class ArmyButton : UserControl
    {
        #region Members

        private bool _selected;

        #endregion

        #region Properties

        /// <summary>
        /// The army that this button represents
        /// </summary>
        public Races Army
        { get; set; }

        /// <summary>
        /// Whether the user has selected this army or not
        /// </summary>
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                UpdateImage();
            }
        }

        #endregion

        #region Constructor

        public ArmyButton()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// When the control is first loaded, set the name of the army and the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArmyButton_Load(object sender, EventArgs e)
        {
            lblArmy.Text = EnumParser.GetDescription(this.Army);
            UpdateImage();
        }

        /// <summary>
        /// If the user clicks on the button, mark it as selected or unselected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClick(object sender, EventArgs e)
        {
            this.Selected = !this.Selected;
            OnClick(e);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Chooses the image to display
        /// </summary>
        private void UpdateImage()
        {
            //Get the filename of the image
            string selected = "";
            if (this.Selected)
                selected = "Selected";

            string imageURI = String.Format("ETC10Matchups.images.{0}Icon120x90{1}.png", Army.ToString(), selected);

            //Load the image
            imgArmy.Image = Image.FromStream(this.GetType().Assembly.GetManifestResourceStream(imageURI));
        }

        #endregion
    }
}
