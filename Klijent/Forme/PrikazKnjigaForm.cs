using Klijent.Kontroleri;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Klijent.Forme
{
    public partial class PrikazKnjigaForm : Form
    {
        public PrikazKnjigaForm()
        {
            InitializeComponent();
        }

        private void btnPretrazi_click(object sender, EventArgs e)
        {
            PretragaSaIzmenom(false);
        }

        private void PretragaSaIzmenom(bool izmena)
        {
            PrikazKnjigeKontroler.Instance.PretraziKnjige(txtKnjiga.Text, txtAutor.Text);

            dgvKnjige.Refresh();
            if (!izmena)
            {
                if (dgvKnjige.Rows.Count <= 0)
                {
                    MessageBox.Show("Knjige nisu pronadjene");
                }
            }
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void PrikazKnjigaForm_Load(object sender, EventArgs e)
        {
            dgvKnjige.DataSource = PrikazKnjigeKontroler.Instance.VratiSveKnjige();
            dgvKnjige.Refresh();
            dgvKnjige.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                var knjiga = dgvKnjige.SelectedRows[0];
                if (knjiga != null)
                {
                    if (!PrikazKnjigeKontroler.Instance.IzmeniKnjigu(knjiga.DataBoundItem))
                    {
                        MessageBox.Show("Ne moze se prikazati izabrana knjiga");
                        return;
                    }
                }
                PretragaSaIzmenom(true);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Izaberite knjigu za izmenu");
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                var knjiga = dgvKnjige.SelectedRows[0];
                if (knjiga != null)
                {
                    if (!PrikazKnjigeKontroler.Instance.ObrisiKnjigu(knjiga.DataBoundItem))
                    {
                        MessageBox.Show("Knjiga nije obrisana");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Knjiga je obrisana");
                    }
                }
                PretragaSaIzmenom(true);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Izaberite knjigu za izmenu");
            }
        }
    }
}
