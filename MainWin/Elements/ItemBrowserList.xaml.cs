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
using MainWin;
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
            Handler handler = new Handler();
            buttonFavorite.Tag = element.Id;
            imageElement.Source = handler.GetImageFromPathOrNet(element.Image);
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
            (Application.Current.MainWindow as MainWindow).AddElementFromFavoriteList((int) buttonFavorite.Tag);
        }

        #region События для элемента
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //System.ArgumentException: "Необходимо отсоединить указанный дочерний элемент от родительского элемента Visual, прежде чем подсоединять его к новому элементу Visual."
            (Application.Current.MainWindow as MainWindow).OpenPage((int) buttonFavorite.Tag);
        }

        #endregion

    }
}
