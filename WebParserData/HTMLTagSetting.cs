using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebParserData
{
    public class HTMLTagSetting
    {
        #region Main settings
        public string SiteHost = "www.besplatnyeprogrammy.ru/";
        public string PageLink = "page/";
        public string MenuId = "menu-aside-menu";
        private string FilePath = (AppDomain.CurrentDomain.BaseDirectory + "SiteSave.cfg");
        #endregion

        #region File setting 
        public string LastLink;
        private char SplitChar = ';';

        public HTMLTagSetting()
        {
            using (StreamReader stream = new StreamReader(FilePath))
            {
                string[] settings = stream.ReadToEnd().Split(';');
                LastLink = settings[0];
            };
        }

        public bool SettingExists()
        {
            return File.Exists(FilePath);
        }
        #endregion
    }
}
