using Domen;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Klijent.Kontroleri
{
    public class ObradaKnjigaKontroler
    {
        private static ObradaKnjigaKontroler instance;
        public static ObradaKnjigaKontroler Instance
        {
            get
            {
                if (instance == null) instance = new ObradaKnjigaKontroler();
                return instance;
            }
        }

        public List<Zanr> VratiSveZanrove()
        {
            return Komunikacija.Instance.VratiSveZanrove();
        }

        public void PostaviZanr(object prosledjeniZanr, List<Zanr> zanrovi, ref ComboBox cbZanr)
        {
            foreach (var zanr in zanrovi)
            {
                if (zanr.ToString() == ((Zanr)prosledjeniZanr).ToString())
                {
                    cbZanr.SelectedIndex = zanrovi.IndexOf(zanr);
                    return;
                }
            }
        }

        public bool IzmeniKnjigu(string knjigaId, string naziv, string autor, int stanje, object zanr)
        {
            Knjiga knjiga = new Knjiga
            {
                KnjigaId = int.Parse(knjigaId),
                NazivKnjige = naziv,
                AutorKnjige = autor,
                Stanje = stanje,
                Zanr = zanr as Zanr
            };

            return Komunikacija.Instance.IzmeniKnjigu(knjiga);
        }

        public bool UnosKnjige(string naziv, string autor, int stanje, object zanr)
        {
            Knjiga knjiga = new Knjiga
            {
                NazivKnjige = naziv,
                AutorKnjige = autor,
                Stanje = stanje,
                Zanr = zanr as Zanr
            };

            return Komunikacija.Instance.UnosKnjige(knjiga);
        }
    }
}
