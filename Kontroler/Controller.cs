using System;
using System.Collections.Generic;
using DbBroker;
using Domen;
using SistemskeOperacije;
using SistemskeOperacije.BibliotekarSO;
using SistemskeOperacije.ClanSO;
using SistemskeOperacije.IznajmljivanjeSO;
using SistemskeOperacije.KnjigaSO;
using SistemskeOperacije.ZanrSO;

namespace Kontroler
{
    public class Controller
    {
        private Broker broker = new Broker();
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        public Bibliotekar Prijava(Bibliotekar bibliotekar)
        {
            OpstaSistemskaOperacija operacija = new PrijavaSO();
            Bibliotekar dbBibliotekar = (Bibliotekar)operacija.IzvrsiSO(bibliotekar);
            return dbBibliotekar;
        }

        public bool KreirajClana(Clan clan)
        {
            OpstaSistemskaOperacija operacija = new KreirajClanaSO();
            return (bool)operacija.IzvrsiSO(clan);
        }

        public List<Clan> VratiSveClanove()
        {
            OpstaSistemskaOperacija operacija = new VratiSveClanoveSO();
            List<Clan> clanovi = (List<Clan>)operacija.IzvrsiSO(new Clan());
            return clanovi;
        }

        public bool IzmeniKnjigu(Knjiga knjiga)
        {
            OpstaSistemskaOperacija operacija = new IzmeniKnjiguSO();
            return (bool)operacija.IzvrsiSO(knjiga);
        }

        public bool KreirajKnjigu(Knjiga knjiga)
        {
            OpstaSistemskaOperacija operacija = new KreirajKnjiguSO();
            return (bool)operacija.IzvrsiSO(knjiga);
        }

        public List<Knjiga> PronadjiKnjige(Knjiga knjiga)
        {
            OpstaSistemskaOperacija operacija = new NadjiKnjigeSO();
            List<Knjiga> knjige = (List<Knjiga>)operacija.IzvrsiSO(knjiga);
            return knjige;
        }

        public bool ObrisiKnjigu(Knjiga knjiga)
        {
            OpstaSistemskaOperacija operacija = new ObrisiKnjiguSO();
            return (bool)operacija.IzvrsiSO(knjiga);
        }

        public Knjiga UcitajKnjigu(Knjiga knjiga)
        {
            OpstaSistemskaOperacija operacija = new UcitajKnjiguSO();
            return (Knjiga)operacija.IzvrsiSO(knjiga);
        }

        public List<Knjiga> VratiSveKnjige()
        {
            OpstaSistemskaOperacija operacija = new VratiSveKnjigeSO();
            List<Knjiga> knjige = (List<Knjiga>)operacija.IzvrsiSO(new Knjiga());
            return knjige;
        }

        public List<Zanr> VratiSveZanrove()
        {
            OpstaSistemskaOperacija operacija = new VratiSveZanroveSO();
            List<Zanr> zanrovi = (List<Zanr>)operacija.IzvrsiSO(new Zanr());
            return zanrovi;
        }

        public bool KreirajIznajmljivanje(List<Iznajmljivanje> iznajmljivanja)
        {
            OpstaSistemskaOperacija operacija = new KreirajIznajmljivanjeSO(iznajmljivanja);
            return (bool)operacija.IzvrsiSO(new Iznajmljivanje());
        }

        public bool ObrisiIznajmljivanje(List<Iznajmljivanje> iznajmljivanja)
        {
            OpstaSistemskaOperacija operacija = new ObrisiIznajmljivanjeSO(iznajmljivanja);
            return (bool)operacija.IzvrsiSO(new Iznajmljivanje());
        }

        public List<Iznajmljivanje> VratiSvaIznajmljivanja()
        {
            OpstaSistemskaOperacija operacija = new VratiSvaIznajmljivanjaSO();
            List<Iznajmljivanje> iznajmljivanja = (List<Iznajmljivanje>)operacija.IzvrsiSO(new Iznajmljivanje());
            return iznajmljivanja;
        }

        public List<Clan> PronadjiClanove(Clan clan)
        {
            OpstaSistemskaOperacija operacija = new PronadjiClanoveSO();
            List<Clan> clanovi = (List<Clan>)operacija.IzvrsiSO(clan);
            return clanovi;
        }

        public List<Iznajmljivanje> PronadjiIznajmljivanja(Iznajmljivanje iznajmljivanje)
        {
            OpstaSistemskaOperacija operacija = new PronadjiIznajmljivanjaSO();
            List<Iznajmljivanje> iznajmljivanja = (List<Iznajmljivanje>)operacija.IzvrsiSO(iznajmljivanje);
            return iznajmljivanja;
        }
    }
}
