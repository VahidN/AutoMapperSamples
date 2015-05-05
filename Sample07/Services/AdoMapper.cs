using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;

namespace Sample07.Services
{
    public abstract class AdoMapper<T> where T : class
    {
        private readonly SqlConnection _connection;

        protected AdoMapper(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        protected virtual IEnumerable<T> ExecuteCommand(SqlCommand command)
        {
            command.Connection = _connection;
            command.CommandType = CommandType.StoredProcedure;
            _connection.Open();

            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        protected virtual T GetRecord(SqlCommand command)
        {
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    return Mapper.Map<IDataReader, T>(reader);
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        protected virtual IEnumerable<T> GetRecords(SqlCommand command)
        {
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}