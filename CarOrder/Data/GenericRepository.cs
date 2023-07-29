using CarOrder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarOrder.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        public T Add(T entity)
        {
            using (SqlConnection conn = new SqlConnection(Configurations.ConnectionString))
            {

                using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
                {
                    connection.Open();

                    Type objectType = typeof(T);
                    PropertyInfo[] properties = objectType.GetProperties();
                    properties = properties.Skip(1).Take(properties.Length - 1).ToArray();

                    string columns = string.Join(", ", properties.Select(p => p.Name));
                    string values = string.Join(", ", properties.Select(p => $"@{p.Name}"));

                    string insertQuery = $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values})";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            string parameterName = $"@{property.Name}";
                            object value = property.GetValue(entity);
                            command.Parameters.AddWithValue(parameterName, value);
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
                
            return entity;
        }

        public void Delete(T entity)
        {
            //
        }

        public T Get()
        {
            return new T();
        }

        public List<T> GetList()
        {
            List<T> list = new List<T>();
            using (SqlConnection conn = new SqlConnection(Configurations.ConnectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM {typeof(T).Name}", conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    T entity = new T();
                    
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        var columnName = reader.GetName(col);
                        //var currentInstanceType = reader.GetFieldType(col);
                        //var currentValueDataType = reader.GetDataTypeName(col);
                        var currentInstanceValue = reader[columnName];

                        var propertyInfo = typeof(T).GetProperty(columnName);
                        propertyInfo.SetValue(entity, Convert.ChangeType(currentInstanceValue, propertyInfo.PropertyType), null);

                    }

                    //foreach(PropertyInfo property in typeof(T).GetProperties()){}

                    list.Add(entity);
                }

                reader.Close();
                conn.Close();
            }

            return list;
        }

        public List<T> GetListWhere(string fkTable, int id)
        {
            List<T> list = new List<T>();
            using (SqlConnection conn = new SqlConnection(Configurations.ConnectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM {typeof(T).Name} WHERE {fkTable}Id = {id}", conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    T entity = new T();

                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        var columnName = reader.GetName(col);
                        //var currentInstanceType = reader.GetFieldType(col);
                        //var currentValueDataType = reader.GetDataTypeName(col);
                        var currentInstanceValue = reader[columnName];

                        var propertyInfo = typeof(T).GetProperty(columnName);
                        propertyInfo.SetValue(entity, Convert.ChangeType(currentInstanceValue, propertyInfo.PropertyType), null);

                    }

                    //foreach(PropertyInfo property in typeof(T).GetProperties()){}

                    list.Add(entity);
                }

                reader.Close();
                conn.Close();
            }

            return list;
        }

        public List<T> GetListWithFK(string fkTable)
        {
            List<T> list = new List<T>();
            using (SqlConnection conn = new SqlConnection(Configurations.ConnectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM {typeof(T).Name} INNER JOIN {fkTable} ON {typeof(T).Name}.{typeof(T).Name}Id = {fkTable}.Id", conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    T entity = new T();

                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        var columnName = reader.GetName(col);
                        //var currentInstanceType = reader.GetFieldType(col);
                        //var currentValueDataType = reader.GetDataTypeName(col);
                        var currentInstanceValue = reader[columnName];

                        var propertyInfo = typeof(T).GetProperty(columnName);
                        propertyInfo.SetValue(entity, Convert.ChangeType(currentInstanceValue, propertyInfo.PropertyType), null);

                    }

                    //foreach(PropertyInfo property in typeof(T).GetProperties()){}

                    list.Add(entity);
                }

                reader.Close();
                conn.Close();
            }

            return list;
        }

        public void Update(T entity)
        {
            //
        }
    }
}
