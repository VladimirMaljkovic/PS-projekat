using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public interface DomenskiObjekat
    {
        string NazivTabele { get; }
        string VrednostiZaUnos { get; }
        string PovratneVrednosti { get; }
        string Join { get; }
        string KriterijumPretrage { get; }
        string VrednostiZaIzmenu { get; }
        string UslovObrade { get; }
        List<DomenskiObjekat> GetEntities(SqlDataReader reader);
    }
}
