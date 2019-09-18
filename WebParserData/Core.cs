using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.OffScreen;

namespace WebParserData
{
    class Core
    {
        HTMLTagSetting setting = new HTMLTagSetting();
        private ChromiumWebBrowser browser;
        private bool ProcessWork = false;
        public void StartBotProcess()
        {
            ProcessWork = true;
        }

        public void StopBotProcess(bool forcibly = false)
        {
            ProcessWork = false;
        }

        private async void AsynsBot()
        {
            List<Uri> UriList = GetProgramList(GetListLink());
            do
            {
                await Task.Run(() => Bot(UriList));

            } while (ProcessWork);
        }

        private void Bot(List<Uri> UriList)
        {

        }

        private string GetListLink()
        {
            string URL = setting.SiteHost;
            try
            {
                if (setting.SettingExists())
                {
                    URL = setting.LastLink;
                }
            }
            catch
            {

            }
            return URL;

        }

        private List<Uri> GetProgramList(string _url)
        {
            browser = new ChromiumWebBrowser(_url);
            return null;
        }

        private void InitializeWebBrowser()
        {
        }
    }
}
