namespace Klijent.Forme
{
    partial class VracanjeForm
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
            this.dtpDatumIznajmljivanja = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnIzbaci = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.dgvKnjigeZaVracanje = new System.Windows.Forms.DataGridView();
            this.dgvKnjige = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjigeZaVracanje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjige)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDatumIznajmljivanja
            // 
            this.dtpDatumIznajmljivanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumIznajmljivanja.Location = new System.Drawing.Point(335, 66);
            this.dtpDatumIznajmljivanja.Name = "dtpDatumIznajmljivanja";
            this.dtpDatumIznajmljivanja.Size = new System.Drawing.Size(111, 22);
            this.dtpDatumIznajmljivanja.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Datum";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(582, 304);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(121, 46);
            this.btnSacuvaj.TabIndex = 19;
            this.btnSacuvaj.Text = "Vrati knjige";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnIzbaci
            // 
            this.btnIzbaci.Location = new System.Drawing.Point(582, 256);
            this.btnIzbaci.Name = "btnIzbaci";
            this.btnIzbaci.Size = new System.Drawing.Size(121, 29);
            this.btnIzbaci.TabIndex = 18;
            this.btnIzbaci.Text = "Izbaci knjigu";
            this.btnIzbaci.UseVisualStyleBackColor = true;
            this.btnIzbaci.Click += new System.EventHandler(this.btnIzbaci_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(582, 146);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(121, 58);
            this.btnDodaj.TabIndex = 17;
            this.btnDodaj.Text = "Dodaj knjigu za vracanje";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // dgvKnjigeZaVracanje
            // 
            this.dgvKnjigeZaVracanje.AllowUserToAddRows = false;
            this.dgvKnjigeZaVracanje.AllowUserToDeleteRows = false;
            this.dgvKnjigeZaVracanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnjigeZaVracanje.Location = new System.Drawing.Point(160, 247);
            this.dgvKnjigeZaVracanje.Name = "dgvKnjigeZaVracanje";
            this.dgvKnjigeZaVracanje.RowTemplate.Height = 24;
            this.dgvKnjigeZaVracanje.Size = new System.Drawing.Size(416, 103);
            this.dgvKnjigeZaVracanje.TabIndex = 16;
            // 
            // dgvKnjige
            // 
            this.dgvKnjige.AllowUserToAddRows = false;
            this.dgvKnjige.AllowUserToDeleteRows = false;
            this.dgvKnjige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnjige.Location = new System.Drawing.Point(160, 124);
            this.dgvKnjige.Name = "dgvKnjige";
            this.dgvKnjige.RowTemplate.Height = 24;
            this.dgvKnjige.Size = new System.Drawing.Size(416, 103);
            this.dgvKnjige.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Knjige za iznajmljivanje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Knjige u ponudi";
            // 
            // VracanjeForm
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
            this.Controls.Add(this.dgvKnjigeZaVracanje);
            this.Controls.Add(this.dgvKnjige);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "VracanjeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vracanje";
            this.Load += new System.EventHandler(this.VracanjeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjigeZaVracanje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjige)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDatumIznajmljivanja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnIzbaci;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvKnjigeZaVracanje;
        private System.Windows.Forms.DataGridView dgvKnjige;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}