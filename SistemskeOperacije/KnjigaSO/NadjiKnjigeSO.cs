using Domen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemskeOperacije.KnjigaSO
{
    public class NadjiKnjigeSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            List<Domen.Knjiga> knjige = broker.Pretrazi(domenskiObjekat)
                                                 .OfType<Domen.Knjiga>()
                                                 .ToList();
            return knjige;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Domen.Knjiga))
            {
                throw new ArgumentException();
            }
        }
    }
}
