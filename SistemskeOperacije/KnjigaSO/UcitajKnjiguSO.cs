using Domen;
using System;
using System.Linq;

namespace SistemskeOperacije.KnjigaSO
{
    public class UcitajKnjiguSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            var knjiga = (Domen.Knjiga)domenskiObjekat;
            return broker.Vrati(knjiga)
                         .OfType<Knjiga>()
                         .ToList()
                         .First(knjigaIzListe => knjigaIzListe.KnjigaId== knjiga.KnjigaId);
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Knjiga))
            {
                throw new ArgumentException();
            }
        }
    }
}
