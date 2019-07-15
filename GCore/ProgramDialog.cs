using System;
using System.Windows;

namespace GCore
{
    public class ProgramDialog
    {
        public void PrintError(bool _exit, Exception _e = null, string _text = "")
        {
            MessageBox.Show(_text + "\n" + _e.ToString(), "Ошибка!!!");

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
