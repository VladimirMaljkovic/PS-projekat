using Domen;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Zajednicki;

namespace Klijent
{
    public class Komunikacija
    {
        #region Komunikacija

        private static Komunikacija instance;

        private Socket klijentskiSoket;

        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        public Bibliotekar logovaniBibliotekar = new Bibliotekar();        

        public static Komunikacija Instance
        {
            get
            {
                if (instance == null) instance = new Komunikacija();
                return instance;
            }
        }

        internal bool Login(Bibliotekar bibliotekar)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.Login;
                zahtev.Bibliotekar = bibliotekar;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.UspesnoPrijavljen)
                {
                    logovaniBibliotekar = odgovor.Bibliotekar;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal Knjiga UcitajKnjigu(Knjiga knjiga)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.UcitajKnjigu;
                zahtev.Knjiga = knjiga;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.KnjigaUcitana)
                {
                    return odgovor.Knjiga;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal bool ObrisiKnjigu(Knjiga knjiga)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.ObrisiKnjigu;
                zahtev.Knjiga = knjiga;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.KnjigaObrisana)
                {
                    return true;
                }

                return false;
            }

            catch (Exception)
            {
                return false;
            }
        }

        internal bool Connect()
        {
            try
            {
                if (klijentskiSoket == null || !klijentskiSoket.Connected)
                {
                    klijentskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijentskiSoket.Connect("localhost", 9000);
                    stream = new NetworkStream(klijentskiSoket);
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        #endregion

        #region Zahtevi
        public List<Zanr> VratiSveZanrove()
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.VratiSveZanrove;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.ZanroviPronadjeni)
                {
                    return odgovor.Zanrovi;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Knjiga> VratiSveKnjige()
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.VratiSveKnjige;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.KnjigePronadjene)
                {
                    return odgovor.Knjige;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Clan> VratiSveClanove()
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.VratiSveClanove;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.ClanoviPronadjeni)
                {
                    return odgovor.Clanovi;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UnosKnjige(Knjiga knjiga)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.KreirajKnjigu;
                zahtev.Knjiga = knjiga;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.KnjigaUspesnoKreirana)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UnosClana(Clan clan)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.KreirajClana;
                zahtev.Clan = clan;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.ClanUspesnoKreirana)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UnosIznajmljivanje(List<Iznajmljivanje> iznajmljivanja)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.KreirajIznajmljivanje;
                zahtev.Iznajmljivanja = iznajmljivanja;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.IznajmljivanjeUspesnoKreirano)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IzmeniKnjigu(Knjiga knjiga)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.IzmeniKnjigu;
                zahtev.Knjiga = knjiga;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.KnjigaUspesnoIzmenjena)
                {
                    return true;
                }

                return false;
            }

            catch (Exception)
            {
                return false;
            }
        }

        internal bool VracanjeKnjiga(List<Iznajmljivanje> iznajmljivanja)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.ObrisiIznajmljivanje;
                zahtev.Iznajmljivanja = iznajmljivanja;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.IznajmljivanjaUspesnoVracena)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Knjiga> PretraziKnjige(Knjiga knjiga)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.NadjiKnjige;
                zahtev.Knjiga = knjiga;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.KnjigePronadjene)
                {
                    return odgovor.Knjige;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Clan> PretraziClanove(Clan clan)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.NadjiClanove;
                zahtev.Clan = clan;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.ClanoviPronadjeni)
                {
                    return odgovor.Clanovi;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Iznajmljivanje> PretraziIznajmljivanja(Iznajmljivanje iznajmljivanje)
        {
            try
            {
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = Operacija.NadjiIznajmljivanja;
                zahtev.Iznajmljivanje = iznajmljivanje;
                formatter.Serialize(stream, zahtev);
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                if (odgovor.Signal == Signal.IznajmljivanjaPronadjena)
                {
                    return odgovor.Iznajmljivanja;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion
    }
}
