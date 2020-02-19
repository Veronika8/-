namespace Хоккей
{
    partial class ShowResultsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupResultsDG = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupResultsDG)).BeginInit();
            this.SuspendLayout();
            // 
            // groupResultsDG
            // 
            this.groupResultsDG.AllowUserToAddRows = false;
            this.groupResultsDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupResultsDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResultsDG.Location = new System.Drawing.Point(0, 0);
            this.groupResultsDG.Name = "groupResultsDG";
            this.groupResultsDG.ReadOnly = true;
            this.groupResultsDG.Size = new System.Drawing.Size(543, 261);
            this.groupResultsDG.TabIndex = 0;
            // 
            // ShowResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 261);
            this.Controls.Add(this.groupResultsDG);
            this.Name = "ShowResultsForm";
            this.Text = "ShowResultsForm";
            ((System.ComponentModel.ISupportInitialize)(this.groupResultsDG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView groupResultsDG;
    }
}