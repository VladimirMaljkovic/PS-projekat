using System;
using System.Collections.Generic;
using System.Linq;
using Domen;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.ClanSO
{
    public class VratiSveClanoveSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            List<Domen.Clan> clanovi = broker.Vrati(domenskiObjekat)
                                                     .OfType<Domen.Clan>()
                                                     .ToList();
            return clanovi;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Domen.Clan))
            {
                throw new ArgumentException();
            }
        }
    }
}
