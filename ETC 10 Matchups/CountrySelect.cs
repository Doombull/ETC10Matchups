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
    public partial class CountrySelect : ContentControl
    {
        #region Properties

        /// <summary>
        /// The opposing country chosen by the user
        /// </summary>
        public string SelectedCountry
        { get; set; }

        #endregion

        #region Constructor

        public CountrySelect()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// When the form loads, populate it with all countries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountrySelect_Load(object sender, EventArgs e)
        {
            LoadCountryDropdowns();
        }

        /// <summary>
        /// When a user has selected an opposing country and wants to view matchups for it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.SelectedCountry = cmbCountries.SelectedItem.ToString();

            //Fire an event to signal that we have chosen our opponants
            if (ViewMatchupSelected != null)
                ViewMatchupSelected(this, new EventArgs());
        }

        /// <summary>
        /// This will add a new country to the Settings file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewCountry_Click(object sender, EventArgs e)
        {
            //Create the new node
            XmlElement newCountryNode = Utils.SettingsFile.CreateElement("Country");
            newCountryNode.SetAttribute("name", txtNewCountry.Text.Trim());

            //Insert the new node into the document and save it
            XmlNode opposingCountriesNode = Utils.SettingsFile.SelectSingleNode("/Settings/OpposingCountries");
            Utils.InsertNodeInOrder(newCountryNode, opposingCountriesNode, "Country", "name");

            Utils.SettingsFile.Save(Utils.SettingsFilePath);

            LoadCountryDropdowns();
        }

        /// <summary>
        /// When a user wants to change the armies associated with a country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeArmies_Click(object sender, EventArgs e)
        {
            this.SelectedCountry = cmbEditCountry.SelectedItem.ToString();

            //Fire an event to signal that we want to change armies for a country
            if (ChangeOpposingCountrysArmiesSelected != null)
                ChangeOpposingCountrysArmiesSelected(this, new EventArgs());
        }

        /// <summary>
        /// This will remove a country from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string label = String.Format("Are you sure you want to delete {0}?", cmbEditCountry.SelectedItem.ToString());
            string caption = "Confirm Deletion";
            if (MessageBox.Show(label, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string xpath = String.Format("/Settings/OpposingCountries/Country[@name='{0}']", cmbEditCountry.SelectedItem.ToString());
                XmlNode countryNode = Utils.SettingsFile.SelectSingleNode(xpath);

                if (countryNode != null)
                    countryNode.ParentNode.RemoveChild(countryNode);

                Utils.SettingsFile.Save(Utils.SettingsFilePath);

                //Update the display
                LoadCountryDropdowns();
            }
        }

        /// <summary>
        /// When they select a country, enable the go to next page button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        /// <summary>
        /// When they select a country in the edit section, enable the editing buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEditCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnChangeArmies.Enabled = true;
            btnDelete.Enabled = true;
        }

        /// <summary>
        /// When they enter text in the New Country box, enable the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNewCountry_TextChanged(object sender, EventArgs e)
        {
            if (txtNewCountry.Text.Replace(" ", "") != "")
                btnNewCountry.Enabled = true;
            else
                btnNewCountry.Enabled = false;
        }

        #endregion

        #region

        /// <summary>
        /// This will read in the countries from the settings file and show them in the drop downs
        /// </summary>
        protected void LoadCountryDropdowns()
        {
            //Clear any existing items
            cmbCountries.Items.Clear();
            cmbEditCountry.Items.Clear();

            cmbCountries.Text = "";
            cmbEditCountry.Text = "";

            btnNext.Enabled = false;
            btnChangeArmies.Enabled = false;
            btnDelete.Enabled = false;

            //Load the items
            string xpath = "/Settings/OpposingCountries/Country";
            XmlNodeList countries = Utils.SettingsFile.SelectNodes(xpath);

            foreach (XmlNode country in countries)
            {
                cmbCountries.Items.Add(country.Attributes["name"].Value);
                cmbEditCountry.Items.Add(country.Attributes["name"].Value);
            }
        }

        #endregion

        #region Events

        public event EventHandler ViewMatchupSelected;
        public event EventHandler ChangeOpposingCountrysArmiesSelected;

        #endregion
    }
}
