using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using RopExample.IDataLayer;
using RopExample.ROP;
using System;
using System.Linq;

namespace RopExample.DataLayer
{
    public class DatabaseLayer : IDatabaseLayer
    {
        private IDatabaseContext _databaseContext;

        public DatabaseLayer(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        private string GetValidPropertiesNames<T>(T item, char delimeter = ',')
        {
            return string.Join(delimeter, item.GetType().GetProperties().Select(x => x.Name));
        }

        private string GetValidPropertiesValues<T>(T item, char delimeter = ',')
        {
            return string.Join(delimeter, item.GetType().GetProperties().Select(x => $"'{x.GetValue(item)}'"));
        }

        private string GenerateInsertQuery<T>(T item)
        {
            return $"INSERT INTO {item.GetType().Name} ({GetValidPropertiesNames(item)}) VALUES ({GetValidPropertiesValues(item)})";
        }

        private T Get<T>(string id)
        {
            return default;
        }

        private void Insert<T>(T item)
        {
            var insertQuery = GenerateInsertQuery(item);
            //using (MySqlConnection con = _databaseContext.GetConnection())
            //{
            //    con.Open();
            //    MySqlCommand cmd = new MySqlCommand(GenerateInsertQuery(item), con);
            //    MySqlDataReader reader = 
            //}

        }

        public Result<T, string[]> GetRop<T>(string id)
        {
            var result = Get<T>(id);

            return result != null
                ? Result<T, string[]>.Succeeded(result)
                : Result<T, string[]>.Failed(new[] { 
                    $"Could not find the {result.GetType().Name}" 
                });
        }

        public Result<T, string[]> InsertRop<T>(T item)
        {
            try
            {
                Insert(item);
                return Result<T, string[]>.Succeeded(item);
            } catch (Exception e)
            {
                return Result<T, string[]>.Failed(new[] { e.Message });
            }
        }
    }
}
