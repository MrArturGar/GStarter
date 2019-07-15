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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Handler handler = new Handler();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonCloseTab_Click(object sender, RoutedEventArgs e)
        {
            tabControl.Items.RemoveAt(tabControl.SelectedIndex);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataMenu();
        }


        /// <summary>
        /// Обновляет данные ListBoxMenu
        /// </summary>
        private void RefreshDataMenu()
        {
            List<Category> cats = handler.GetCategoryList();
            foreach (Category c in cats)
            {
                ListBoxItem lbi = new ListBoxItem()
                {
                    Content = c.name
                };
                listBoxMenu.Items.Add(lbi);
            }
        }
    }
}
