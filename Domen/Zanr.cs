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
    public class Zanr : DomenskiObjekat
    {
        [Browsable(false)]
        public int ZanrId { get; set; }
        public string NazivZanra { get; set; }
        
        [Browsable(false)]
        public string NazivTabele => "Zanr";
        [Browsable(false)]
        public string VrednostiZaUnos => string.Empty;
        [Browsable(false)]
        public string PovratneVrednosti => "*";
        [Browsable(false)]
        public string Join => string.Empty;
        [Browsable(false)]
        public string KriterijumPretrage => string.Empty;
        [Browsable(false)]
        public string VrednostiZaIzmenu => string.Empty;
        [Browsable(false)]
        public string UslovObrade => string.Empty;
        [Browsable(false)]
        public List<DomenskiObjekat> GetEntities(SqlDataReader reader)
        {
            List<DomenskiObjekat> zanrovi = new List<DomenskiObjekat>();
            while (reader.Read())
            {
                Zanr zanr = new Zanr
                {
                    ZanrId = reader.GetInt32(0),
                    NazivZanra = reader.GetString(1)
                };
                zanrovi.Add(zanr);
            }
            return zanrovi;
        }

        public override string ToString()
        {
            return NazivZanra;
        }
    }
}
