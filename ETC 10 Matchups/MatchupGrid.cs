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
    public partial class MatchupGrid : ContentControl
    {
        #region Members

        private int _topMargin = 10;
        private int _leftMargin = 30;

        private int _armyLabelWidth = 110;
        private int _opponantLabelHeight = 140;
        private int _spacing = 3;

        private int _rowHeight = 30;
        private int _colWidth = 40;

        #endregion

        #region Properties

        [Category("MatchupGrid"), Description("Height of each row")]
        public int RowHeight
        {
            get { return _rowHeight; }
            set { _rowHeight = value; }
        }

        [Category("MatchupGrid"), Description("Width of each column")]
        public int ColWidth
        {
            get { return _colWidth; }
            set { _colWidth = value; }
        }

        [Category("MatchupGrid"), Description("The country we are playing")]
        public string OpposingCountry
        {
            get;
            set;
        }

        [Category("MatchupGrid"), Description("The opponants your team will be matched up against")]
        public List<Races> OpposingArmies
        {
            get;
            set;
        }

        [Category("MatchupGrid"), Description("The armies that we are taking")]
        public List<Races> OurArmies
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public MatchupGrid()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// This is fired when the control first loads. Here we create the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MatchupGrid_Load(object sender, EventArgs e)
        {
            //Load the settings file
            string settingsFile = Assembly.GetExecutingAssembly().Location.Replace(".exe", ".Settings.xml");
            if (!File.Exists(settingsFile))
                throw new ApplicationException("Settings file not found at " + settingsFile);

            XmlDocument doc = new XmlDocument();
            doc.Load(settingsFile);

            //Get the armies from the opposing country
            XmlNode opposingCountryNode = doc.SelectSingleNode(String.Format("/Settings/OpposingCountries/Country[@name='{0}']", OpposingCountry));
            XmlNodeList opponents = opposingCountryNode.SelectNodes("Opponent");
            this.OpposingArmies = new List<Races>(8);

            foreach (XmlNode node in opponents)
            {
                Races opponent = (Races)Enum.Parse(typeof(Races), node.Attributes["name"].Value);
                this.OpposingArmies.Add(opponent);
            }

            this.OpposingArmies.Sort();

            //Get the armies that we are taking
            XmlNodeList ourArmies = doc.SelectNodes("/Settings/OurArmies/Army");
            this.OurArmies = new List<Races>(8);

            foreach (XmlNode node in ourArmies)
            {
                Races army = (Races)Enum.Parse(typeof(Races), node.Attributes["name"].Value);
                this.OurArmies.Add(army);
            }

            this.OurArmies.Sort();

            //Draw the form
            CreateGridControls(doc);
        }
        
        /// <summary>
        /// This is fired when a user selects one of our armies as being matched up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OurArmySelect(object sender, MouseEventArgs e)
        {
            //Get the army that the user clicked on
            Label armyLabel = (Label)sender;
            Races army = (Races)Enum.Parse(typeof(Races), armyLabel.Name.Remove(0,7)); 

            //Get all the matchups that are for this army
            foreach (Control control in pnlGrid.Controls)
            {
                if (control is Matchup)
                {
                    Matchup matchup = (Matchup)control;
                    if (matchup.OurArmy == army)
                        matchup.OurArmySelected = !matchup.OurArmySelected;
                }
            }
        }

        /// <summary>
        /// This is fired when a user selects an opponants army as a match up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpposingArmySelect(object sender, MouseEventArgs e)
        {
            //Get the army that the user clicked on
            OpposingArmyLabel oppLabel = (OpposingArmyLabel)sender;

            //Mark all matchups for this army as selected
            foreach (Control control in pnlGrid.Controls)
            {
                if (control is Matchup)
                {
                    Matchup matchup = (Matchup)control;
                    if (matchup.OpposingArmy == oppLabel.Army)
                        matchup.OpposingArmySelected = !matchup.OpposingArmySelected;
                }
            }
        }

        /// <summary>
        /// When the user has finished doing matchups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewMatchupsComplete != null)
                ViewMatchupsComplete(this, new EventArgs());
        }

        #endregion

        #region Methods

        /// <summary>
        /// This will draw out the matchup grid
        /// </summary>
        /// <param name="doc">The settings document</param>
        private void CreateGridControls(XmlDocument doc)
        {
            //Create the heading row
            int oCntr = 0;
            foreach (Races opposingArmy in OpposingArmies)
            {
                OpposingArmyLabel oppLabel = new OpposingArmyLabel();

                oppLabel.Name = "lblOpponent" + oCntr;
                oppLabel.Army = opposingArmy;
                oppLabel.Font = new Font("Verdana", 9);

                oppLabel.Location = new Point(_leftMargin + _armyLabelWidth + _spacing + (oCntr * (ColWidth + _spacing + _spacing)), _topMargin);
                oppLabel.Size = new Size(ColWidth, _opponantLabelHeight);

                oppLabel.MouseClick += new MouseEventHandler(this.OpposingArmySelect);
                pnlGrid.Controls.Add(oppLabel);

                oCntr++;
            }

            //Get the node representing their country
            XmlNode opposingCountryNode = doc.SelectSingleNode(String.Format("/Settings/OpposingCountries/Country[@name='{0}']", OpposingCountry));
            if (opposingCountryNode == null)
                throw new ApplicationException(String.Format("Opponents armies not found in settings file at /Settings/OpposingCountries/Country[@name='{0}']", OpposingCountry));

            XmlNode defaultNode = doc.SelectSingleNode("/Settings/Country[@name='Default']");
            if (defaultNode == null)
                throw new ApplicationException("Default matchups not found in settings file at /Settings/Country[@name='Default']");

            //Loop through each of the armies that we are taking
            int aCntr = 0;
            foreach (Races ourArmy in OurArmies)
            {
                //Write the label for this army
                Label armyLabel = new Label();

                armyLabel.Name = "lblArmy" + ourArmy.ToString();
                armyLabel.Font = new Font("Verdana", 8);
                armyLabel.Text = EnumParser.GetDescription(ourArmy);
                armyLabel.TextAlign = ContentAlignment.MiddleLeft;
                armyLabel.UseMnemonic = false;

                int rowYVal = _topMargin + _opponantLabelHeight + _spacing + (aCntr * (RowHeight + _spacing + _spacing));
                armyLabel.Location = new Point(_leftMargin, rowYVal);
                armyLabel.Size = new Size(_armyLabelWidth, RowHeight);

                armyLabel.MouseClick += new MouseEventHandler(this.OurArmySelect);
                pnlGrid.Controls.Add(armyLabel);

                //Write a control for each matchup
                oCntr = 0;
                foreach (Races opposingArmy in OpposingArmies)
                {
                    //Get the rating for this matchup
                    XmlNode matchupNode = opposingCountryNode.SelectSingleNode(String.Format("Opponent[@name = '{0}']/Army[@name='{1}']", opposingArmy.ToString(), ourArmy.ToString()));

                    //If there is no matchup in the settings file, then check the default matchup
                    if (matchupNode == null)
                        matchupNode = defaultNode.SelectSingleNode(String.Format("Opponent[@name = '{0}']/Army[@name='{1}']", opposingArmy.ToString(), ourArmy.ToString()));

                    //Get the strength of this matchup
                    MatchupStrength strength = MatchupStrength.Unknown;
                    if (matchupNode != null)
                        strength = (MatchupStrength)Enum.Parse(typeof(MatchupStrength), matchupNode.InnerText);

                    //Show the matchup
                    Matchup matchup = new Matchup(ourArmy, opposingArmy, OpposingCountry, strength);
                    matchup.Name = "matchup" + aCntr + oCntr;

                    int xVal = _leftMargin + _armyLabelWidth + _spacing + (oCntr * (ColWidth + _spacing + _spacing));
                    matchup.Location = new Point(xVal, rowYVal);
                    matchup.Size = new Size(ColWidth, RowHeight);

                    pnlGrid.Controls.Add(matchup);

                    //Go to the next opponent in this row
                    oCntr++;
                }

                //Go to the next row
                aCntr++;
            }
        }

        #endregion

        #region Events

        public event EventHandler ViewMatchupsComplete;

        #endregion
    }
}
