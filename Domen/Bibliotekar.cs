using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Bibliotekar : Osoba, DomenskiObjekat
    {
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        [Browsable(false)]
        public override string NazivTabele => "bibliotekar";
        [Browsable(false)]
        public override string KriterijumPretrage => $" korisnickoIme = '{KorisnickoIme}' and sifra = '{Sifra}'";

        public override List<DomenskiObjekat> GetEntities(SqlDataReader reader)
        {
            List<DomenskiObjekat> bibliotekari = new List<DomenskiObjekat>();
            while (reader.Read())
            {
                Bibliotekar bibliotekar = new Bibliotekar
                {
                    OsobaId = reader.GetInt32(0),
                    Ime = reader.GetString(1),
                    Prezime = reader.GetString(2),
                    KorisnickoIme = reader.GetString(3),
                    Sifra = reader.GetString(4)
                };
                bibliotekari.Add(bibliotekar);
            }
            return bibliotekari;
        }
    }
}
