using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije.ZanrSO
{
    public class VratiSveZanroveSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            List<Domen.Zanr> zanrovi = broker.Vrati(domenskiObjekat)
                                                     .OfType<Domen.Zanr>()
                                                     .ToList();
            return zanrovi;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Domen.Zanr))
            {
                throw new ArgumentException();
            }
        }
    }
}
