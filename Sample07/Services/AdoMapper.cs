using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;

namespace Sample07.Services
{
    public abstract class AdoMapper<T> where T : class
    {
        private readonly IMapper _mapper;
        private readonly SqlConnection _connection;

        protected AdoMapper(string connectionString, IMapper mapper)
        {
            _mapper = mapper;
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
                    return _mapper.Map<IDataReader, IEnumerable<T>>(reader);
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
                    return _mapper.Map<IDataReader, T>(reader);
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
                    // moved to https://github.com/AutoMapper/AutoMapper.Data
                    return _mapper.Map<IDataReader, IEnumerable<T>>(reader);
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