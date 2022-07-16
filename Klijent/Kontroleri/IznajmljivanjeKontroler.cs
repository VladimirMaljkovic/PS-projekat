using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Klijent.Kontroleri
{
    public class IznajmljivanjeKontroler
    {
        public static BindingList<Knjiga> Knjige = new BindingList<Knjiga>();

        public static BindingList<Knjiga> KnjigeZaIznajmljivanjeList = new BindingList<Knjiga>();

        private static IznajmljivanjeKontroler instance;
        public static IznajmljivanjeKontroler Instance
        {
            get
            {
                if (instance == null) instance = new IznajmljivanjeKontroler();
                return instance;
            }
        }

        internal BindingList<Knjiga> KnjigeZaIznajmljivanje()
        {
            KnjigeZaIznajmljivanjeList.Clear();

            return KnjigeZaIznajmljivanjeList;
        }

        internal List<Clan> VratiClanove()
        {
            return Komunikacija.Instance.VratiSveClanove();
        }

        internal BindingList<Knjiga> VratiKnjige()
        {
            Knjige.Clear();

            var knjige = Komunikacija.Instance.VratiSveKnjige();

            knjige?.ForEach(knjiga =>
            {
                Knjige.Add(knjiga);
            });

            return Knjige;
        }

        internal void DodajKnjigu(object dgvRowKnjiga)
        {
            var knjiga = dgvRowKnjiga as Knjiga;   

            if (knjiga != null)
            {
                Knjige.Remove(knjiga);
                KnjigeZaIznajmljivanjeList.Add(knjiga);
            }
        }

        internal void IzbaciKnjigu(object dgvRowKnjiga)
        {
            var knjiga = dgvRowKnjiga as Knjiga;

            if (knjiga != null)
            {
                KnjigeZaIznajmljivanjeList.Remove(knjiga);
                Knjige.Add(knjiga);
            }
        }

        internal bool SacuvajIznajmljivanje(object clan, DateTime datum)
        {
            List<Iznajmljivanje> iznajmljivanja = new List<Iznajmljivanje>();

            KnjigeZaIznajmljivanjeList.ToList().ForEach(knjiga =>
            {
                iznajmljivanja.Add(new Iznajmljivanje
                {
                    DatumIzdavanja = datum,
                    Clan = clan as Clan,
                    Knjiga = knjiga,
                    Bibliotekar = Komunikacija.Instance.logovaniBibliotekar
                });
            });

            return Komunikacija.Instance.UnosIznajmljivanje(iznajmljivanja);
        }
    }
}
