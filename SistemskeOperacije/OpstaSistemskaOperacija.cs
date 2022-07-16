using DbBroker;
using Domen;
using System;

namespace SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected abstract object Izvrsavanje(DomenskiObjekat domenskiObjekat);
        protected abstract void Validacija(DomenskiObjekat domenskiObjekat);
        protected Broker broker = new Broker();
        public object IzvrsiSO(DomenskiObjekat domenskiObjekat)
        {
            object rezultat = null;
            try
            {
                Validacija(domenskiObjekat);
                broker.OpenConnection();
                broker.BeginTransaction();
                rezultat = Izvrsavanje(domenskiObjekat);
                broker.Commit();
            }
            
            catch (Exception e)
            {
                broker.Rollback();
            }
            finally
            {
                broker.CloseConnection();
            }
            return rezultat;
        }
    }
}
