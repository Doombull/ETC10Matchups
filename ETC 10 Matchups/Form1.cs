using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ETC10Matchups
{
    public partial class Form1 : Form
    {
        #region Constructor

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// If the user wants to view matchups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countrySelect_ViewMatchupSelected(object sender, EventArgs e)
        {
            string opposingCountry = ((CountrySelect)sender).SelectedCountry;

            //Create the matchup grid
            MatchupGrid matchupGrid = new MatchupGrid();
            matchupGrid.OpposingCountry = opposingCountry;

            matchupGrid.ViewMatchupsComplete += new EventHandler(matchupGrid_ViewMatchupsComplete);

            LoadContentControl(matchupGrid);
        }

        /// <summary>
        /// If the user wants to change the armeis of an opposing country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countrySelect_ChangeOpposingCountrysArmiesSelected(object sender, EventArgs e)
        {
            string opposingCountry = ((CountrySelect)sender).SelectedCountry;

            //Create the matchup grid
            ArmySelect armySelect = new ArmySelect();
            armySelect.Mode = ArmySelectionMode.OpposingCountry;
            armySelect.OpposingCountry = opposingCountry;

            armySelect.ArmySelectionComplete += new EventHandler(armySelect_ArmySelectionComplete);
            armySelect.ArmySelectionCancelled += new EventHandler(armySelect_ArmySelectionCancelled);

            LoadContentControl(armySelect);
        }

        /// <summary>
        /// If the user has changed an opposing countrys armies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void armySelect_ArmySelectionComplete(object sender, EventArgs e)
        {
            ArmySelectionMode mode = ((ArmySelect)sender).Mode;
            List<Races> armies = ((ArmySelect)sender).Armies;

            //Check if we are saving our own armies or another countries
            if (mode == ArmySelectionMode.OpposingCountry)
            {
                string opposingCountry = ((ArmySelect)sender).OpposingCountry;

                //Find that countries node in the settings xml
                string xpath = String.Format("/Settings/OpposingCountries/Country[@name='{0}']", opposingCountry);
                XmlNode opposingCountryNode = Utils.SettingsFile.SelectSingleNode(xpath);

                if (opposingCountryNode == null)
                {
                    string text = String.Format("Unable to find country node at {0}.\nArmies not saved.", xpath);
                    MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Remove existing armies that dont belong
                    XmlNodeList existingArmies = opposingCountryNode.SelectNodes("Opponent");
                    foreach (XmlNode node in existingArmies)
                    {
                        Races thisRace = (Races)Enum.Parse(typeof(Races), node.Attributes["name"].Value);
                        if (!armies.Contains(thisRace))
                            node.ParentNode.RemoveChild(node);
                    }

                    //Add new armies
                    foreach (Races army in armies)
                    {
                        xpath = String.Format("Opponent[@name='{0}']", army.ToString());
                        XmlNode node = opposingCountryNode.SelectSingleNode(xpath);
                        if (node == null)
                        {
                            XmlElement newArmy = Utils.SettingsFile.CreateElement("Opponent");
                            newArmy.SetAttribute("name", army.ToString());

                            Utils.InsertNodeInOrder(newArmy, opposingCountryNode, "Opponent", "name");
                        }
                    }

                    //Save the changes
                    Utils.SettingsFile.Save(Utils.SettingsFilePath);
                }
            }

            //Once the changes are saved, go back to the start
            LoadCountrySelect();
        }

        /// <summary>
        /// If the user exits without savings armies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void armySelect_ArmySelectionCancelled(object sender, EventArgs e)
        {
            LoadCountrySelect();
        }

        /// <summary>
        /// If the user wants to start a new matchup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matchupGrid_ViewMatchupsComplete(object sender, EventArgs e)
        {
            LoadCountrySelect();
        }

        /// <summary>
        /// When the form is first loaded, display the first step
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCountrySelect();
        }

        /// <summary>
        /// If the user wants to start a new matchup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCountrySelect();
        }

        /// <summary>
        /// If the user wants to exit the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods

        /// <summary>
        /// This will update the content area of the page with a new control
        /// </summary>
        /// <param name="control"></param>
        private void LoadContentControl(Control newControl)
        {
            //Remove the existing control
            foreach (Control control in this.Controls)
            {
                if (control is ContentControl)
                {
                    control.Dispose();
                    this.Controls.Remove(control);
                }
            }

            //Add the new control
            newControl.Location = new Point(804 - newControl.Width, 27);
            this.Controls.Add(newControl);

            newControl.BringToFront();
        }

        /// <summary>
        /// This method clears the existing control and loads the Select Country control
        /// </summary>
        protected void LoadCountrySelect()
        {
            CountrySelect countrySelect = new CountrySelect();
            countrySelect.ViewMatchupSelected += new EventHandler(countrySelect_ViewMatchupSelected);
            countrySelect.ChangeOpposingCountrysArmiesSelected += new EventHandler(countrySelect_ChangeOpposingCountrysArmiesSelected);

            LoadContentControl(countrySelect);
        }

        #endregion
    }
}
