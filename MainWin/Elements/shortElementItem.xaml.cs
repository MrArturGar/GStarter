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
    /// Логика взаимодействия для shortElementItem.xaml
    /// </summary>
    public partial class shortElementItem : UserControl
    {
        public shortElementItem()
        {
            InitializeComponent();
        }
        public void SetDataOnForm(IElement element)
        {
            Core core = new Core();
            buttonFavorite.Tag = element;

            imageElement.Source = core.GetImageFromPathOrNet(element.Image);
            textBlockNameRus.Text = element.NameRus;
            textBlockShortDesc.Text = element.ShortDescription;
        }
    }
}
