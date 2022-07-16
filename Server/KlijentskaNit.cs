using Kontroler;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Zajednicki;

namespace Server
{
    public class KlijentskaNit
    {
        public Socket klijentskiSoket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        public KlijentskaNit(Socket KlijentskiSoket)
        {
            this.klijentskiSoket = KlijentskiSoket;
            this.stream = new NetworkStream(KlijentskiSoket);
        }

        internal void ObradiZahteve()
        {
            Odgovor odgovor = new Odgovor();
            try
            {
                while (true)
                {
                    Zahtev zahtev = (Zahtev)formatter.Deserialize(stream);
                    switch (zahtev.Operacija)
                    {
                        case Operacija.Login:
                            odgovor.Bibliotekar = Controller.Instance.Prijava(zahtev.Bibliotekar);
                            odgovor.Signal = odgovor.Bibliotekar != null ? Signal.UspesnoPrijavljen : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.KreirajClana:
                            odgovor.Signal = Controller.Instance.KreirajClana(zahtev.Clan) ? Signal.ClanUspesnoKreirana : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.VratiSveClanove:
                            odgovor.Clanovi = Controller.Instance.VratiSveClanove();
                            odgovor.Signal = odgovor.Clanovi.Count > 0 ? Signal.ClanoviPronadjeni : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.IzmeniKnjigu:
                            odgovor.Signal = Controller.Instance.IzmeniKnjigu(zahtev.Knjiga) ? Signal.KnjigaUspesnoIzmenjena : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.KreirajKnjigu:
                            odgovor.Signal = Controller.Instance.KreirajKnjigu(zahtev.Knjiga) ? Signal.KnjigaUspesnoKreirana : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.NadjiKnjige:
                            odgovor.Knjige = Controller.Instance.PronadjiKnjige(zahtev.Knjiga);
                            odgovor.Signal = odgovor.Knjige.Count > 0 ? Signal.KnjigePronadjene : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.ObrisiKnjigu:
                            odgovor.Signal = Controller.Instance.ObrisiKnjigu(zahtev.Knjiga) ? Signal.KnjigaObrisana : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.UcitajKnjigu:
                            odgovor.Knjiga= Controller.Instance.UcitajKnjigu(zahtev.Knjiga);
                            odgovor.Signal = odgovor.Knjiga != null ? Signal.KnjigaUcitana : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.VratiSveKnjige:
                            odgovor.Knjige = Controller.Instance.VratiSveKnjige();
                            odgovor.Signal = odgovor.Knjige.Count > 0 ? Signal.KnjigePronadjene : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.VratiSveZanrove:
                            odgovor.Zanrovi = Controller.Instance.VratiSveZanrove();
                            odgovor.Signal = odgovor.Zanrovi.Count > 0 ? Signal.ZanroviPronadjeni : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.KreirajIznajmljivanje:
                            odgovor.Signal = Controller.Instance.KreirajIznajmljivanje(zahtev.Iznajmljivanja) ? Signal.IznajmljivanjeUspesnoKreirano : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.ObrisiIznajmljivanje:
                            odgovor.Signal = Controller.Instance.ObrisiIznajmljivanje(zahtev.Iznajmljivanja) ? Signal.IznajmljivanjaUspesnoVracena : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.VratiSvaIznajmljivanja:
                            odgovor.Iznajmljivanja = Controller.Instance.VratiSvaIznajmljivanja();
                            odgovor.Signal = odgovor.Iznajmljivanja.Count > 0 ? Signal.IznajmljivanjaPronadjena : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.NadjiClanove:
                            odgovor.Clanovi = Controller.Instance.PronadjiClanove(zahtev.Clan);
                            odgovor.Signal = odgovor.Clanovi.Count > 0 ? Signal.ClanoviPronadjeni : Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        case Operacija.NadjiIznajmljivanja:
                            odgovor.Iznajmljivanja = Controller.Instance.PronadjiIznajmljivanja(zahtev.Iznajmljivanje);
                            odgovor.Signal = odgovor.Iznajmljivanja.Count>0 ? Signal.IznajmljivanjaPronadjena :Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                        default:
                            odgovor.Signal = Signal.GreskaUZahtevu;
                            formatter.Serialize(stream, odgovor);
                            break;
                    }

                }
            }
            catch (IOException)
            {
                klijentskiSoket.Close();
            }
            catch (Exception)
            {
                odgovor.Signal = Signal.GreskaUZahtevu;
                formatter.Serialize(stream, odgovor);
            }
        }
    }
}
