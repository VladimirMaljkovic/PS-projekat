using Domen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemskeOperacije
{
    public class ObrisiIznajmljivanjeSO : OpstaSistemskaOperacija
    {
        List<Iznajmljivanje> iznajmljivanja;

        public ObrisiIznajmljivanjeSO(List<Iznajmljivanje> iznajmljivanja)
        {
            this.iznajmljivanja = iznajmljivanja;
        }

        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            bool signal = true;
            iznajmljivanja.ForEach(i =>
            {
                i.DatumVracanja = DateTime.Now;
                signal = signal && broker.Azuriraj(i) > 0;

                i.Knjiga.Stanje++;
                signal = signal && broker.Azuriraj(i.Knjiga) > 0;
            });

            var clan = iznajmljivanja.FirstOrDefault()?.Clan;

            if ((bool)!clan?.DugujeKnjige)
            {
                clan.DugujeKnjige = true;

                signal = signal && broker.Azuriraj(clan) > 0;
            }

            signal = signal && broker.Azuriraj(clan) > 0;

            if (!signal)
            {
                throw new Exception("Neuspesno brisanje");
            }

            return signal;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Domen.Iznajmljivanje))
            {
                throw new ArgumentException();
            }
        }
    }
}
