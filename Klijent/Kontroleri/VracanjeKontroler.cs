using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Klijent.Kontroleri
{
    public class VracanjeKontroler
    {
        public static BindingList<Knjiga> Knjige = new BindingList<Knjiga>();

        public static BindingList<Knjiga> KnjigeZaVracanjeist = new BindingList<Knjiga>();

        private static VracanjeKontroler instance;
        public static VracanjeKontroler Instance
        {
            get
            {
                if (instance == null) instance = new VracanjeKontroler();
                return instance;
            }
        }

        internal void DodajKnjigu(object dgvRowKnjiga)
        {
            var knjiga = dgvRowKnjiga as Knjiga;

            if (knjiga != null)
            {
                Knjige.Remove(knjiga);
                KnjigeZaVracanjeist.Add(knjiga);
            }
        }

        internal BindingList<Knjiga> KnjigeZaIznajmljivanje()
        {
            KnjigeZaVracanjeist.Clear();
            return KnjigeZaVracanjeist;
        }

        internal BindingList<Knjiga> VratiIznajmljivanja(object clan)
        {
            Knjige.Clear();

            var iznajmljivanja = Komunikacija.Instance.PretraziIznajmljivanja(new Iznajmljivanje
            {
                Clan = clan as Clan,  //castovanje
            });

            iznajmljivanja?.ForEach(iznajmljivanje =>
            {
                Knjige.Add(iznajmljivanje.Knjiga);
            });

            return Knjige;
        }

        internal void IzbaciKnjigu(object dgvRowKnjiga)
        {
            var knjiga = dgvRowKnjiga as Knjiga;

            if (knjiga != null)
            {
                KnjigeZaVracanjeist.Remove(knjiga);
                Knjige.Add(knjiga);
            }
        }

        internal bool VratiKnjige(object clan, DateTime datum)
        {
            if (!KnjigeZaVracanjeist.Any())
            {
                return false;
            }
            List<Iznajmljivanje> iznajmljivanja = new List<Iznajmljivanje>();

            KnjigeZaVracanjeist.ToList().ForEach(knjiga =>
            {
                iznajmljivanja.Add(new Iznajmljivanje
                {
                    DatumVracanja = datum,
                    Clan = clan as Clan,
                    Knjiga = knjiga,
                    Bibliotekar = Komunikacija.Instance.logovaniBibliotekar
                });
            });

            return Komunikacija.Instance.VracanjeKnjiga(iznajmljivanja);
        }
    }
}
