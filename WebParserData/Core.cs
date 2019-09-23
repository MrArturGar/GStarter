using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.OffScreen;
using HtmlAgilityPack;
using System.Windows.Threading;
using System.Threading;

namespace WebParserData
{
    class Core
    {
        HTMLTagSetting setting = new HTMLTagSetting();
        private ChromiumWebBrowser browser;
        private static bool ProcessWork = false;
        private bool IsParsingProgram = false;
        private List<string> UrlList = new List<string>();
        public void StartBotProcess()
        {
            ProcessWork = true;
            AsynsBot();
        }

        public void StopBotProcess(bool forcibly = false)
        {
            ProcessWork = false;
        }

        private async void AsynsBot()
        {
            await Task.Run(() => GetProgramList(GetListPageLink()));
        }


        /// <summary>
        /// Получаем начальную ссылку на список программ
        /// </summary>
        /// <returns></returns>
        private string GetListPageLink()
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


        /// <summary>
        /// Запускаем браузер для получения списка
        /// </summary>
        /// <param name="_url"></param>
        private void GetProgramList(string _url)
        {
            if (ProcessWork == true)
            {
                browser = new ChromiumWebBrowser(_url);
                browser.FrameLoadEnd += OnFrameLoadEnd;
            }
            else
            {
                browser.Stop();
                browser.Delete();
            }
        }

        private async void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            string html = await browser.GetBrowser().MainFrame.GetSourceAsync();

            if (IsParsingProgram)
            {

            }
            else
            {
                if (html != null)
                    GetLinkPrograms(html);
            }
        }

        private void GetLinkPrograms(string _html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(_html);
            HtmlNode root = htmlDoc.DocumentNode.SelectSingleNode(setting.HTMLTagBlocksProgram);
            foreach (var child in root.ChildNodes)
            {
                if (child.Name == setting.HTMLTagBlockProgram)
                {
                    var tag = root.SelectSingleNode(setting.HTMLTagLinkProgram).Attributes[0].Value;
                    UrlList.Add(tag);
                    MainWindow.ChangeUI();

                }
            }
            GetProgramList(GetNextListPage(browser.Address));
        }


        private string GetNextListPage(string _url)
        {
            string URL = null;
            if (_url == setting.SiteHost)
            {
                URL = _url + setting.PageLink + "2";
            }
            else
            {
                string[] linkSplit = _url.Split('/');
                if (Int32.Parse(linkSplit[linkSplit.Length - 1]) < setting.MaxCountPage)
                {
                    for (int i = 0; i < linkSplit.Length; i++)
                    {
                        URL = URL + linkSplit[i];
                    }
                    URL += $"";
                }
                else
                    ProcessWork = false;
            }
            return URL;
        }
    }
}
