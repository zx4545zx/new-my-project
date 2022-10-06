﻿using KClass;
using System;
using System.Data;

namespace Calibration.Model
{
  public class Database
  {
    public static DBClass Connection()
    {
      DBClass db = new DBClass();
      DBClass.Connenct_DB(
        Process.Env.ServerName, 
        Process.Env.DBName, 
        Process.Env.ServerUser, 
        Process.Env.ServerPass
        );

      return db;
    }

    public static DataTable SqlQuery(string sql)
    {
      DBClass db = Connection();
      DataTable AllData = db.QueryDataTable($"{sql}");

      return AllData;
    }

    public static bool SqlQueryExecute(string sql)
    {
      DBClass db = Connection();
      bool AllData = db.QueryExecuteNonQuery($"{sql}");

      return AllData;
    }

    public static int SqlReturnID(string sql)
    {
      DBClass db = Connection();
      int id = Convert.ToInt32(db.QueryExecuteScalar(sql));
      return id;
    }

    public static DataTable SelectAll(string tableName)
    {
      DBClass db = Connection();
      DataTable AllData = db.QueryDataTable($"SELECT * FROM {tableName};");

      return AllData;
    }

    public static DataTable SelectInnerJoin(string attribute, string tableName, string joinTable, string condition)
    {
      // INNER JOIN Customers ON Orders.CustomerID= Customers.CustomerID;
      DBClass db = Connection();
      DataTable AllData = db.QueryDataTable(
        $"SELECT {attribute} FROM {tableName} INNER JOIN {joinTable} ON {condition};"
        );

      return AllData;
    }

    public static DataTable SelectByID(string tableName, string id)
    {
      DBClass db = Connection();
      DataTable Data = db.QueryDataTable($"SELECT * FROM {tableName} WHERE id='{id}';");

      return Data;
    }

    public static DataTable SelectByCondition(string tableName, string condition)
    {
      DBClass db = Connection();
      DataTable Data = db.QueryDataTable($"SELECT * FROM {tableName} WHERE {condition};");

      return Data;
    }

    public static DataTable SelectAttribute(string attribute, string tableName)
    {
      DBClass db = Connection();
      DataTable Data = db.QueryDataTable($"SELECT {attribute} FROM {tableName};");

      return Data;
    }

    public static DataTable SelectAttributeByID(string attribute, string tableName, string id)
    {
      DBClass db = Connection();
      DataTable Data = db.QueryDataTable($"SELECT {attribute} FROM {tableName} WHERE id='{id}';");

      return Data;
    }

    public static DataTable SelectAttributeByCondition(string attribute, string tableName, string condition)
    {
      DBClass db = Connection();
      DataTable Data = db.QueryDataTable($"SELECT {attribute} FROM {tableName} WHERE {condition};");

      return Data;
    }

    public static bool Insert(string tableName, string columnName, string Value)
    {
      DBClass db = Connection();
      string strQuery = $"INSERT INTO {tableName} ({columnName}) VALUES ({Value});";
      bool cb = db.QueryExecuteNonQuery(strQuery);

      return cb;
    }

    public static int InsertReturnID(string tableName, string columnName, string Value)
    {
      DBClass db = Connection();
      string strQuery = $"INSERT INTO {tableName} ({columnName}) VALUES ({Value}) SELECT SCOPE_IDENTITY();";
      int id = Convert.ToInt32(db.QueryExecuteScalar(strQuery));
      return id;
    }

    public static bool UpdateByID(string tableName, string statement, string id)
    {
      DBClass db = Connection();
      string strQuery = $"UPDATE {tableName} SET {statement} WHERE id = {id};";
      bool cb = db.QueryExecuteNonQuery(strQuery);

      return cb;
    }

    public static bool DeleteByID(string tableName, string id)
    {
      DBClass db = Connection();
      string strQuery = $"DELETE FROM {tableName} WHERE id={id};";
      bool cb = db.QueryExecuteNonQuery(strQuery);

      return cb;
    }
  }
}