﻿using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BinAff.SqlServerUtil
{

    public static class Handler
    {

        public static List<String> GetSqlServerInstances(Boolean isLocal)
        {
            List<String> instanceList = new List<String>();
            DataTable table = SmoApplication.EnumAvailableSqlServers(isLocal);
            foreach (DataRow row in table.Rows)
            {
                instanceList.Add(row["Server"].ToString() + "\\" + row["Instance"].ToString());
            }
            return instanceList;
        }

        public static List<Database> GetSqlServerDatabases(String instance)
        {
            List<Database> dbList = new List<Database>();
            Server svr = new Server(instance);

            foreach (Database db in svr.Databases)
            {
                dbList.Add(db);
            }

            return dbList;
        }

        public static List<String> GetSqlServerDatabaseNames(String instance)
        {
            List<String> dbList = new List<String>();
            Server svr = new Server(instance);

            foreach (Database db in svr.Databases)
            {
                dbList.Add(db.Name);
            }

            return dbList;
        }

        public static Boolean TestDbConnection(String instanceName, String dbName)
        {
            String connectionString = GetConnectionString(instanceName, dbName);
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open) return true;
            }
            catch
            {
                //Do nothing, any problem in db connection
            }

            return false;
        }

        public static Boolean TestDbConnection(String instanceName, String dbName, String userName, String password)
        {
            String connectionString = GetConnectionString(instanceName, dbName, userName, password);
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open) return true;
            }
            catch
            {
                //Do nothing, any problem in db connection
            }

            return false;
        }

        public static String GetConnectionString(String instanceName, String dbName)
        {
            return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;", instanceName, dbName);
        }

        public static String GetConnectionString(String instanceName, String dbName, String userName, String password)
        {
            return String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};",
                instanceName, dbName, userName, password);
        }

        public static SqlConnection GetConnectionObject(String instanceName, String dbName)
        {
            return new SqlConnection(GetConnectionString(instanceName, dbName));
        }

        public static SqlConnection GetConnectionObject(String instanceName, String dbName, String userName, String password)
        {
            return new SqlConnection(GetConnectionString(instanceName, dbName, userName, password));
        }
        
        public static Boolean CreateDatabaseObject(SqlConnection conn, String existQuery, String createQuery)
        {
            Boolean status = true;
            Boolean isOpenHere = false;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                isOpenHere = true;
            }

            //Schema
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(existQuery, conn);
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) //Schema is not there
            {
                if (!reader.IsClosed) reader.Close();
                cmd.CommandText = createQuery;
                if (cmd.ExecuteNonQuery() != 1)
                {
                    status = false; //Problem in schema creation
                }
            }
            if (!reader.IsClosed) reader.Close();
            if (isOpenHere && conn.State == ConnectionState.Open) conn.Close();
            return status;
        }

        //Duplication in overload... Need to repair
        private static Boolean CreateDatabaseObject(SqlTransaction trans, String existQuery, String createQuery)
        {
            Boolean status = true;
            Boolean isOpenHere = false;
            if (trans.Connection.State != ConnectionState.Open)
            {
                trans.Connection.Open();
                isOpenHere = true;
            }

            //Database object
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(existQuery, trans.Connection)
            {
                Transaction = trans,
            };
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) //Object is not there
            {
                if (!reader.IsClosed) reader.Close();
                cmd.CommandText = createQuery;
                if (cmd.ExecuteNonQuery() != -1)
                {
                    status = false; //Problem in object creation
                }
            }
            if (!reader.IsClosed) reader.Close();
            if (isOpenHere && trans.Connection.State == ConnectionState.Open) trans.Connection.Close();
            return status;
        }

        /// <summary>
        /// Create schema if does not exist
        /// </summary>
        /// <param name="conn">
        /// Connection object, preferablly open
        /// If connection open here, it will be automatically closed
        /// </param>
        /// <param name="schemaName">Schema name</param>
        /// <returns></returns>
        public static Boolean CreateSchema(SqlConnection conn, String schemaName)
        {
            return CreateDatabaseObject(conn,
                "SELECT * FROM sys.schemas WHERE name = N'" + schemaName + "'",
                "CREATE SCHEMA " + schemaName + " AUTHORIZATION [dbo]");
        }

        /// <summary>
        /// Create schema if does not exist
        /// </summary>
        /// <param name="trans">Transaction object</param>
        /// <param name="schemaName">Schema name</param>
        /// <returns></returns>
        public static Boolean CreateSchema(SqlTransaction trans, String schemaName)
        {
            return CreateDatabaseObject(trans,
                "SELECT * FROM sys.schemas WHERE name = N'" + schemaName + "'",
                "CREATE SCHEMA " + schemaName + " AUTHORIZATION [dbo]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn">
        /// Connection object, preferablly open
        /// If connection open here, it will be automatically closed
        /// </param>
        /// <param name="schemaName">Schema name</param>
        /// <param name="tableName">Table name</param>
        /// <param name="columnDetails">Column definition</param>
        /// <returns></returns>
        public static Boolean CreateTable(SqlConnection conn, String schemaName, String tableName, List<ColumnDefinition> columnDetails)
        {
            StringBuilder columnQuery = new StringBuilder();
            Boolean isColumnMatching = true;
            String table = String.IsNullOrEmpty(schemaName) ? tableName : schemaName + "." + tableName;
            foreach (ColumnDefinition col in columnDetails)
            {
                columnQuery.Append(col.ColumnName + " " + col.Type);
                if (!col.IsNull)
                {
                    columnQuery.Append(" " + "NOT NULL");
                }
                columnQuery.Append(", ");
                if (CheckIfColumnExist(conn, tableName, col.ColumnName)) isColumnMatching = false;             
            }
            columnQuery.Remove(columnQuery.Length - 2, 2);
            if (!isColumnMatching) DropTable(conn, table);
            return CreateDatabaseObject(conn,
                "SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" + table + "') AND type in (N'U')",
                "CREATE TABLE " + table + "(" + columnQuery + ") ON [PRIMARY]");
        }

        private static void DropTable(SqlConnection conn, String tableName)
        {
            SqlCommand cmd = new SqlCommand("DROP TABLE " + tableName + "", conn);
            cmd.ExecuteNonQuery();
        }

        private static Boolean CheckIfColumnExist(SqlConnection conn, String tableName, String columnName)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM sys.columns WHERE Name = N'" + columnName
                + "' and Object_ID = Object_ID(N'" + tableName + "')", conn);
            return cmd.ExecuteNonQuery() == 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans">Transaction object</param>
        /// <param name="schemaName">Schema name</param>
        /// <param name="tableName">Table name</param>
        /// <param name="columnDetails">Column definition</param>
        /// <returns></returns>
        public static Boolean CreateTable(SqlTransaction trans, String schemaName, String tableName, List<ColumnDefinition> columnDetails)
        {
            StringBuilder columnQuery = new StringBuilder();
            String table = String.IsNullOrEmpty(schemaName) ? tableName : schemaName + "." + tableName;
            Boolean isColumnMatching = true;
            foreach (ColumnDefinition col in columnDetails)
            {
                columnQuery.Append(col.ColumnName + " " + col.Type);
                if (col.IsAutoNumber)
                {
                    columnQuery.Append(" " + "IDENTITY(1,1)");
                }
                if (!col.IsNull)
                {
                    columnQuery.Append(" " + "NOT NULL");
                }
                columnQuery.Append(", ");
                if (!CheckIfColumnExist(trans, table, col.ColumnName)) isColumnMatching = false;
            }
            columnQuery.Remove(columnQuery.Length - 2, 2);
            if (!isColumnMatching)
            {
                Boolean status = DropTable(trans, table);
            }
            return CreateDatabaseObject(trans,
                "SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" + table + "') AND type in (N'U')",
                "CREATE TABLE " + table + "(" + columnQuery + ") ON [PRIMARY]");
        }

        private static Boolean CheckIfColumnExist(SqlTransaction trans, String tableName, String columnName)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM sys.columns WHERE Name = N'" + columnName
                   + "' and Object_ID = Object_ID(N'" + tableName + "')", trans.Connection)
            {
                Transaction = trans,
            };
            return (Int32)cmd.ExecuteScalar() == 1;
        }

        private static Boolean DropTable(SqlTransaction trans, String tableName)
        {
            SqlCommand cmd = new SqlCommand("DROP TABLE " + tableName, trans.Connection)
            {
                Transaction = trans,
            };
            return cmd.ExecuteNonQuery() == 1;
        }

        /// <summary>
        /// Insert or update
        /// </summary>
        /// <param name="trans">Transaction Object</param>
        /// <param name="schemaName">Schema Name</param>
        /// <param name="tableName">Table Name</param>
        /// <param name="columnDetails">Column details as name value pair</param>
        /// <param name="whereClause">Where clause with AND operator as name value pair</param>
        /// <returns></returns>
        public static Boolean InsertOrUpdate(SqlTransaction trans, String schemaName, String tableName, Dictionary<String, String> columnDetails, List<KeyValuePair<String, String>> whereClause)
        {
            String where = CreateWhereClause(whereClause, Clause.AND, Operator.Equal);
            SqlCommand cmd = new SqlCommand(String.Format("SELECT COUNT(*) FROM {0}.{1}{2}", schemaName, tableName, where), trans.Connection)
            {
                Transaction = trans,
            };
            if ((Int32)cmd.ExecuteScalar() == 0)
            {
                StringBuilder field = new StringBuilder();
                StringBuilder value = new StringBuilder();
                foreach (KeyValuePair<String, String> node in columnDetails)
                {
                    field.Append(node.Key + ", ");
                    value.Append(node.Value + ", ");
                }
                field.Remove(field.Length - 2, 2);
                value.Remove(value.Length - 2, 2);
                cmd.CommandText = String.Format("INSERT INTO {0}.{1}({2}) VALUES({3})", schemaName, tableName, field.ToString(), value.ToString());
            }
            else
            {
                StringBuilder field = new StringBuilder();
                foreach (KeyValuePair<String, String> node in columnDetails)
                {
                    field.Append(node.Key + " = " + node.Value + ", ");
                }
                field.Remove(field.Length - 2, 2);
                cmd.CommandText = String.Format("UPDATE {0}.{1} SET {2}{3}", schemaName, tableName, field.ToString(), where);
            }
            return cmd.ExecuteNonQuery() == 1;
        }

        public static Boolean DeleteOther(SqlTransaction trans, String schemaName, String tableName, List<KeyValuePair<String, String>> whereClause)
        {
            SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM {0}.{1}{2}", schemaName, tableName, CreateWhereClause(whereClause, Clause.AND, Operator.NotEqual)), trans.Connection)
            {
                Transaction = trans,
            };
            cmd.ExecuteNonQuery();
            return true;
        }

        public static DataRow ReadRow(SqlTransaction trans, String schemaName, String tableName)
        {
            Boolean isOpenHere = false;
            if (trans.Connection.State != ConnectionState.Open)
            {
                trans.Connection.Open();
                isOpenHere = true;
            }

            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}.{1}') AND type in (N'U')", schemaName, tableName), trans.Connection)
            {
                Transaction = trans,
            };
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) //Table is not there
            {
                if (!reader.IsClosed) reader.Close();
                return null;
            }
            if (!reader.IsClosed) reader.Close();

            cmd.CommandText = String.Format("SELECT * FROM {0}.{1}", schemaName, tableName);
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable(); 
            dt.Load(reader);
            if (!reader.IsClosed) reader.Close();
            if (isOpenHere && trans.Connection.State == ConnectionState.Open) trans.Connection.Close();
            if (dt.Rows.Count == 0) return null;
            return dt.Rows[0];
        }

        public static DataTable Read(SqlTransaction trans, String schemaName, String tableName)
        {
            Boolean isOpenHere = false;
            if (trans.Connection.State != ConnectionState.Open)
            {
                trans.Connection.Open();
                isOpenHere = true;
            }

            SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}.{1}') AND type in (N'U')", schemaName, tableName), trans.Connection)
            {
                Transaction = trans,
            };
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) //Table is not there
            {
                if (!reader.IsClosed) reader.Close();
                return null;
            }
            if (!reader.IsClosed) reader.Close();

            cmd.CommandText = String.Format("SELECT * FROM {0}.{1}", schemaName, tableName);
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            if (!reader.IsClosed) reader.Close();
            if (isOpenHere && trans.Connection.State == ConnectionState.Open) trans.Connection.Close();
            return dt;
        }
        
        private static String CreateWhereClause(List<KeyValuePair<String, String>> whereClause, Clause clause, Operator opt)
        {
            StringBuilder where = new StringBuilder();
            String oper;
            switch (opt)
            {
                case Operator.Equal:
                    oper = " = ";
                    break;
                case Operator.NotEqual:
                    oper = " <> ";
                    break;
                default:
                    oper = " = ";
                    break;
            }
            if (whereClause != null && whereClause.Count > 0)
            {
                where.Append(" WHERE ");
                foreach (KeyValuePair<String, String> node in whereClause)
                {
                    where.Append(node.Key + oper + node.Value + " " + clause.ToString() + " ");
                }
                where.Remove(where.Length - (clause.ToString().Length + 1), clause.ToString().Length + 1);
            }
            return where.ToString();
        }

        public class ColumnDefinition
        {
            public String ColumnName { get; set; }
            public String Type { get; set; }
            public Boolean IsNull { get; set; }
            public Boolean IsAutoNumber { get; set; }
        }

        public enum Clause
        {
            AND,
            OR
        }

        public enum Operator
        {
            Equal,
            NotEqual
        }

    }

}
