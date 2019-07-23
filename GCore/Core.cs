using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GCore
{
    public class Core
    {
        #region Settings programm
        private bool webImage { set => webImage = value; }

        #endregion


        /// <summary>
        /// Gиск изображения в сети или в папках
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Возвращает изображение</returns>
        public BitmapImage GetImageFromPathOrNet(string path)
        {
            var result = new BitmapImage { UriSource = new Uri(path) };
            return result;
        }

    }
}

