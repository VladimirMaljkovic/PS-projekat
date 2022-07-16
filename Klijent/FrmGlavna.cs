using Klijent.Forme;
using System;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FrmGlavna : Form
    {
        public FrmGlavna()
        {
            InitializeComponent();
        }

        private void btnPrikazKnjige_Click(object sender, EventArgs e)
        {
            PrikazKnjigaForm form = new PrikazKnjigaForm();
            form.ShowDialog();
        }

        private void btnUnosKnjige_Click(object sender, EventArgs e)
        {
            ObradaKnjigeForm form = new ObradaKnjigeForm(false);
            form.ShowDialog();
        }

        private void btnKlijent_Click(object sender, EventArgs e)
        {
            KreiranjeClanaForm form = new KreiranjeClanaForm();
            form.ShowDialog();
        }

        private void btnIznajmni_Click(object sender, EventArgs e)
        {
            IznajmljivanjeForm form = new IznajmljivanjeForm();
            form.ShowDialog();
        }

        private void btnVrati_Click(object sender, EventArgs e)
        {
            PrikazClanovaForm form = new PrikazClanovaForm();
            form.ShowDialog();
        }
    }
}
