using Gitlab.Api.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Codeplex.Data;
using System.Runtime.InteropServices;

namespace Gitlab_api
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void TestButtonClickHandler(object sender, RoutedEventArgs e)
        {
            Gitlab.Api.Library.Gitlab gitlab = new Gitlab.Api.Library.Gitlab(this.url.Text);

            gitlab.ErrorAction = (Exception exception) =>
                {
                    // TODO:例外発生時の処理
                };

            var ptr = Marshal.SecureStringToGlobalAllocUnicode(this.password.SecurePassword);

            try
            {
                // セキュア文字列を平文へ変換
                string password = Marshal.PtrToStringUni(ptr);

                // セッションの取得
                gitlab.RequestSession(this.email.Text, password, (bool saccess) =>
                {
                    gitlab.RequestProjects((List<Project> result) =>
                    {
                        // プロジェクトリスト取得
                    });

                    gitlab.RequestUsers((List<User> result) =>
                    {
                        // プロジェクトリスト取得
                    });
                });
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            }

            /*
            using (StreamReader r = new StreamReader(@"projects.json"))
            {
                string responseBody = r.ReadLine();

                List<Project> projects = ProjectsFactory.Create(responseBody);
            }
            */
        }
    }
}
