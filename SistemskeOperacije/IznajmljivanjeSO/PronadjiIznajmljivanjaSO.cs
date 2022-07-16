using Domen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemskeOperacije.IznajmljivanjeSO
{
    public class PronadjiIznajmljivanjaSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            List<Iznajmljivanje> iznajmmljivanje = broker.Pretrazi(domenskiObjekat)
                                                 .OfType<Iznajmljivanje>()
                                                 .ToList();
            return iznajmmljivanje;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Iznajmljivanje))
            {
                throw new ArgumentException();
            }
        }
    }
}
