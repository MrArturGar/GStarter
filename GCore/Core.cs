using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GCore
{
    public class Core
    {
        public bool StartInstallerProgram()
        {

            return true;
        }

        private string GetArgument(int _id)
        {
            try
            {
                string arg;
// / silent
// / verysilent
// / quiet
// / qb
// / qn
// / qr
// / passive
// / s
// / S
// / qn REBOOT = ReallySuppress
//  / s / v" /qn REBOOT=ReallySuppress

//Ключи для отмены перезагрузки:

// / norestart
// / noreboot
                return arg;
            }
            catch
            {
                return "";
            }
        }

    }
}

