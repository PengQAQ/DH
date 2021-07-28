using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.Data;

public class MySQLManager
{
    public static MySqlConnection SqlConnection;    //对象
    private static string host;     //IP地址
    private static string id;       //用户名
    private static string pwd;      //密码
    private static string dataBase; //数据库名
    private static string table;    //表名
    public MySQLManager(string _host, string _id, string _pwd, string _dataBase)
    {
        host = _host;
        id = _id;
        pwd = _pwd;
        dataBase = _dataBase;
        table = "str";
        OpenSql();
    }

    ///
    ///打开数据库
    ///
    public void OpenSql()
    {
        try
        {
            string SqlString = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", dataBase, host, id, pwd, "3306");
            SqlConnection = new MySqlConnection(SqlString);
            SqlConnection.Open();
            Debug.Log("打开数据库");
        }
        catch (Exception e)
        {
            Debug.Log("服务器连接失败，请重新检查是否打开MySql服务。" + e.Message.ToString());
        }
    }

    /// <summary>
    /// 查询数据
    /// </summary>

    public string SelectData(string id)//查询，读取数据
    {
        OpenSql();
        try
        {
            string read_sql = "select answer from str where id = " + id;//sql命令，选择user1表
            MySqlCommand read_cmd = new MySqlCommand(read_sql, SqlConnection);
            MySqlDataReader reader = read_cmd.ExecuteReader();
            while (reader.Read())
            {
                //
            }
            string data = reader[0].ToString();
            return data;
        }
        catch (Exception e)
        {
            Debug.Log("Error");
            return null;
        }
        finally
        {
            Close();
        }

    }


    /// <summary>
    /// 插入数据
    /// </summary>
    public void Insert(string col, string values)
    {
        OpenSql();
        try
        {
            string query = "insert into " + table + " values(" + col + "," + values + ");";
            MySqlCommand read_cmd = new MySqlCommand(query, SqlConnection);
            MySqlDataReader reader = read_cmd.ExecuteReader();

        }
        catch (Exception e)
        {
            Debug.Log("Error");
        }
        finally
        {
            Close();
        }

    }

    public void Close()
    {
        if (SqlConnection != null)
        {
            SqlConnection.Close();
            SqlConnection.Dispose();
            SqlConnection = null;
        }
        Debug.Log("关闭数据库");
    }
}