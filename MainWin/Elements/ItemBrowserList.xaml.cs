using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataHandler;
using GCore;

namespace MainWin
{
    /// <summary>
    /// Логика взаимодействия для ItemBrowserList.xaml
    /// </summary>
    public partial class ItemBrowserList : UserControl
    {
        public ItemBrowserList()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Загрузка данных на элемент
        /// </summary>
        /// <param name="element"></param>
        public void SetDataOnElement(IElement element)
        {
            Core core = new Core();
            buttonFavorite.Tag = element;
            try
            {
                imageElement.Source = core.GetImageFromPathOrNet(element.Image);
            }
            catch
            {
                imageElement.Source = core.GetImageFromPathOrNet("Resources\no_image.png");
            }
            textBlockNameRus.Text = element.NameRus;
            textBlockShortDesc.Text = element.ShortDescription;
        }

        /// <summary>
        /// Добавление программы в список избранных
        /// </summary>
        /// <param name="sender">Обработчик кнопки</param>
        /// <param name="e"></param>
        private void ButtonFavorite_Click(object sender, RoutedEventArgs e)
        {
            //////
        }

    }
}
