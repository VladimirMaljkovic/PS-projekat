using Domen;

namespace Klijent.Kontroleri
{
    public class LoginKontroler
    {
        internal bool Login(string korisnickoIme, string sifra)
        {
            return Komunikacija.Instance.Login(new Bibliotekar
            {
                KorisnickoIme = korisnickoIme,
                Sifra = sifra
            });
            
        }

        internal bool PovezivanjeNaServer()
        {
            return Komunikacija.Instance.Connect();
        }
    }
}
