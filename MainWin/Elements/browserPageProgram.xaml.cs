﻿using System;
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
    /// Логика взаимодействия для иrowserPageProgram.xaml
    /// </summary>
    public partial class BrowserPageProgram : UserControl
    {
        public BrowserPageProgram()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Заполняет данными элемент управления
        /// </summary>
        /// <param name="_prog">Данные программы</param>
        public void SetDataOnElement(Program _prog)
        {
            Handler handler = new Handler();
            buttonFavorite.Tag = _prog.Id;
            textBlockNameRus.Text = _prog.NameRus;
            textBlockNameOrig.Content = _prog.NameOrig;
            programImage.Source = handler.GetImageFromPathOrNet(_prog.Image);
            textBlockShortDesc.Text = _prog.ShortDescription;
            textBlockDesc.Text = _prog.Description;
            textBlockMetaData.Text = "Вес программы достигает ~ " + (_prog.Weight/1024) +  " mb.";
        }


        /// <summary>
        /// Событие кнопки добавления программы в избранное
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFavority_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).AddElementFromFavoriteList((int)buttonFavorite.Tag);
        }
    }
}
