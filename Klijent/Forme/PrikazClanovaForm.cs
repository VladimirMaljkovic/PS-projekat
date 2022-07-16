using Klijent.Kontroleri;
using System;
using System.Windows.Forms;

namespace Klijent.Forme
{
    public partial class PrikazClanovaForm : Form
    {
        public PrikazClanovaForm()
        {
            InitializeComponent();
        }

        private void PrikazClanovaForm_Load(object sender, EventArgs e)
        {
            dgvClanovi.DataSource = PrikazClanovaKontroler.Instance.VratiSveClanove();
            dgvClanovi.Refresh();
            dgvClanovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            if(!PrikazClanovaKontroler.Instance.PretraziClanove(txtIme.Text, txtPrezime.Text))
            {
                MessageBox.Show("Clan nije pronadjen");
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                var clan = dgvClanovi.SelectedRows[0];
                if (clan != null)
                {
                    PrikazClanovaKontroler.Instance.PrikaziIznajmljivanja(clan.DataBoundItem);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Izaberite clana za prikaz iznajmljivanja");
            }
        }
    }
}
