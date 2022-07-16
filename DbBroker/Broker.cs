using Domen;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DbBroker
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public Broker()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KonekcioniString"].ConnectionString);
        }
        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction?.Rollback();
        }
        public int Sacuvaj(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"Insert into {domenskiObjekat.NazivTabele} values ({domenskiObjekat.VrednostiZaUnos})";
            return command.ExecuteNonQuery();
        }

        public List<DomenskiObjekat> Vrati(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"SELECT {domenskiObjekat.PovratneVrednosti} FROM {domenskiObjekat.NazivTabele} {domenskiObjekat.Join}";
            SqlDataReader reader = command.ExecuteReader();
            List<DomenskiObjekat> rezultat = domenskiObjekat.GetEntities(reader);
            reader.Close();
            return rezultat;
        }

        public List<DomenskiObjekat> Pretrazi(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"SELECT {domenskiObjekat.PovratneVrednosti} FROM {domenskiObjekat.NazivTabele} {domenskiObjekat.Join} WHERE {domenskiObjekat.KriterijumPretrage}";
            SqlDataReader reader = command.ExecuteReader();
            List<DomenskiObjekat> rezultat = domenskiObjekat.GetEntities(reader);
            reader.Close();
            return rezultat;
        }

        public int Azuriraj(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"Update {domenskiObjekat.NazivTabele} set {domenskiObjekat.VrednostiZaIzmenu} where {domenskiObjekat.UslovObrade}";
            int rez = command.ExecuteNonQuery();
            return rez;
        }

        public int Obrisi(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"DELETE FROM {domenskiObjekat.NazivTabele} WHERE {domenskiObjekat.UslovObrade}";
            int rez = command.ExecuteNonQuery();
            return rez;
        }
    }
}
