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
            this.lvKlientet = new System.Windows.Forms.ListView();
            this.Klienti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvFaturat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboAccessData
            // 
            this.cboAccessData.FormattingEnabled = true;
            this.cboAccessData.Location = new System.Drawing.Point(106, 106);
            this.cboAccessData.Name = "cboAccessData";
            this.cboAccessData.Size = new System.Drawing.Size(212, 21);
            this.cboAccessData.TabIndex = 0;
            // 
            // btnParaqit
            // 
            this.btnParaqit.Location = new System.Drawing.Point(12, 155);
            this.btnParaqit.Name = "btnParaqit";
            this.btnParaqit.Size = new System.Drawing.Size(75, 23);
            this.btnParaqit.TabIndex = 1;
            this.btnParaqit.Text = "Paraqit";
            this.btnParaqit.UseVisualStyleBackColor = true;
            this.btnParaqit.Click += new System.EventHandler(this.btnParaqit_Click);
            // 
            // lvKlientet
            // 
            this.lvKlientet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Klienti,
            this.columnHeader2,
            this.columnHeader3});
            this.lvKlientet.FullRowSelect = true;
            this.lvKlientet.GridLines = true;
            this.lvKlientet.Location = new System.Drawing.Point(12, 184);
            this.lvKlientet.Name = "lvKlientet";
            this.lvKlientet.Size = new System.Drawing.Size(512, 215);
            this.lvKlientet.TabIndex = 2;
            this.lvKlientet.UseCompatibleStateImageBehavior = false;
            this.lvKlientet.View = System.Windows.Forms.View.Details;
            this.lvKlientet.SelectedIndexChanged += new System.EventHandler(this.lvKlientet_SelectedIndexChanged);
            // 
            // Klienti
            // 
            this.Klienti.Text = "Klienti";
            this.Klienti.Width = 188;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adresa";
            this.columnHeader2.Width = 135;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Numri i faturave";
            this.columnHeader3.Width = 92;
            // 
            // lvFaturat
            // 
            this.lvFaturat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5});
            this.lvFaturat.FullRowSelect = true;
            this.lvFaturat.GridLines = true;
            this.lvFaturat.Location = new System.Drawing.Point(530, 185);
            this.lvFaturat.Name = "lvFaturat";
            this.lvFaturat.Size = new System.Drawing.Size(366, 215);
            this.lvFaturat.TabIndex = 3;
            this.lvFaturat.UseCompatibleStateImageBehavior = false;
            this.lvFaturat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nurmi";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Data";
            this.columnHeader4.Width = 179;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Shuma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Menyra e kycjes:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 87);
            this.panel1.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(93, 155);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Shto";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(174, 155);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Ndrysho";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(324, 104);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 8;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 412);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvFaturat);
            this.Controls.Add(this.lvKlientet);
            this.Controls.Add(this.btnParaqit);
            this.Controls.Add(this.cboAccessData);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAccessData;
        private System.Windows.Forms.Button btnParaqit;
        private System.Windows.Forms.ListView lvKlientet;
        private System.Windows.Forms.ListView lvFaturat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader Klienti;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDebug;
    }
}

