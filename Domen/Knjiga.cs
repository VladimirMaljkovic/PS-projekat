using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Knjiga : DomenskiObjekat
    {
        [Browsable(false)]
        public int KnjigaId { get; set; }
        public string NazivKnjige { get; set; }
        public string AutorKnjige { get; set; }
        public Zanr Zanr { get; set; }
        public int Stanje { get; set; }

        [Browsable(false)]
        public string NazivTabele => "knjiga";
        [Browsable(false)]
        public string VrednostiZaUnos => $"'{NazivKnjige}', '{AutorKnjige}', {Stanje}, {Zanr.ZanrId}";
        [Browsable(false)]
        public string PovratneVrednosti => "*";
        [Browsable(false)]
        public string Join => " k JOIN zanr z on (k.zanrid = z.zanrid)";
        [Browsable(false)]
        public string KriterijumPretrage => $"k.nazivKnjige LIKE '%'+'{NazivKnjige}'+'%' AND k.autorKnjige LIKE '%'+'{AutorKnjige}'+'%'";
        [Browsable(false)]
        public string VrednostiZaIzmenu => $" stanje = {Stanje}, nazivKnjige = '{NazivKnjige}', autorKnjige = '{AutorKnjige}', zanrid = {Zanr.ZanrId}";
        [Browsable(false)]
        public string UslovObrade => $"knjigaId = {KnjigaId}";
        [Browsable(false)]
        public List<DomenskiObjekat> GetEntities(SqlDataReader reader)
        {
            List<DomenskiObjekat> knjige = new List<DomenskiObjekat>();
            while (reader.Read())
            {
                Knjiga knjiga = new Knjiga
                {
                    KnjigaId = reader.GetInt32(reader.GetOrdinal("knjigaId")),
                    NazivKnjige = reader.GetString(reader.GetOrdinal("nazivKnjige")),
                    AutorKnjige = reader.GetString(reader.GetOrdinal("autorknjige")),
                    Zanr = new Zanr
                    {
                        ZanrId = reader.GetInt32(reader.GetOrdinal("zanrId")),
                        NazivZanra = reader.GetString(reader.GetOrdinal("nazivZanra")),
                    },
                    Stanje = reader.GetInt32(reader.GetOrdinal("stanje"))
                };
                knjige.Add(knjiga);
            }
            return knjige;
        }
    }
}
