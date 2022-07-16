using Domen;
using Klijent.Forme;
using System;
using System.ComponentModel;
using System.Linq;

namespace Klijent.Kontroleri
{
    public class PrikazClanovaKontroler
    {
        public static BindingList<Clan> Clanovi = new BindingList<Clan>();

        private static PrikazClanovaKontroler instance;
        public static PrikazClanovaKontroler Instance
        {
            get
            {
                if (instance == null) instance = new PrikazClanovaKontroler();
                return instance;
            }
        }

        internal object VratiSveClanove()
        {
            Clanovi.Clear();

            Komunikacija.Instance.VratiSveClanove()?.ForEach(clan =>
            {
                if (clan.DugujeKnjige)
                {
                    Clanovi.Add(clan);
                }
            });

            return Clanovi;
        }

        internal bool PretraziClanove(string ime, string prezime)
        {
            Clanovi.Clear();

            Komunikacija.Instance.PretraziClanove(new Clan
            {
                Ime = ime,
                Prezime = prezime
            })
                                ?.ForEach(clan =>
                                        {
                                            if (clan.DugujeKnjige)
                                            {
                                                Clanovi.Add(clan);
                                            }
                                        });

            return (bool)(Clanovi?.Any());
        }

        internal void PrikaziIznajmljivanja(object clan)
        {
            VracanjeForm form = new VracanjeForm(clan);
            form.ShowDialog();
        }
    }
}
