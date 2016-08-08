using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ETC10Matchups
{
    public partial class OpposingArmyLabel : UserControl
    {
        #region Members

        private Races _army;

        #endregion

        #region Properties

        /// <summary>
        /// The army used by this opponant
        /// </summary>
        public Races Army
        {
            get
            { 
                return _army; 
            }
            set
            {
                _army = value;
                verticalLabel.Text = EnumParser.GetDescription(_army);
            }
        }

        /// <summary>
        /// The name of the opposing army
        /// </summary>
        [Category("VerticalLabel"), Description("Text is displayed vertically in container")]
        public override string Text
        {
            get
            {
                return verticalLabel.Text;
            }
            set
            {
                verticalLabel.Text = value;
            }
        }

        #endregion

        #region Constructor

        public OpposingArmyLabel()
        {
            InitializeComponent();
            verticalLabel.TextAlign = ContentAlignment.BottomCenter;
        }

        #endregion

        #region Event Handlers
        
        private void verticalLabel_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }

        #endregion
    }
}
