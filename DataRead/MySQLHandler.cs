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
        Logger Log = new Logger();

        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        private MySqlConnection GetDBConnection()
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
            string database = "gstarter";

            /// <summary>
            /// Таблица базы данных
            /// </summary>
            string username = "gstarter";

            /// <summary>
            /// Пароль к базе данных
            /// </summary>
            string password = "1234";

            // Connection String.
            string connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            return new MySqlConnection(connString);
        }

        /// <summary>
        /// Отправка запроса базе данных
        /// </summary>
        /// <param name="_table">Таблица</param>
        public List<string> CommanderMySql(string _table)
        {
            //Подготавливаем коллекцию для ответа
            List<string> response = new List<string>(); ;
            //Строка запроса
            string sql;
            switch (_table)
            {
                case "category":
                    sql = "Select ID_Category, RusName, Name, Short_Description, Description, Image from category";
                    break;

                default:
                    Log.addLineToLog("SWITCH ERROR!!! Uncorrect programm code.");
                    return response;
            }


            //Создаем подключение
            MySqlConnection conn = GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    //Фасуем ответы
                    while (reader.Read())
                    {
                        string resLine = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            resLine += (reader[i].ToString() + (i != reader.FieldCount - 1 ? "," : ""));
                        }
                        response.Add(resLine);
                    }
                }
            }
            catch (Exception e)
            {
                //Логирование
                Log.addLineToLog(e.ToString());
            }
            finally
            {
                // Закрыть соединение.
                conn.Close();
                // Разрушить объект, освободить ресурс.
                conn.Dispose();
            }
            return response;
        }
    }
}
