using Klijent.Kontroleri;
using System;
using System.Windows.Forms;

namespace Klijent.Forme
{
    public partial class IznajmljivanjeForm : Form
    {
        public IznajmljivanjeForm()
        {
            InitializeComponent();
        }

        private void IznajmljivanjeForm_Load(object sender, EventArgs e)
        {
            cbClan.DataSource = IznajmljivanjeKontroler.Instance.VratiClanove();

            dgvKnjige.DataSource = IznajmljivanjeKontroler.Instance.VratiKnjige();
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKnjigeZaIznajmljivanje.DataSource = IznajmljivanjeKontroler.Instance.KnjigeZaIznajmljivanje();
            dgvKnjigeZaIznajmljivanje.Columns["stanje"].Visible = false;
            dgvKnjigeZaIznajmljivanje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                var knjiga = dgvKnjige.SelectedRows[0];

                if (knjiga != null)
                {
                    IznajmljivanjeKontroler.Instance.DodajKnjigu(knjiga.DataBoundItem);
                    dgvKnjige.Refresh();
                    dgvKnjigeZaIznajmljivanje.Refresh();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Izaberite knjigu za iznajmljivanje");
            }
        }

        private void btnIzbaci_Click(object sender, EventArgs e)
        {
            try
            {
                var knjiga = dgvKnjigeZaIznajmljivanje.SelectedRows[0];

                if (knjiga != null)
                {
                    IznajmljivanjeKontroler.Instance.IzbaciKnjigu(knjiga.DataBoundItem);
                    dgvKnjige.Refresh();
                    dgvKnjigeZaIznajmljivanje.Refresh();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Izaberite knjigu koju zelite da izbacite");
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (IznajmljivanjeKontroler.Instance.SacuvajIznajmljivanje(cbClan.SelectedItem, dtpDatumIznajmljivanja.Value))
            {
                MessageBox.Show("Knjige uspesno iznajmljene");
                IznajmljivanjeForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Iznajmljivanje nije uspesno");
            }
        }
    }
}
