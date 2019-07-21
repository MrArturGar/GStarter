using System;
using System.Text;
using System.IO;
using System.Windows;

namespace GCore
{
    public class Logger
    {
        
        /// <summary>
        /// Путь к файлу логирования
        /// </summary>
        private string pathLogger = (AppDomain.CurrentDomain.BaseDirectory + "//logger.log");

        /// <summary>
        /// Добавить строчку в логгер
        /// </summary>
        /// <param name="_text">Текст для добавление</param>
        public void addLineToLog(string _text)
        {
            using (StreamWriter sw = new StreamWriter(pathLogger, true, Encoding.Default))
            {
                sw.WriteLine(DateTime.Now.ToString() + " — " + _text);
            }
        }


        /// <summary>
        /// Метод вывода сообщения об ошибке и закрытие программы
        /// </summary>
        /// <param name="_title">Заголовок</param>
        /// <param name="_text">Текст</param>
        /// <param name="_closeApp">Завершение программы</param>
        public void ErrorMessege(string _title, string _text, bool _closeApp = false)
        {
            if (_closeApp)
                Environment.Exit(1);
            MessageBox.Show(_text, _title);
        }
    }
}
