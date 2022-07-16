using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije.KnjigaSO
{
    public class VratiSveKnjigeSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            List<Domen.Knjiga> knjige = broker.Vrati(domenskiObjekat)
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
