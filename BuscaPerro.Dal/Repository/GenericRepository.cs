using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using Dapper;
using System.Text;
using System.ComponentModel;
using Z.Dapper.Plus;
using BuscaPerro.Domain.Interfaces.Repository;
using BuscaPerro.Dal.Connection;

namespace BuscaPerro.Dal.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _tableName;
        private readonly string _schema = "dbo";
        public string cadenaConexion;
        protected DataBaseConnection connection_database;
        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        protected GenericRepository(IConfiguration configuration, string tableName)
        {
            this.cadenaConexion = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            this._tableName = tableName;
            this.connection_database = new DataBaseConnection(this.cadenaConexion);
        }
        protected GenericRepository(IConfiguration configuration, string tableName, string schema)
        {
            this.cadenaConexion = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            this._tableName = tableName;
            this.connection_database = new DataBaseConnection(this.cadenaConexion);
            this._schema = schema;
        }
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_schema}.{_tableName} ");

            insertQuery.Append("(");

            var propertiesComplete = GenerateListOfProperties(GetProperties);
            var properties = propertiesComplete.Where(x => !x.Equals($"id_{_tableName}")).ToList();
            properties.ForEach(prop => { insertQuery.Append($"{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append($") RETURNING id_{_tableName}");

            return Convert.ToString(insertQuery);
        }
        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_schema}.{_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals($"id_{_tableName}"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append($" WHERE id_{_tableName}=@id_{_tableName}");

            return updateQuery.ToString();
        }

        private string GenerateSearchQueryDictionary(Dictionary<string, object> searchParams)
        {
            var searchQuery = new StringBuilder($"SELECT * FROM {_schema}.{_tableName} WHERE ");
            var properties = searchParams.Keys.ToList();
            properties.ForEach(property =>
            {
                if (!property.Equals($"id_{_tableName}"))
                {
                    searchQuery.Append($"{property}=@{property} and ");
                }
            });

            searchQuery.Remove(searchQuery.Length - 5, 5); //remove last and

            return searchQuery.ToString();
        }
        public async Task<int> DeleteRow(int id)
        {
            using (var connection = connection_database.CreateConnection())
            {
                return await connection.ExecuteAsync($"DELETE FROM {_schema}.{_tableName} WHERE id_{_tableName}=@Id"
                    , new { Id = id });
            }
        }

        public async Task<T> Get(int id)
        {
            using (var connection = connection_database.CreateConnection())
            {
                var result = connection.QuerySingleAsync<T>($"SELECT * FROM {_schema}.{_tableName} WHERE id_{_tableName}=@Id", new { Id = id });
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with id_{_tableName} [{id}] could not be found.");

                return await result;
            }
        }
        public async Task<IEnumerable<T>> GetRange(IEnumerable<int> ids)
        {
            using (var connection = connection_database.CreateConnection())
            {
                string obtenerids = "(";
                int cont = 0;
                foreach (var id in ids)
                {
                    if (cont != ids.Count() - 1)
                    {
                        obtenerids += id + ",";
                    }
                    else
                        obtenerids += id;
                    cont++;
                }
                obtenerids += ")";

                var result = connection.QueryAsync<T>($"SELECT * FROM {_schema}.{_tableName} WHERE id_{_tableName} in {obtenerids}");


                return await result;
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            using (var connection = connection_database.CreateConnection())
            {
                return await connection.QueryAsync<T>($"SELECT * FROM {_schema}.{_tableName}");
            }
        }

        public async Task<int> Insert(T t)
        {
            var insertQuery = GenerateInsertQuery();

            using (var connection = connection_database.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(insertQuery, t);
            }
        }

        public async Task<int> InsertRange(IEnumerable<T> list)
        {
            DapperPlusManager.Entity<T>().Table($"{_schema}.{_tableName}");
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (var connection = connection_database.CreateConnection())
            {
                //var range = connection.UseBulkOptions(options => options.InsertIfNotExists = true).BulkInsert(list);
                inserted = await connection.ExecuteAsync(await query, list);
            }
            return inserted;

            async Task<string> GenerateInsertQuery()
            {
                var insertQuery = new StringBuilder($"INSERT INTO {_schema}.{_tableName} ");

                insertQuery.Append("(");
                var properties = GenerateListOfProperties(GetProperties).Where(x => !x.Equals($"id_{_tableName}")).ToList();
                properties.ForEach(prop => { insertQuery.Append($"{prop},"); });
                insertQuery
                    .Remove(insertQuery.Length - 1, 1)
                    .Append(") VALUES (");
                properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });
                insertQuery
                    .Remove(insertQuery.Length - 1, 1)
                    .Append(")");
                return insertQuery.ToString();
            }
        }

        public async Task<int> Update(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = connection_database.CreateConnection())
            {
                return await connection.ExecuteAsync(updateQuery, t);
            }
        }
        public async Task<int> UpdateDictionary(Dictionary<string, object> updateParams)
        {
            var updateQuery = GenerateUpdateDictionaryQuery();

            using (var connection = connection_database.CreateConnection())
            {
                return await connection.ExecuteAsync(updateQuery, updateParams);
            }
            string GenerateUpdateDictionaryQuery()
            {
                var updateQueryDict = new StringBuilder($"UPDATE {_schema}.{_tableName} SET ");
                var properties = updateParams.Keys.ToList();

                properties.ForEach(property =>
                {
                    if (!property.Equals($"id_{_tableName}"))
                    {
                        updateQueryDict.Append($"{property}=@{property},");
                    }
                });

                updateQueryDict.Remove(updateQueryDict.Length - 1, 1); //remove last comma
                updateQueryDict.Append($" WHERE id_{_tableName}=@id_{_tableName}");

                return updateQueryDict.ToString();
            }
        }
        public async Task<IEnumerable<T>> SearchByFields<Fields>(Fields modelFields) where Fields : class
        {
            var search = GenerateSearchQuery(modelFields);

            using (var connection = connection_database.CreateConnection())
            {
                return await connection.QueryAsync<T>(search, modelFields);
            }

            #region metodos privados
            string GenerateSearchQuery<Fields>(Fields searchParams) where Fields : class
            {
                var searchQuery = new StringBuilder($"SELECT * FROM {_schema}.{_tableName} WHERE ");
                var properties = GenerateListOfProperties(searchParams.GetType().GetProperties());
                typeof(T).GetProperties();
                properties.ForEach(property =>
                {
                    if (!property.Equals($"id_{_tableName}"))
                    {
                        searchQuery.Append($"{property}=@{property} and ");
                    }
                });

                searchQuery.Remove(searchQuery.Length - 5, 5); //remove last and

                return searchQuery.ToString();
            }
            #endregion
        }
        public async Task<IEnumerable<T>> SearchByFieldsDictionary(Dictionary<string, object> modelFields)
        {
            var searchQuery = GenerateSearchQueryDictionary(modelFields);

            using (var connection = connection_database.CreateConnection())
            {
                return await connection.QueryAsync<T>(searchQuery, modelFields);
            }
        }
        public async Task<IEnumerable<TE>> Query<TE>(string consult, object modelFields = null)
        {

            using (var connection = connection_database.CreateConnection())
            {
                if (modelFields != null)
                {
                    return await connection.QueryAsync<TE>(consult, modelFields);
                }
                else
                {
                    return await connection.QueryAsync<TE>(consult);
                }
            }
        }
    }
}