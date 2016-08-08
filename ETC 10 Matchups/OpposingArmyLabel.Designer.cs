namespace ETC10Matchups
{
    partial class OpposingArmyLabel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.verticalLabel = new ETC10Matchups.VerticalLabel();
            this.SuspendLayout();
            // 
            // verticalLabel
            // 
            this.verticalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.verticalLabel.Location = new System.Drawing.Point(0, 16);
            this.verticalLabel.Name = "verticalLabel";
            this.verticalLabel.Size = new System.Drawing.Size(30, 124);
            this.verticalLabel.TabIndex = 0;
            this.verticalLabel.Text = null;
            this.verticalLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.verticalLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.verticalLabel_MouseClick);
            // 
            // OpposingArmyLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.verticalLabel);
            this.Name = "OpposingArmyLabel";
            this.Size = new System.Drawing.Size(30, 140);
            this.ResumeLayout(false);

        }

        #endregion

        private VerticalLabel verticalLabel;
    }
}
