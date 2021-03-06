using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace SistemskeOperacije.KnjigaSO
{
    public class IzmeniKnjiguSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            return broker.Azuriraj((Domen.Knjiga)domenskiObjekat) > 0;
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
