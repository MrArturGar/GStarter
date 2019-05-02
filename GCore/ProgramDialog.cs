using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GCore
{
    class ProgramDialog
    {
        public void PrintError(Exception _e, bool _exit)
        {
            MessageBox.Show(_e.ToString(), "Ошибка!!!");

            if (_exit)
                Environment.Exit(0);
        }

        public bool PrintConfirm(string _question)
        {
           
            MessageBoxResult result = MessageBox.Show(_question, "Подтвердите", MessageBoxButton.YesNo);

            if (result.ToString() == "6")
                return true;
            else
                return false;
        }
    }
}
