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
        Logger log = new Logger();
        Handler handler = new Handler();
        public MainWindow()
        {
            Window_Loading();
            InitializeComponent();
        }


        private void ButtonCloseTab_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;

            foreach (TabItem tab in tabControl.Items)
            {
                if (tab.Resources.Contains(bt))
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
            RefreshDataMenu();
            CreateTab();
        }


        /// <summary>
        /// Обновляет данные ListBoxMenu
        /// </summary>
        private void RefreshDataMenu()
        {
            try
            {
                List<Category> cats = handler.GetCategoryList();
                foreach (Category c in cats)
                {
                    Button bt = new Button()
                    {
                        Content = c.rusName,
                        Width = 185,
                        BorderBrush = Brushes.White,
                        Tag = c.name
                    };
                    bt.Click += Buttons_Click;

                    listBoxMenu.Items.Add(bt);
                }
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
        private void Buttons_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            CreateTab(bt.Tag.ToString());
        }

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
                WebBrowser wb = new WebBrowser();//
                #endregion
                switch (_tag)
                {
                    case "Main":
                        {
                            wb.Source = new Uri("https://www.google.ru/");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                g.Children.Add(wb);//
                ti.Content = g;
                tabControl.Items.Add(ti);
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
