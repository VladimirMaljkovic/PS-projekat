using Domen;
using Klijent.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Klijent.Kontroleri
{
    public class PrikazKnjigeKontroler
    {
        public static BindingList<Knjiga> Knjige = new BindingList<Knjiga>();

        private static PrikazKnjigeKontroler instance;
        public static PrikazKnjigeKontroler Instance
        {
            get
            {
                if (instance == null) instance = new PrikazKnjigeKontroler();
                return instance;
            }
        }

        internal void PretraziKnjige(string naziv, string autor)
        {
            var knjige = Komunikacija.Instance.PretraziKnjige(new Knjiga
            {
                NazivKnjige = naziv,
                AutorKnjige = autor
            });

            SrediListuKnjiga(knjige);
        }

        internal bool IzmeniKnjigu(object dgvRowKnjiga)  //lazy loading
        {
            Knjiga knjiga = dgvRowKnjiga as Knjiga;

            Knjiga dbKnjiga = Komunikacija.Instance.UcitajKnjigu(knjiga);

            if(dbKnjiga != null)
            {
                ObradaKnjigeForm form = new ObradaKnjigeForm(true, dbKnjiga.KnjigaId, dbKnjiga.NazivKnjige, dbKnjiga.AutorKnjige, dbKnjiga.Stanje, dbKnjiga.Zanr);
                form.ShowDialog();
                return true;
            }
            else
            {
                return false;
            }

           
        }

        private static void SrediListuKnjiga(List<Knjiga> knjige)
        {
            Knjige.Clear();

            knjige?.ForEach(knjiga =>
            {
                Knjige.Add(knjiga);
            });
        }

        public object VratiSveKnjige()
        {
            SrediListuKnjiga(Komunikacija.Instance.VratiSveKnjige());

            return Knjige;
        }

        internal bool ObrisiKnjigu(object knjiga)
        {
            return Komunikacija.Instance.ObrisiKnjigu(knjiga as Knjiga);
        }
    }
}
