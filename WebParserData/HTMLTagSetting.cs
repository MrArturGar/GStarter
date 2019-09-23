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
        public int MaxCountPage = 32;
        public string MenuId = "menu-aside-menu";
        private string FilePath = (AppDomain.CurrentDomain.BaseDirectory + "SiteSave.cfg");
        #endregion

        public string HTMLTagBlocksProgram = "//body/div/main";
        public string HTMLTagBlockProgram = "article";
        public string HTMLTagLinkProgram = "//header/a";







        #region File setting 
        public string LastLink;
        private char SplitChar = ';';

        public HTMLTagSetting()
        {
            if (SettingExists())
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
