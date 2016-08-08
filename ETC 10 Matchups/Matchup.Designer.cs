namespace ETC10Matchups
{
    partial class Matchup
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miGood = new System.Windows.Forms.ToolStripMenuItem();
            this.miAverage = new System.Windows.Forms.ToolStripMenuItem();
            this.miPoor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miClear = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGood,
            this.miAverage,
            this.miPoor,
            this.toolStripSeparator1,
            this.miClear});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 98);
            // 
            // miGood
            // 
            this.miGood.Name = "miGood";
            this.miGood.Size = new System.Drawing.Size(101, 22);
            this.miGood.Text = "Good";
            this.miGood.Click += new System.EventHandler(this.contextMenuItem_Click);
            // 
            // miAverage
            // 
            this.miAverage.Name = "miAverage";
            this.miAverage.Size = new System.Drawing.Size(101, 22);
            this.miAverage.Text = "Average";
            this.miAverage.Click += new System.EventHandler(this.contextMenuItem_Click);
            // 
            // miPoor
            // 
            this.miPoor.Name = "miPoor";
            this.miPoor.Size = new System.Drawing.Size(101, 22);
            this.miPoor.Text = "Poor";
            this.miPoor.Click += new System.EventHandler(this.contextMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(98, 6);
            // 
            // miClear
            // 
            this.miClear.Name = "miClear";
            this.miClear.Size = new System.Drawing.Size(101, 22);
            this.miClear.Text = "Clear";
            this.miClear.Click += new System.EventHandler(this.contextMenuItem_Click);
            // 
            // Matchup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "Matchup";
            this.Size = new System.Drawing.Size(21, 21);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miGood;
        private System.Windows.Forms.ToolStripMenuItem miAverage;
        private System.Windows.Forms.ToolStripMenuItem miPoor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miClear;
    }
}
