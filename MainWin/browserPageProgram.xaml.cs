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
    /// Логика взаимодействия для browserPage.xaml
    /// </summary>
    public partial class BrowserPageProgram : UserControl
    {

        Core core = new Core();
        public BrowserPageProgram()
        {
            InitializeComponent();
        }

        public void SetDataOnForm(Program _prog)
        {
            buttonFavorite.Tag = _prog;

            textBlockNameRus.Text = _prog.name;
            textBlockNameOrig.Content = _prog.origName;
            programImage.Source = core.GetImageFromPathOrNet(_prog.Image);
            textBlockShortDesc.Text = _prog.shortDescription;
            textBlockDesc.Text = _prog.description;
            textBlockMetaData.Text = "Вес программы достигает ~ " + (_prog.weight/1024) +  " mb.";
        }

        private void ButtonFavority_Click(object sender, RoutedEventArgs e)
        {
            var bt = (Button)sender;
            MainWindow mw = new MainWindow();
            mw.favoritePrograms.Add((Program) bt.Tag);
        }
    }
}
