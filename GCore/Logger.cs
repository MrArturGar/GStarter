using System;
using System.Text;
using System.IO;

namespace GCore
{
    public class Logger
    {
        public string pathLogger = (AppDomain.CurrentDomain.BaseDirectory + "//logger.log");

        /// <summary>
        /// Добавить строчку в логгер
        /// </summary>
        /// <param name="_text">Текст для добавление</param>
        public void addLineInLog(string _text)
        {
            using (StreamWriter sw = new StreamWriter(pathLogger, false, Encoding.Default))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + _text);
            }
        }
    }
}
