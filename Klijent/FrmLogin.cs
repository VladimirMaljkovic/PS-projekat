using Klijent.Kontroleri;
using System;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FrmLogin : Form
    {
        LoginKontroler loginKontroler = new LoginKontroler();
        public FrmLogin()
        {
            
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (loginKontroler.PovezivanjeNaServer())
            {
                MessageBox.Show("Uspesno povezivanje");
            }
            else
            {
                MessageBox.Show("Neuspesno povezivanje");
                Environment.Exit(0);
                return;
            }

            if (loginKontroler.Login(txtKorisnickoIme.Text, txtLozinka.Text))
            {
                MessageBox.Show("Uspesna prijava");
                FrmGlavna form = new FrmGlavna();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pogresni kredencijali za prijavu");
            }
        }
    }
}
