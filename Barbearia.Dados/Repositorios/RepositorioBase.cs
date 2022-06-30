using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Barbearia.Dados.Repositorios
{
    public class RepositorioBase : IDisposable
    {
        internal string connectionString = ConfigurationManager.ConnectionStrings["NetcomConnection"].ConnectionString;
        private MySqlConnection _connection;
        private MySqlTransaction _transaction;
        public MySqlTransaction Transaction { get => _transaction; set => _transaction = value; }
        public MySqlConnection Connection { get => _connection; set => _connection = value; }

        public RepositorioBase()
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (Connection != null && Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                else
                {
                    Connection = new MySqlConnection(connectionString);
                    Connection.Open();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void OpenTransaction()
        {
            try
            {
                OpenConnection();

                if (Transaction == null) { Transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }

        public void Dispose()
        {
            try
            {
                if (Connection != null) { Connection.Close(); Connection.Dispose(); Connection = null; }
                if (Transaction != null) { Transaction.Dispose(); Connection = null; }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
