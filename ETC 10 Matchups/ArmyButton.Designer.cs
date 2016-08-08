namespace ETC10Matchups
{
    partial class ArmyButton
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
            this.imgArmy = new System.Windows.Forms.PictureBox();
            this.lblArmy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgArmy)).BeginInit();
            this.SuspendLayout();
            // 
            // imgArmy
            // 
            this.imgArmy.Location = new System.Drawing.Point(0, 0);
            this.imgArmy.Name = "imgArmy";
            this.imgArmy.Size = new System.Drawing.Size(120, 90);
            this.imgArmy.TabIndex = 0;
            this.imgArmy.TabStop = false;
            this.imgArmy.Click += new System.EventHandler(this.buttonClick);
            // 
            // lblArmy
            // 
            this.lblArmy.Location = new System.Drawing.Point(0, 90);
            this.lblArmy.Name = "lblArmy";
            this.lblArmy.Size = new System.Drawing.Size(120, 20);
            this.lblArmy.TabIndex = 1;
            this.lblArmy.Text = "Army";
            this.lblArmy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblArmy.UseMnemonic = false;
            this.lblArmy.Click += new System.EventHandler(this.buttonClick);
            // 
            // ArmyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblArmy);
            this.Controls.Add(this.imgArmy);
            this.Name = "ArmyButton";
            this.Size = new System.Drawing.Size(120, 110);
            this.Load += new System.EventHandler(this.ArmyButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgArmy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgArmy;
        private System.Windows.Forms.Label lblArmy;
    }
}
