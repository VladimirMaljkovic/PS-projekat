using Klijent.Kontroleri;
using System;
using System.Windows.Forms;

namespace Klijent.Forme
{
    public partial class VracanjeForm : Form
    {
        private object clan;

        public VracanjeForm(object clan)
        {
            InitializeComponent();

            this.clan = clan;
        }

        private void btnDodaj_Click(object sender, System.EventArgs e)
        {
            try
            {
                var knjiga = dgvKnjige.SelectedRows[0];

                if (knjiga != null)
                {
                    VracanjeKontroler.Instance.DodajKnjigu(knjiga.DataBoundItem);
                    dgvKnjige.Refresh();
                    dgvKnjigeZaVracanje.Refresh();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Izaberite knjigu za vracanje");
            }
        }

        private void btnIzbaci_Click(object sender, System.EventArgs e)
        {
            try
            {
                var knjiga = dgvKnjigeZaVracanje.SelectedRows[0];

                if (knjiga != null)
                {
                    VracanjeKontroler.Instance.IzbaciKnjigu(knjiga.DataBoundItem);
                    dgvKnjige.Refresh();
                    dgvKnjigeZaVracanje.Refresh();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Izaberite knjigu koju zelite da izbacite");
            }
        }

        private void btnSacuvaj_Click(object sender, System.EventArgs e)
        {
            if (VracanjeKontroler.Instance.VratiKnjige(clan, dtpDatumIznajmljivanja.Value))
            {
                MessageBox.Show("Knjige uspesno vracene");
            }
            else
            {
                MessageBox.Show("Vracanje nije uspesno");
            }
            this.Close();
        }

        private void VracanjeForm_Load(object sender, System.EventArgs e)
        {
            dgvKnjige.DataSource = VracanjeKontroler.Instance.VratiIznajmljivanja(clan);
            dgvKnjige.Columns["stanje"].Visible = false;
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKnjigeZaVracanje.DataSource = VracanjeKontroler.Instance.KnjigeZaIznajmljivanje();
            dgvKnjigeZaVracanje.Columns["stanje"].Visible = false;
            dgvKnjigeZaVracanje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
