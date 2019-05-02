using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCore;
using MySql.Data.MySqlClient;

namespace SQLConn
{
    public class MySQLHandler
    {
        Logger addLog = new Logger();

        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        public static MySqlConnection GetDBConnection(string _table)
        {

            /// <summary>
            /// Адресс к базе данных
            /// </summary>
            string host = "localhost";

            /// <summary>
            /// Порт к адрессу к базе данных
            /// </summary>
            int port = 3306;

            /// <summary>
            /// Логин к базе данных
            /// </summary>
            string database = _table;

            /// <summary>
            /// Таблица базы данных
            /// </summary>
            string username = "root";

            /// <summary>
            /// Пароль к базе данных
            /// </summary>
            string password = "";

            // Connection String.
            string connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            return new MySqlConnection(connString);
        }

        /// <summary>
        /// Отправка запроса базе данных
        /// </summary>
        /// <param name="_sql">Сам запрос</param>
        /// <param name="_table">Таблика</param>
        public void CommanderMySql(string _sql, string _table)
        {
            MySqlConnection conn = GetDBConnection(_table);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(_sql, conn);
            }
            catch (Exception e)
            {
                addLog.addLineInLog(e.ToString());
            }
            finally
            {
                // Закрыть соединение.
                conn.Close();
                // Разрушить объект, освободить ресурс.
                conn.Dispose();
            }

        }
    }
}
