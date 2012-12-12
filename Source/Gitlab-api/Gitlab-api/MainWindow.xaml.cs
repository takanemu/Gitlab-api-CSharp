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
using Gitlab;

namespace Gitlab_api
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Gitlab.Gitlab gitlab;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ConnectButtonClickHandler(object sender, RoutedEventArgs e)
        {
            this.gitlab = new Gitlab.Gitlab(this.url.Text);

            this.gitlab.ErrorAction = (Exception exception) =>
                {
                    // TODO:例外発生時の処理
                };

            var ptr = Marshal.SecureStringToGlobalAllocUnicode(this.password.SecurePassword);

            try
            {
                // セキュア文字列を平文へ変換
                string password = Marshal.PtrToStringUni(ptr);

                // セッションの取得
                bool saccess = await this.gitlab.RequestSessionAsync(this.email.Text, password);

                if (saccess)
                {
                    List<Project> projects = await this.gitlab.RequestProjectsAsync();

                    if (projects.Count > 0)
                    {
                        // プロジェクトリスト取得
                        this.ReadProject(projects[0].Id);

                        // プロジェクトメンバーリスト取得
                        this.ReadProjectMember(projects[0].Id);
                    }

                    List<User> users = await this.gitlab.RequestUsersAsync();

                    if (users.Count > 0)
                    {
                        // ユーザーリスト取得
                        this.ReadUser(users[0].Id);
                    }
                }
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            }
        }

        private async void ReadProject(string id)
        {
            // プロジェクト情報取得
            Project project = await this.gitlab.RequestProjectAsync(id);
        }

        private async void ReadProjectMember(string id)
        {
            List<ProjectTeamMember> members = await this.gitlab.RequestProjectTeamMembers(id);
        }

        private async void ReadUser(string id)
        {
            // ユーザー情報取得
            User user = await this.gitlab.RequestUserAsync(id);
        }

        /// <summary>
        /// プロジェクトの作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NewProjectHandler(object sender, RoutedEventArgs e)
        {
            bool result = await this.gitlab.CreateProjectAsync(
                this.projectName.Text,
                this.code.Text,
                this.path.Text,
                "description",
                string.Empty,
                null,
                null,
                null,
                null);
        }

        /// <summary>
        /// 鍵の追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddKeyClickHandler(object sender, RoutedEventArgs e)
        {
            bool result = await this.gitlab.AddSSHkeyAsync(this.keyTitle.Text, this.keyBody.Text);
        }
    }
}
