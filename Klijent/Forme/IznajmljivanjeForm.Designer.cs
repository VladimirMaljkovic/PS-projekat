namespace Klijent.Forme
{
    partial class IznajmljivanjeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClan = new System.Windows.Forms.ComboBox();
            this.dgvKnjige = new System.Windows.Forms.DataGridView();
            this.dgvKnjigeZaIznajmljivanje = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzbaci = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDatumIznajmljivanja = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjigeZaIznajmljivanje)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Knjige u ponudi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Knjige za iznajmljivanje";
            // 
            // cbClan
            // 
            this.cbClan.FormattingEnabled = true;
            this.cbClan.Location = new System.Drawing.Point(167, 62);
            this.cbClan.Name = "cbClan";
            this.cbClan.Size = new System.Drawing.Size(167, 24);
            this.cbClan.TabIndex = 3;
            // 
            // dgvKnjige
            // 
            this.dgvKnjige.AllowUserToAddRows = false;
            this.dgvKnjige.AllowUserToDeleteRows = false;
            this.dgvKnjige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnjige.Location = new System.Drawing.Point(167, 136);
            this.dgvKnjige.Name = "dgvKnjige";
            this.dgvKnjige.RowTemplate.Height = 24;
            this.dgvKnjige.Size = new System.Drawing.Size(416, 103);
            this.dgvKnjige.TabIndex = 4;
            // 
            // dgvKnjigeZaIznajmljivanje
            // 
            this.dgvKnjigeZaIznajmljivanje.AllowUserToAddRows = false;
            this.dgvKnjigeZaIznajmljivanje.AllowUserToDeleteRows = false;
            this.dgvKnjigeZaIznajmljivanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnjigeZaIznajmljivanje.Location = new System.Drawing.Point(167, 259);
            this.dgvKnjigeZaIznajmljivanje.Name = "dgvKnjigeZaIznajmljivanje";
            this.dgvKnjigeZaIznajmljivanje.RowTemplate.Height = 24;
            this.dgvKnjigeZaIznajmljivanje.Size = new System.Drawing.Size(416, 103);
            this.dgvKnjigeZaIznajmljivanje.TabIndex = 5;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(589, 158);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(121, 58);
            this.btnDodaj.TabIndex = 6;
            this.btnDodaj.Text = "Dodaj knjigu za iznajmljivanje";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzbaci
            // 
            this.btnIzbaci.Location = new System.Drawing.Point(589, 268);
            this.btnIzbaci.Name = "btnIzbaci";
            this.btnIzbaci.Size = new System.Drawing.Size(121, 29);
            this.btnIzbaci.TabIndex = 7;
            this.btnIzbaci.Text = "Izbaci knjigu";
            this.btnIzbaci.UseVisualStyleBackColor = true;
            this.btnIzbaci.Click += new System.EventHandler(this.btnIzbaci_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(589, 316);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(121, 46);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sacuvaj Iznajmljivanje";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Datum";
            // 
            // dtpDatumIznajmljivanja
            // 
            this.dtpDatumIznajmljivanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumIznajmljivanja.Location = new System.Drawing.Point(437, 65);
            this.dtpDatumIznajmljivanja.Name = "dtpDatumIznajmljivanja";
            this.dtpDatumIznajmljivanja.Size = new System.Drawing.Size(111, 22);
            this.dtpDatumIznajmljivanja.TabIndex = 10;
            // 
            // IznajmljivanjeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(715, 422);
            this.Controls.Add(this.dtpDatumIznajmljivanja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnIzbaci);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dgvKnjigeZaIznajmljivanje);
            this.Controls.Add(this.dgvKnjige);
            this.Controls.Add(this.cbClan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IznajmljivanjeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IznajmljivanjeForm";
            this.Load += new System.EventHandler(this.IznajmljivanjeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjigeZaIznajmljivanje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClan;
        private System.Windows.Forms.DataGridView dgvKnjige;
        private System.Windows.Forms.DataGridView dgvKnjigeZaIznajmljivanje;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzbaci;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDatumIznajmljivanja;
    }
}