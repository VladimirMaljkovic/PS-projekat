using Domen;
using System;

namespace Klijent.Kontroleri
{
    internal class UnosClanaKontroler
    {
        private static UnosClanaKontroler instance;
        public static UnosClanaKontroler Instance
        {
            get
            {
                if (instance == null) instance = new UnosClanaKontroler();
                return instance;
            }
        }

        internal bool UnosClana(string ime, string prezime, object tip, DateTime datum)
        {
            return Komunikacija.Instance.UnosClana(new Clan
            {
                Ime = ime,
                Prezime = prezime,
                TipClana = tip as string,
                DatumUclanjenja = datum
            });
        }
    }
}
