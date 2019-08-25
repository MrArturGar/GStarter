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

namespace MainWin.Elements
{
    /// <summary>
    /// Логика взаимодействия для BrowserList.xaml
    /// </summary>
    public partial class BrowserList : UserControl
    {
        public BrowserList()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Загрузка элементов на форму
        /// </summary>
        /// <param name="_namePage"></param>
        /// <returns></returns>
        public bool SetElementsToBrowser(string _namePage, int _idCategory, int _numPage = 1)
        {
            try
            {
                TextBlockNamePage.Text = _namePage;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
