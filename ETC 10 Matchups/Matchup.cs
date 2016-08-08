using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ETC10Matchups
{
    public partial class Matchup : UserControl
    {
        #region Members

        private MatchupStrength _strength;
        private bool _armySelected = false;
        private bool _opposingArmySelected = false;

        #endregion

        #region Properties

        public Races OurArmy
        { get; set; }

        public Races OpposingArmy
        { get; set; }

        public string OpposingCountry
        { get; set; }

        public bool OurArmySelected
        {
            get { return _armySelected; }
            set
            {
                _armySelected = value;
                Invalidate();
            }
        }

        public bool OpposingArmySelected
        {
            get { return _opposingArmySelected; }
            set
            {
                _opposingArmySelected = value;
                Invalidate();
            }
        }

        public MatchupStrength Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        public Matchup(Races army, Races opposingArmy, string opposingCountry, MatchupStrength strength)
        {
            InitializeComponent();
            this.OurArmy = army;
            this.OpposingArmy = opposingArmy;
            this.OpposingCountry = opposingCountry;
            this.Strength = strength;
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Override the OnPaint method to colour this matchup appropriately
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Set the unavailable matchup look
            if (this.OurArmySelected || this.OpposingArmySelected)
            {
                this.BackColor = Color.Gainsboro;
                base.OnPaint(e);
            }

            //Set the available match up look
            else
            {
                int borderWidth = 1;
                Color borderColor = Color.Black;

                //Select the colors depending on the strength of the matchup
                switch (this.Strength)
                {
                    case MatchupStrength.Unknown:
                        this.BackColor = Color.White;
                        borderColor = Color.Gainsboro;
                        break;

                    case MatchupStrength.Good:
                        this.BackColor = Color.LimeGreen;
                        borderColor = Color.ForestGreen;
                        break;

                    case MatchupStrength.Average:
                        this.BackColor = Color.Gold;
                        borderColor = Color.Goldenrod;
                        break;

                    case MatchupStrength.Bad:
                        this.BackColor = Color.Red;
                        borderColor = Color.DarkRed;
                        break;
                }

                //Draw the control
                base.OnPaint(e);
                Rectangle paintArea = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(e.Graphics, paintArea, borderColor,
                          borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
                          ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
                          borderColor, borderWidth, ButtonBorderStyle.Solid);
            }
        }

        /// <summary>
        /// This fires when a user chooses a different strength from the context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == miGood)
                UpdateMatchupStrength(MatchupStrength.Good);
            else if (sender == miAverage)
                UpdateMatchupStrength(MatchupStrength.Average);
            else if (sender == miPoor)
                UpdateMatchupStrength(MatchupStrength.Bad);
            else if (sender == miClear)
                UpdateMatchupStrength(MatchupStrength.Unknown);

            Invalidate();
        }

        #endregion

        #region Methods

        /// <summary>
        /// This will update the display with the new strength and save it to the settings file
        /// if nessecary
        /// </summary>
        /// <param name="newStrength"></param>
        protected void UpdateMatchupStrength(MatchupStrength newStrength)
        {
            //Check if we need to update the settings file
            if (newStrength != this.Strength)
            {
                //Get the opposing armies node in the settings file
                string xpath = String.Format("/Settings/OpposingCountries/Country[@name='{0}']/Opponent[@name='{1}']", OpposingCountry, OpposingArmy.ToString());
                XmlNode opposingArmyNode = Utils.SettingsFile.SelectSingleNode(xpath);
                if (opposingArmyNode == null)
                    throw new ApplicationException("Opposing Army node not found in setting file at " + xpath);

                //Check if we need to add a new node for this army or overwrite an existing one
                xpath = String.Format("Army[@name='{0}']", OurArmy.ToString());
                XmlNode ourArmyNode = opposingArmyNode.SelectSingleNode(xpath);

                if (ourArmyNode == null && newStrength != MatchupStrength.Unknown)
                {
                    XmlElement newNode = Utils.SettingsFile.CreateElement("Army");
                    newNode.SetAttribute("name", OurArmy.ToString());
                    newNode.InnerText = newStrength.ToString();

                    //Insert the node in the appropriate place
                    Utils.InsertNodeInOrder(newNode, opposingArmyNode, "Army", "name");
                }
                else if (ourArmyNode != null && newStrength == MatchupStrength.Unknown)
                {
                    ourArmyNode.ParentNode.RemoveChild(ourArmyNode);
                }
                else
                {
                    ourArmyNode.InnerText = newStrength.ToString();
                }

                //Save the changes
                Utils.SettingsFile.Save(Utils.SettingsFilePath);
            }

            //Update the display
            this.Strength = newStrength;
        }

        #endregion
    }
}

