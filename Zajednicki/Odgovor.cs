using Domen;
using System;
using System.Collections.Generic;

namespace Zajednicki
{
    [Serializable]
    public class Odgovor
    {
        public Signal Signal { get; set; }
        public Bibliotekar Bibliotekar { get; set; }
        public List<Clan> Clanovi { get; set; }
        public List<Knjiga> Knjige { get; set; }
        public Knjiga Knjiga { get; set; }
        public List<Zanr> Zanrovi { get; set; }
        public List<Iznajmljivanje> Iznajmljivanja { get; set; }
    }
    public enum Signal
    {
        NeuspesnaPretraga,
        UspesnoPrijavljen,
        GreskaUZahtevu,
        KnjigaUspesnoKreirana,
        ClanoviPronadjeni,
        KnjigaUspesnoIzmenjena,
        KnjigaObrisana,
        KnjigaUcitana,
        ClanUspesnoKreirana,
        KnjigePronadjene,
        ZanroviPronadjeni,
        IznajmljivanjeUspesnoKreirano,
        IznajmljivanjaUspesnoVracena,
        IznajmljivanjaPronadjena,
    }
}
