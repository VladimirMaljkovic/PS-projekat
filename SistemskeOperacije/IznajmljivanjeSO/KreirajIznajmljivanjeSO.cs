using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class KreirajIznajmljivanjeSO : OpstaSistemskaOperacija
    {
        List<Iznajmljivanje> iznajmljivanja;

        public KreirajIznajmljivanjeSO(List<Iznajmljivanje> iznajmljivanja)
        {
            this.iznajmljivanja = iznajmljivanja;
        }

        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            bool signal = true;

            iznajmljivanja.ForEach(iznajmljivanje =>
            {
                signal = signal && broker.Sacuvaj(iznajmljivanje)>0;

                var knjiga = iznajmljivanje?.Knjiga;

                knjiga.Stanje--;

                signal = signal && broker.Azuriraj(knjiga) > 0;
            });

            var clan = iznajmljivanja.FirstOrDefault()?.Clan;

            if ((bool)!clan?.DugujeKnjige)
            {
                clan.DugujeKnjige = true;

                signal = signal && broker.Azuriraj(clan) > 0;
            }

            if (!signal)
            {
                throw new Exception("Neuspesno cuvanje");
            }

            return signal;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {

            iznajmljivanja.ForEach(iznajmljivanje =>
            {
                if (iznajmljivanje.Knjiga.Stanje <= 0)
                    throw new Exception($"Knjiga {iznajmljivanje.Knjiga.NazivKnjige} ne postoji na stanju");
            });
        }
    }
}
