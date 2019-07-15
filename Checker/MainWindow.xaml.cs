using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Security.Cryptography;
using GCore;

namespace Checker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string pathApp = AppDomain.CurrentDomain.BaseDirectory;
        StreamWriter CheckFilesPath = new StreamWriter(pathApp + "\\checkFiles.tmp");
        ProgramDialog PD = new ProgramDialog();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                labelStatus.Content = "Старт программы...";
                Progress<int> prog = new Progress<int>(SetProgress);
                CancellationTokenSource m_cancelTokenSource = new CancellationTokenSource();
                await StartProcessRefresh(prog, m_cancelTokenSource.Token);
                labelStatus.Content = "Готово";

                StartMainWindow();
            }
            catch
            {
                labelStatus.Content = "Ошибка! Отмена...";
            }
        }

        /// <summary>Updates the progress display</summary>
        /// <param name="value">The new progress value</param>
        private void SetProgress(int _value)
        {
            // Add 1 so that progress is "completed"
            int adjustedValue = _value + 1;

            // Make sure value is in range
            adjustedValue = (int)Math.Max(adjustedValue, progressBar.Minimum);
            adjustedValue = (int)Math.Min(adjustedValue, progressBar.Maximum);

            progressBar.Value = adjustedValue;
            //labelStatus.Content = $"{_value}% - {_text}";
        }

        private Task StartProcessRefresh(IProgress<int> prog, CancellationToken ct)
        {
            string[] files = Directory.GetFiles(pathApp);
            int numProgress = files.Length;
            progressBar.Maximum = numProgress;

            return Task.Run(() =>
            {
                try
                {

                    for (int i = 0; i < numProgress; i++)
                    {
                        string st = (pathApp + "checkFiles.tmp");
                        //Сбор хеш всех файлов
                        if (st != files[i])
                            CheckFiles(files[i]);

                        //ct.ThrowIfCancellationRequested();
                        prog.Report(i);
                        Thread.Sleep(200);
                    }

                }
                catch (Exception e)
                {
                    PD.PrintError(true, e);
                }
                finally
                {
                    CheckFilesPath.Close();
                }
            }, ct);

        }


        /// <summary>
        /// Сбор хеш всех файлов программы
        /// </summary>
        /// <param name="_path">Путь к файлу</param>
        private void CheckFiles(string _path)
        {
            FileStream file = File.OpenRead(_path);
            string chksum = BitConverter.ToString(SHA1.Create().ComputeHash(file));
            CheckFilesPath.WriteLine(chksum);
            file.Close();
            ///////Временные строчки
            StreamWriter sw = new StreamWriter(pathApp + "//checkFiles.txt");
            sw.WriteLine(file.Name + " " + chksum);
            sw.Close();
            ////////////////////////

        }

        private void StartMainWindow()
        {
            try
            {
                MainWin.MainWindow main = new MainWin.MainWindow();
                main.Show();
                Close();
            }
            catch (Exception e)
            {
                PD.PrintError(true, e);
            }
        }
    }
}
