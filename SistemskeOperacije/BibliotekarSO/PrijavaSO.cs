using Domen;
using System;
using System.Linq;

namespace SistemskeOperacije.BibliotekarSO
{
    public class PrijavaSO : OpstaSistemskaOperacija
    {
        protected override object Izvrsavanje(DomenskiObjekat domenskiObjekat)
        {
            Bibliotekar bibliotekar = broker.Pretrazi(domenskiObjekat)
                                            .OfType<Bibliotekar>()
                                            .ToList()
                                            .FirstOrDefault();
            return bibliotekar;
        }

        protected override void Validacija(DomenskiObjekat domenskiObjekat)
        {
            if (!(domenskiObjekat is Bibliotekar))
            {
                throw new ArgumentException();
            }
        }
    }
}
