using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ETC10Matchups
{
    public partial class ArmySelect : ContentControl
    {
        #region Members

        private int _currentSelected = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The armies chosen by the user
        /// </summary>
        public List<Races> Armies
        { get; set; }

        /// <summary>
        /// Indicates whether we are selecting our armies or armies for a different country
        /// </summary>
        public ArmySelectionMode Mode
        { get; set; }

        /// <summary>
        /// If we are editing another countrys armies this stores what country it is
        /// </summary>
        public string OpposingCountry
        { get; set; }

        #endregion

        #region Constructor

        public ArmySelect()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// When the form loads, select the armies that we currently have
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArmySelect_Load(object sender, EventArgs e)
        {
            if (Mode == ArmySelectionMode.OpposingCountry)
            {
                //Get the opposing armies
                string xpath = String.Format("/Settings/OpposingCountries/Country[@name='{0}']/Opponent", OpposingCountry);
                XmlNodeList opposingArmies = Utils.SettingsFile.SelectNodes(xpath);

                //Select the appropriate buttons
                foreach (XmlNode node in opposingArmies)
                {
                    Races army = (Races)Enum.Parse(typeof(Races), node.Attributes["name"].Value);
                    foreach (Control control in panel1.Controls)
                    {
                        if (control is ArmyButton)
                        {
                            ArmyButton button = (ArmyButton)control;
                            if (button.Army == army)
                            {
                                button.Selected = true;
                                armyButtonClick(button, new EventArgs());
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when a user clicks a button to select an opponant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void armyButtonClick(object sender, EventArgs e)
        {
            ArmyButton button = (ArmyButton)sender;

            //Check if we are selecting or unselecting
            if (button.Selected)
                _currentSelected++;
            else
                _currentSelected--;

            //Check if we have the rigth amount selected
            btnNext.Enabled = (_currentSelected == 8);
        }

        /// <summary>
        /// When a user has selected all 8 opponants and wants to go on to the next screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            List<Races> armies = new List<Races>();

            //Loop through all the buttons and get the ones the user selected
            foreach (Control control in panel1.Controls)
            {
                if (control is ArmyButton)
                {
                    ArmyButton button = (ArmyButton)control;
                    if (button.Selected)
                        armies.Add(button.Army);
                }
            }

            armies.Sort();
            this.Armies = armies;

            //Fire an event to signal that we have chosen our opponants
            if (ArmySelectionComplete != null)
                ArmySelectionComplete(this, new EventArgs());
        }

        /// <summary>
        /// If the user hits the cancel button, raise the event and dont save anything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Fire an event to signal that we dont want to save anything
            if (ArmySelectionCancelled != null)
                ArmySelectionCancelled(this, new EventArgs());
        }

        #endregion

        #region Events

        public event EventHandler ArmySelectionComplete;
        public event EventHandler ArmySelectionCancelled;

        #endregion

    }

    /// <summary>
    /// This enum is used to indicate whether we are selecting our armies or the armies of a 
    /// different country
    /// </summary>
    public enum ArmySelectionMode
    {
        OurArmies,
        OpposingCountry
    }
}
