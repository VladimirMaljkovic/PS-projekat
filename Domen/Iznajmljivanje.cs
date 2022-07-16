using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Iznajmljivanje : DomenskiObjekat
    {
        [Browsable(false)]
        public int IznajmljivanjeId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public Clan Clan { get; set; }
        public Knjiga Knjiga { get; set; }
        public Bibliotekar Bibliotekar { get; set; }

        [Browsable(false)]
        public string NazivTabele => "iznajmljivanje";
        [Browsable(false)]
        public string VrednostiZaUnos => $"{Clan.OsobaId}, '{DatumIzdavanja}', null,  {Bibliotekar.OsobaId}, {Knjiga.KnjigaId}";
        [Browsable(false)]
        public string PovratneVrednosti => "*";
        [Browsable(false)]
        public string Join => " i JOIN clan c on (i.clanid = c.osobaid) JOIN knjiga k on (i.knjigaid = k.knjigaid) JOIN zanr z on (k.zanrid = z.zanrid) JOIN bibliotekar b on (i.bibliotekarid = b.osobaid)";
        [Browsable(false)]
        public string KriterijumPretrage => $" clanid = {Clan.OsobaId} and datumVracanja is null";
        [Browsable(false)]
        public string VrednostiZaIzmenu => $" datumVracanja = '{DatumVracanja}'";
        [Browsable(false)]
        public string UslovObrade => $" clanid = {Clan.OsobaId} and  knjigaid = {Knjiga.KnjigaId}";
        [Browsable(false)]
        public List<DomenskiObjekat> GetEntities(SqlDataReader reader)
        {
            List<DomenskiObjekat> iznajmljivanja = new List<DomenskiObjekat>();
            while (reader.Read())
            {
                var datumVracanja = reader["DatumVracanja"];

                Iznajmljivanje iznajmljivanje = new Iznajmljivanje
                {
                    IznajmljivanjeId = reader.GetInt32(reader.GetOrdinal("IznajmljivanjeId")),
                    DatumIzdavanja = reader.GetDateTime(reader.GetOrdinal("DatumIzdavanja")),
                    DatumVracanja = datumVracanja != DBNull.Value ?
                                    (DateTime?)reader.GetDateTime(reader.GetOrdinal("DatumVracanja")) : null,
                    Clan = new Clan
                    {
                        OsobaId = reader.GetInt32(reader.GetOrdinal("ClanId")),
                        Ime = reader.GetString(reader.GetOrdinal("Ime")),
                        Prezime = reader.GetString(reader.GetOrdinal("Prezime")),
                        DugujeKnjige = reader.GetBoolean(reader.GetOrdinal("Dugujeknjige")),
                        TipClana = reader.GetString(reader.GetOrdinal("TipClana")),
                        DatumUclanjenja = reader.GetDateTime(reader.GetOrdinal("DatumUclanjenja"))
                    },
                    Knjiga = new Knjiga
                    {
                        KnjigaId = reader.GetInt32(reader.GetOrdinal("KnjigaId")),
                        NazivKnjige = reader.GetString(reader.GetOrdinal("NazivKnjige")),
                        AutorKnjige = reader.GetString(reader.GetOrdinal("Autorknjige")),
                        Zanr = new Zanr
                        {
                            ZanrId = reader.GetInt32(reader.GetOrdinal("ZanrId")),
                            NazivZanra = reader.GetString(reader.GetOrdinal("NazivZanra")),
                        },
                        Stanje = reader.GetInt32(reader.GetOrdinal("Stanje"))
                    },
                    Bibliotekar = new Bibliotekar
                    {
                        OsobaId = reader.GetInt32(reader.GetOrdinal("Osobaid")),
                        Ime = reader.GetString(reader.GetOrdinal("Ime")),
                        Prezime = reader.GetString(reader.GetOrdinal("Prezime")),
                        KorisnickoIme = reader.GetString(reader.GetOrdinal("KorisnickoIme")),
                        Sifra = reader.GetString(reader.GetOrdinal("Sifra")),
                    }
                };
                iznajmljivanja.Add(iznajmljivanje);
            }
            return iznajmljivanja;
        }
    }
}
