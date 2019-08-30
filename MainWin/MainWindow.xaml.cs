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
using MainWin.Elements;

namespace MainWin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Список избранных программ
        /// </summary>
        public List<Program> favoritePrograms = new List<Program>();

        /// <summary>
        /// Инициализация логера
        /// </summary>
        Logger log = new Logger();

        /// <summary>
        /// Инициализация класса обработки информации
        /// </summary>
        Handler handler = new Handler();

        public MainWindow()
        {
            InitializeComponent();
            Window_Loading();
        }


        /// <summary>
        /// Обработчик событий кнопок закрытия на вкладке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseTab_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;

            foreach (TabItem tab in tabControl.Items)
            {
                bool finded = tab.Resources.Contains(bt);
                if (finded)
                {
                    tabControl.Items.Remove(tab);
                    break;
                }
            }
        }


        /// <summary>
        /// Обработка данных до старта окна
        /// </summary>
        private void Window_Loading()
        {
            GetDataMenu();
            CreateTab();
        }

        /// <summary>
        /// Обновляет данные ListBoxMenu
        /// </summary>
        private void GetDataMenu()
        {
            try
            {
                #region Пункты меню из базы данных
                List<MenuItem> rootMenu = new List<MenuItem>();
                List<Category> cats = handler.GetCategoryList();
                foreach (Category c in cats)
                {
                    if (c.IdParent == -1)
                    {
                        Menu menu = new Menu();
                        MenuItem item = new MenuItem()
                        {
                            Header = c.NameRus,
                            Width = 185,
                            Tag = c.IdCatalog,
                            Background = Brushes.Gray,
                            FontSize = 14,
                            Foreground = Brushes.White
                        };
                        rootMenu.Add(item);
                        menu.Items.Add(item);
                        listBoxMenu.Items.Add(menu);
                    }
                    else
                    {
                        foreach (MenuItem m in rootMenu)
                        {
                            if ((int) m.Tag == c.IdParent)
                            {
                                MenuItem item = new MenuItem()
                                {
                                    Header = c.NameRus,
                                    Width = Double.NaN,
                                    Tag = c.IdCatalog,
                                    Foreground = Brushes.Black
                                };
                                item.Click += ButtonsMenu_Click;
                                m.Items.Add(item);
                                break;
                            }
                        }
                    }
                }
                #endregion

                #region Тест
                Button buttonMenuTest = new Button()
                {
                    Content = "Тест",
                    Tag = "1",
                    FontSize = buttonMenuMain.FontSize,
                    Width = buttonMenuMain.Width,
                    BorderBrush = buttonMenuMain.BorderBrush,
                    FontWeight = buttonMenuMain.FontWeight,
                    Foreground = buttonMenuMain.Foreground,
                    Background = buttonMenuMain.Background
                };
                buttonMenuTest.Click += ButtonsMenu_Click;
                listBoxMenu.Items.Add(buttonMenuTest);
                #endregion


            }
            catch (Exception ex)
            {
                log.addLineToLog(ex.ToString());
                log.ErrorMessege("Критическая ошибка!", "Проблема с загрузкой категорий.");
            }

        }

        /// <summary>
        /// Вызывает и передает тэг кнопки вкладке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonsMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem bt = (MenuItem)sender;
            CreateTab(bt.Tag.ToString(), ((string) bt.Header));
        }


        /// <summary>
        /// Создание вкладок браузера
        /// </summary>
        /// <param name="_tag">Наименование вкладки на англ.</param>
        /// <param name="_rusName">Наименование вкладки на рус.</param>
        /// <returns>Успешное создание</returns>
        private bool CreateTab(string _tag = "Main", string _rusName = "Главное")
        {
            try
            {
                #region инициализация
                #region Шаблон header вкладки
                WrapPanel wp = new WrapPanel();
                TextBlock tb = new TextBlock()
                {
                    Text = _rusName
                };
                Button bt = new Button()
                {
                    Margin = new Thickness(5, 0, 0, 0),
                    Content = "✖",
                    Width = 25,
                    Background = null,
                    BorderBrush = null
                };
                bt.Click += ButtonCloseTab_Click;


                wp.Children.Add(tb);
                wp.Children.Add(bt);
                #endregion

                TabItem ti = new TabItem()
                {
                    Tag = _tag,
                    Header = wp,
                    MaxWidth = 100
                };
                ti.Resources.Add(bt, bt);

                Grid g = new Grid();
                ScrollViewer scroll = new ScrollViewer()
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
                };
                g.Children.Add(scroll);
                ti.Content = g;
                tabControl.Items.Add(ti);
                #endregion


                //Выбор необходимого шаблона окна
                switch (_tag)
                {
                    case "Main":
                        {
                            WebBrowser wb = new WebBrowser();//
                            wb.Source = new Uri("https://www.google.ru/");
                            g.Children.Add(wb);//
                            break;
                        }
                    case "Test":
                        {
                            BrowserPageProgram pageProg = new BrowserPageProgram();
                            //g.Children.Add(pageProg);
                            scroll.Content = pageProg;
                            //pageProg.SetDataOnForm();
                            break;
                        }
                    default:
                        {
                            BrowserList browserList = new BrowserList();
                            browserList.SetDataToBrowser("Test", Int32.Parse(_tag));
                            scroll.Content = browserList;
                            break;
                        }
                }
                ti.IsSelected = true;
                return true;
            }
            catch (Exception ex)
            {
                log.addLineToLog(ex.ToString());
                return false;
            }
        }

    }
}
