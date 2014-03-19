namespace DataAccessPresentation
{
    partial class MainForm
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
            this.cboAccessData = new System.Windows.Forms.ComboBox();
            this.btnParaqit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboAccessData
            // 
            this.cboAccessData.FormattingEnabled = true;
            this.cboAccessData.Location = new System.Drawing.Point(80, 37);
            this.cboAccessData.Name = "cboAccessData";
            this.cboAccessData.Size = new System.Drawing.Size(212, 21);
            this.cboAccessData.TabIndex = 0;
            // 
            // btnParaqit
            // 
            this.btnParaqit.Location = new System.Drawing.Point(310, 37);
            this.btnParaqit.Name = "btnParaqit";
            this.btnParaqit.Size = new System.Drawing.Size(75, 23);
            this.btnParaqit.TabIndex = 1;
            this.btnParaqit.Text = "Paraqit";
            this.btnParaqit.UseVisualStyleBackColor = true;
            this.btnParaqit.Click += new System.EventHandler(this.btnParaqit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 567);
            this.Controls.Add(this.btnParaqit);
            this.Controls.Add(this.cboAccessData);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAccessData;
        private System.Windows.Forms.Button btnParaqit;
    }
}

