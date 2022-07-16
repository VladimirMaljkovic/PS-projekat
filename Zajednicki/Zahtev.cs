using Domen;
using System;
using System.Collections.Generic;

namespace Zajednicki
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public Bibliotekar Bibliotekar { get; set; }
        public Clan Clan { get; set; }
        public Iznajmljivanje Iznajmljivanje { get; set; }
        public Knjiga Knjiga { get; set; }
        public Zanr Zanr { get; set; }
        public List<Iznajmljivanje> Iznajmljivanja { get; set; }
    }
    public enum Operacija
    {
        Login,
        KreirajClana,
        VratiSveClanove,
        IzmeniKnjigu,
        KreirajKnjigu,
        NadjiKnjige,
        ObrisiKnjigu,
        UcitajKnjigu,
        VratiSveKnjige,
        VratiSveZanrove,
        KreirajIznajmljivanje,
        ObrisiIznajmljivanje,
        VratiSvaIznajmljivanja,
        NadjiClanove,
        NadjiIznajmljivanja,
    }

}
