﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Practic4BIG
{
    class DBMySQLUtils
    {
        public static MySqlConnection
            GetDBConnection(string host,int port,string database, string username, string password)
        {
            String connString = "Server = " + host + "; Database = " + database + "; Port = " + port + "; User = " + username + "; Password = " + password;
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
