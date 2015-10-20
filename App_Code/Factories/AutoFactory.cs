using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

public class AutoFactory<T> where T : AutoTable
{
    public enum OrderBy { DESC, ASC };
    private string connectionString;
    private string tableName;
    private bool usePrefix;
    private string tablePrefix;
    private string fieldPrefix;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectionString">ConfigurationManager.ConnectionStrings[0] is used by default</param>
    /// <param name="usePrefix">Should use a prefix in front of property names as stated in the models</param>
    /// <param name="tablePrefix">The prefix you use in front of tables in your database</param>
    /// <param name="fieldPrefix">The prefix you use in front of fields in your database</param>
    public AutoFactory(string connectionString = "", bool usePrefix = true, string tablePrefix = "tbl", string fieldPrefix = "fld")
    {
        this.connectionString = (connectionString == "" ? ConfigurationManager.ConnectionStrings[0].ConnectionString : connectionString);
        tableName = typeof(T).Name;
        this.usePrefix = usePrefix;
        this.tablePrefix = tablePrefix;
        this.fieldPrefix = fieldPrefix;
    }

    public T GetGenericType()
    {
        T result;
        return result = Activator.CreateInstance<T>();
    }

    private string GetTableName()
    {
        return (usePrefix ? tablePrefix + tableName : tableName);
    }
    private string GetFieldName(string fieldName)
    {
        return (usePrefix ? fieldPrefix + fieldName : fieldName);
    }

    public void Add(T entity)
    {
        string insertQuery = string.Format("INSERT INTO {0} (", GetTableName());

        for (int i = 1; i < entity.Properties.Count; i++)
        {
            PropertyInfo property = entity.Properties[i];

            insertQuery += GetFieldName(property.Name);
            insertQuery += (i + 1 == entity.Properties.Count ? "" : ", ");
        }

        insertQuery += ")";
        insertQuery += " VALUES (";

        for (int i = 1; i < entity.Properties.Count; i++)
        {
            PropertyInfo p = entity.Properties[i];
            insertQuery += "@" + entity.Properties[i].Name + (i + 1 == entity.Properties.Count ? "" : ", ");
        }

        insertQuery += ")";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(insertQuery, connection);

        for (int i = 0; i < entity.Properties.Count; i++)
        {
            cmd.Parameters.AddWithValue("@" + entity.Properties[i].Name, entity.Properties[i].GetValue(entity, null));
        }

        cmd.ExecuteNonQuery();

        cmd.Dispose();
        connection.Dispose();
        connection.Close();
    }

    public void Update(T entity)
    {
        string updateQuery = string.Format("UPDATE {0} SET ", GetTableName());

        for (int i = 1; i < entity.Properties.Count; i++)
        {
            PropertyInfo property = entity.Properties[i];

            updateQuery += GetFieldName(property.Name) + "=@" + entity.Properties[i].Name;
            updateQuery += (i + 1 == entity.Properties.Count ? " " : ", ");
        }

        updateQuery += string.Format("WHERE {0}={1}", GetFieldName(entity.Properties[0].Name), entity.Properties[0].GetValue(entity, null));

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(updateQuery, connection);

        for (int i = 0; i < entity.Properties.Count; i++)
        {
            cmd.Parameters.AddWithValue("@" + entity.Properties[i].Name, entity.Properties[i].GetValue(entity, null));
        }

        cmd.ExecuteNonQuery();

        cmd.Dispose();
        connection.Dispose();
        connection.Close();
    }

    public void Delete(int id)
    {
        T entity = GetEntityByID(id);

        string deleteQuery = string.Format("DELETE FROM {0} ", GetTableName());
        deleteQuery += string.Format("WHERE {0}={1}", GetFieldName(entity.Properties[0].Name), id);

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(deleteQuery, connection);
        cmd.ExecuteNonQuery();

        cmd.Dispose();
        connection.Dispose();
        connection.Close();
    }

    public T GetLatest(string uniqueColumn, OrderBy order)
    {
        T result = Activator.CreateInstance<T>();
        string selectQuery = string.Format("SELECT TOP 1 * FROM {0} ORDER BY {1} {2}", GetTableName(), GetFieldName(uniqueColumn), order);

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(selectQuery, connection);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                for (int i = 0; i < result.Properties.Count; i++)
                {
                    if (reader[i] == DBNull.Value) continue;
                    result.Properties[i].SetValue(result, reader[i], null);
                }
            }
        }

        cmd.Dispose();
        connection.Dispose();
        connection.Close();

        return result;
    }

    public T GetEntityByID(int id)
    {
        T result = Activator.CreateInstance<T>();
        string selectQuery = string.Format("SELECT * FROM {0} WHERE {1}={2}", GetTableName(), GetFieldName(result.Properties[0].Name), id);


        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(selectQuery, connection);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                for (int i = 0; i < result.Properties.Count; i++)
                {
                    if (reader[i] == DBNull.Value) continue;
                    result.Properties[i].SetValue(result, reader[i], null);
                }
            }
        }

        cmd.Dispose();
        connection.Dispose();
        connection.Close();

        return result;
    }

    public List<T> GetAllEntities()
    {
        List<T> result = new List<T>();
        string selectQuery = string.Format("SELECT * FROM {0}", GetTableName());

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(selectQuery, connection);
        SqlDataReader reader = cmd.ExecuteReader();

        T entry = null;

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                entry = Activator.CreateInstance<T>();
                for (int i = 0; i < entry.Properties.Count; i++)
                {
                    if (reader[i] == DBNull.Value) continue;
                    entry.Properties[i].SetValue(entry, reader[i], null);
                }
                result.Add(entry);
            }
        }

        cmd.Dispose();
        connection.Dispose();
        connection.Close();

        return result;
    }

    public T GetEntity(string query)
    {
        T result = Activator.CreateInstance<T>();
        string selectQuery = query;


        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(selectQuery, connection);
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                for (int i = 0; i < result.Properties.Count; i++)
                {
                    if (reader[i] == DBNull.Value) continue;
                    result.Properties[i].SetValue(result, reader[i], null);
                }
            }
        }

        cmd.Dispose();
        connection.Dispose();
        connection.Close();

        return result;
    }
}

