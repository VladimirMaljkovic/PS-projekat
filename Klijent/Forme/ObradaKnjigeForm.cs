using Klijent.Kontroleri;
using System;
using System.Windows.Forms;

namespace Klijent.Forme
{
    public partial class ObradaKnjigeForm : Form
    {
        private bool izmena;

        private object zanr;

        public ObradaKnjigeForm(bool izmena)
        {
            InitializeComponent();

            this.izmena = izmena;
        }

        public ObradaKnjigeForm(bool izmena, int id, string naziv, string autor, int stanje, object zanr)
        {
            InitializeComponent();

            this.izmena = izmena;

            txtKnjiga.Text = id.ToString();
            txtNaziv.Text = naziv;
            txtAutor.Text = autor;
            numStanje.Value = stanje;
            this.zanr = zanr;
        }

        private void VracanjeForm_Load(object sender, EventArgs e)
        {
            var zanrovi = ObradaKnjigaKontroler.Instance.VratiSveZanrove();
            cbZanr.DataSource = zanrovi;

            if (izmena)
            {
                btnObrada.Text = "Izmeni";
                ObradaKnjigaKontroler.Instance.PostaviZanr(zanr, zanrovi, ref cbZanr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (izmena) 
            {
                if (ObradaKnjigaKontroler.Instance.IzmeniKnjigu(txtKnjiga.Text, txtNaziv.Text, txtAutor.Text, (int)numStanje.Value, cbZanr.SelectedItem))
                {
                    MessageBox.Show("Izmene su sacuvane");
                }
                else
                {
                    MessageBox.Show("Izmene nisu sacuvane");
                }
            }
            else
            {
                if (ObradaKnjigaKontroler.Instance.UnosKnjige(txtNaziv.Text, txtAutor.Text, (int)numStanje.Value, cbZanr.SelectedItem))
                {
                    MessageBox.Show("Nova knjiga je uneta u sistem");
                }
                else
                {
                    MessageBox.Show("Nova knjiga nije sacuvana");
                }
            }
        }
    }
}
