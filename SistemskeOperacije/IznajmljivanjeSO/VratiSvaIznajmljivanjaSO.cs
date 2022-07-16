using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije
{
    public class VratiSvaIznajmljivanjaSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            List<Domen.Iznajmljivanje> iznajmljivanja = broker.Vrati(domenskiObjekat)
                                                     .OfType<Domen.Iznajmljivanje>()
                                                     .ToList();
            return iznajmljivanja;
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
