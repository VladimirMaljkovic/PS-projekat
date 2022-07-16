using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Clan : Osoba
    {
        public bool DugujeKnjige { get; set; }
        public string TipClana { get; set; }
        public DateTime DatumUclanjenja { get; set; }

        [Browsable(false)]
        public override string NazivTabele => "clan";
        [Browsable(false)]
        public override string VrednostiZaUnos => base.VrednostiZaUnos + $"'{DugujeKnjige}', '{TipClana}', '{DatumUclanjenja}'";
        [Browsable(false)]
        public override string KriterijumPretrage => $" ime LIKE '%{Ime}%' and prezime LIKE '%{Prezime}%'";
        [Browsable(false)]
        public override string VrednostiZaIzmenu => $"dugujeKnjige = '{DugujeKnjige}'";
        [Browsable(false)]
        public override string UslovObrade => $"osobaId = '{OsobaId}'";
        [Browsable(false)]
        public override List<DomenskiObjekat> GetEntities(SqlDataReader reader)
        {
            List<DomenskiObjekat> clanovi = new List<DomenskiObjekat>();
            while (reader.Read())
            {
                Clan clan = new Clan
                {
                    OsobaId = reader.GetInt32(0),
                    Ime = reader.GetString(1),
                    Prezime = reader.GetString(2),
                    DugujeKnjige = reader.GetBoolean(3),
                    TipClana = reader.GetString(4),
                    DatumUclanjenja = reader.GetDateTime(5)
                };
                clanovi.Add(clan);
            }
            return clanovi;
        }
    }
}
