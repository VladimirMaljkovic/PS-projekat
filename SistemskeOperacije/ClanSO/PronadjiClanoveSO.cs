using Domen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemskeOperacije.ClanSO
{
    public class PronadjiClanoveSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            List<Clan> clanovi = broker.Pretrazi(domenskiObjekat)
                                                 .OfType<Clan>()
                                                 .ToList();
            return clanovi;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Clan))
            {
                throw new ArgumentException();
            }
        }
 
    }
}
