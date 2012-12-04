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
            Gitlab.Api.Library.Gitlab gitlab = new Gitlab.Api.Library.Gitlab("http://192.168.11.47", "5Bn5tKi3qsB87nwcKzNB");

            gitlab.RequestProjects((List<Project> result) =>
            {
                // プロジェクトリスト取得
            });

            gitlab.RequestUsers((List<User> result) =>
            {
                // プロジェクトリスト取得
            });


            //HttpResponseMessage response = await client.GetAsync("http://192.168.11.47/api/v2/users?page=1&per_page=30&private_token=5Bn5tKi3qsB87nwcKzNB");

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
