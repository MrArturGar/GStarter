using DataHandler;
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
using GCore;
using System.Windows.Shapes;

namespace MainWin.Elements
{
    /// <summary>
    /// Логика взаимодействия для BrowserList.xaml
    /// </summary>
    public partial class BrowserList : UserControl
    {
        //Айди категории
        private int IdCategory;
        //Номер страницы категории
        private int NumPageCategory;

        public BrowserList()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Загрузка элементов на форму
        /// </summary>
        /// <param name="_namePage"></param>
        /// <returns></returns>
        public void SetDataToBrowser(string _nameCategory, int _idCategory, int _numPage = 1)
        {
            //NameCategory = _nameCategory;
            IdCategory = _idCategory;
            NumPageCategory = _numPage;
            TextBlockNamePage.Text  = _nameCategory;

            GetElementsBrowser();

        }

        private void GetElementsBrowser()
        {
            try
            {
                Handler handler = new Handler();
                List<Program> programList = handler.GetProgramList(NumPageCategory, IdCategory);
                foreach (Program pr in programList)
                {
                    ItemBrowserList item = new ItemBrowserList();
                    item.SetDataOnElement(pr);
                    WrapPanelElementList.Children.Add(item);
                }
            }
            catch (Exception e)
            {
                Logger log = new Logger();
                log.ErrorMessege("Error" ,e.ToString(), true);
            }
        }
    }
}
