using Domen;
using System;
using System.Linq;

namespace SistemskeOperacije.ClanSO
{
    public class KreirajClanaSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            return broker.Sacuvaj((Domen.Clan)domenskiObjekat) > 0;
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
