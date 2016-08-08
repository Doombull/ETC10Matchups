namespace ETC10Matchups
{
    partial class CountrySelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountrySelect));
            this.btnNext = new System.Windows.Forms.Button();
            this.imgBackground = new System.Windows.Forms.PictureBox();
            this.cmbCountries = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewCountry = new System.Windows.Forms.TextBox();
            this.btnNewCountry = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEditCountry = new System.Windows.Forms.ComboBox();
            this.btnChangeArmies = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(423, 287);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(96, 25);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // imgBackground
            // 
            this.imgBackground.Image = ((System.Drawing.Image)(resources.GetObject("imgBackground.Image")));
            this.imgBackground.Location = new System.Drawing.Point(-367, 178);
            this.imgBackground.Name = "imgBackground";
            this.imgBackground.Size = new System.Drawing.Size(400, 400);
            this.imgBackground.TabIndex = 20;
            this.imgBackground.TabStop = false;
            // 
            // cmbCountries
            // 
            this.cmbCountries.FormattingEnabled = true;
            this.cmbCountries.Location = new System.Drawing.Point(151, 291);
            this.cmbCountries.MaxDropDownItems = 25;
            this.cmbCountries.Name = "cmbCountries";
            this.cmbCountries.Size = new System.Drawing.Size(239, 21);
            this.cmbCountries.TabIndex = 21;
            this.cmbCountries.SelectedIndexChanged += new System.EventHandler(this.cmbCountries_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Add a New Country";
            // 
            // txtNewCountry
            // 
            this.txtNewCountry.Location = new System.Drawing.Point(151, 57);
            this.txtNewCountry.Name = "txtNewCountry";
            this.txtNewCountry.Size = new System.Drawing.Size(239, 20);
            this.txtNewCountry.TabIndex = 24;
            this.txtNewCountry.TextChanged += new System.EventHandler(this.txtNewCountry_TextChanged);
            // 
            // btnNewCountry
            // 
            this.btnNewCountry.Enabled = false;
            this.btnNewCountry.Location = new System.Drawing.Point(423, 57);
            this.btnNewCountry.Name = "btnNewCountry";
            this.btnNewCountry.Size = new System.Drawing.Size(96, 23);
            this.btnNewCountry.TabIndex = 25;
            this.btnNewCountry.Text = "Add";
            this.btnNewCountry.UseVisualStyleBackColor = true;
            this.btnNewCountry.Click += new System.EventHandler(this.btnNewCountry_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Edit an Existing Country";
            // 
            // cmbEditCountry
            // 
            this.cmbEditCountry.FormattingEnabled = true;
            this.cmbEditCountry.Location = new System.Drawing.Point(151, 167);
            this.cmbEditCountry.MaxDropDownItems = 25;
            this.cmbEditCountry.Name = "cmbEditCountry";
            this.cmbEditCountry.Size = new System.Drawing.Size(239, 21);
            this.cmbEditCountry.TabIndex = 27;
            this.cmbEditCountry.SelectedIndexChanged += new System.EventHandler(this.cmbEditCountry_SelectedIndexChanged);
            // 
            // btnChangeArmies
            // 
            this.btnChangeArmies.Enabled = false;
            this.btnChangeArmies.Location = new System.Drawing.Point(423, 167);
            this.btnChangeArmies.Name = "btnChangeArmies";
            this.btnChangeArmies.Size = new System.Drawing.Size(96, 23);
            this.btnChangeArmies.TabIndex = 28;
            this.btnChangeArmies.Text = "Change Armies";
            this.btnChangeArmies.UseVisualStyleBackColor = true;
            this.btnChangeArmies.Click += new System.EventHandler(this.btnChangeArmies_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(423, 196);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 23);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "View Matchups";
            // 
            // CountrySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChangeArmies);
            this.Controls.Add(this.cmbEditCountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNewCountry);
            this.Controls.Add(this.txtNewCountry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCountries);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.imgBackground);
            this.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Name = "CountrySelect";
            this.Size = new System.Drawing.Size(563, 500);
            this.Load += new System.EventHandler(this.CountrySelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox imgBackground;
        private System.Windows.Forms.ComboBox cmbCountries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewCountry;
        private System.Windows.Forms.Button btnNewCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEditCountry;
        private System.Windows.Forms.Button btnChangeArmies;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
    }
}
