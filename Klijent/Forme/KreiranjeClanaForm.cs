using Klijent.Kontroleri;
using System;
using System.Windows.Forms;

namespace Klijent.Forme
{
    public partial class KreiranjeClanaForm : Form
    {
        public KreiranjeClanaForm()
        {
            InitializeComponent();
        }

        private void btnObrada_Click(object sender, EventArgs e)
        {
            if (UnosClanaKontroler.Instance.UnosClana(txtIme.Text, txtPrezime.Text, cbTip.SelectedItem, dtpUclanjenje.Value)){
                MessageBox.Show("Nov korisnik je kreiran");
            }
            else
            {
                MessageBox.Show("Nov clan nije sacuvan");
            }
        }
    }
}
