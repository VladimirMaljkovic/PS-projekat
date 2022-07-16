using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Osoba : DomenskiObjekat
    {
        [Browsable(false)]
        public int OsobaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [Browsable(false)]
        public virtual string NazivTabele => string.Empty;
        [Browsable(false)]
        public virtual string VrednostiZaUnos => $"'{Ime}', '{Prezime}',";
        [Browsable(false)]
        public string PovratneVrednosti => "*";
        [Browsable(false)]
        public virtual string Join => string.Empty;
        [Browsable(false)]
        public virtual string KriterijumPretrage => string.Empty;
        [Browsable(false)]
        public virtual string VrednostiZaIzmenu => $"ime = '{Ime}', prezime = '{Prezime}', ";
        [Browsable(false)]
        public virtual string UslovObrade => $"osobaId = {OsobaId}";

        public virtual List<DomenskiObjekat> GetEntities(SqlDataReader reader)
        {
            return null;
        }
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
