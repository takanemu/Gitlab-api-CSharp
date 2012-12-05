
namespace Gitlab.Api.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Gitlab制御クラス
    /// </summary>
    public class Gitlab
    {
        /// <summary>
        /// ホスト名
        /// </summary>
        private string host;

        /// <summary>
        /// プライベートトークン
        /// </summary>
        private string private_token;

        /// <summary>
        /// エラー通知アクション
        /// </summary>
        private Action<Exception> errorAction = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Gitlab()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="host">ホスト名</param>
        /// <param name="private_token">プライベートトークン</param>
        public Gitlab(string host)
        {
            this.host = host;
        }

        /// <summary>
        /// ホスト名
        /// </summary>
        public string Host
        {
            set
            {
                this.host = value;
            }
        }

        /// <summary>
        /// プライベートトークン
        /// </summary>
        public string PrivateToken
        {
            set
            {
                this.private_token = value;
            }
        }

        /// <summary>
        /// エラー通知アクション
        /// </summary>
        public Action<Exception> ErrorAction
        {
            set
            {
                this.errorAction = value;
            }
        }

        /// <summary>
        /// セッションの取得
        /// </summary>
        /// <param name="email">電子メール</param>
        /// <param name="password">パスワード</param>
        /// <param name="result">完了コールバック関数</param>
        public async void RequestSession(string email, string password, Action<bool> result)
        {
            try
            {
                HttpClient client = new HttpClient();

                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "email", email },
                    { "password", password },
                });

                HttpResponseMessage response = await client.PostAsync(this.host + "/api/v2/session", content);

                if (response.IsSuccessStatusCode == false)
                {
                    result(false);
                }
                string responseBody = response.Content.ReadAsStringAsync().Result;

                Action action = () =>
                {
                    Session session = SessionFactory.Create(responseBody);

                    // プライベートトークンの取得
                    this.private_token = session.PrivateToken;

                    result(true);
                };

                var task = Task.Factory.StartNew(action);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                if (this.errorAction != null)
                {
                    this.errorAction(ex);
                }
                result(false);
            }
        }

        /// <summary>
        /// プロジェクトリストの取得
        /// </summary>
        /// <param name="result">結果</param>
        public async void RequestProjects(Action<List<Project>> result)
        {
            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(this.host + "/api/v2/projects?" + "&private_token=" + this.private_token);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Action action = () =>
                {
                    List<Project> projects = ProjectsFactory.Create(responseBody);

                    result(projects);
                };

                var task = Task.Factory.StartNew(action);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                if (this.errorAction != null)
                {
                    this.errorAction(ex);
                }
            }
        }

        /// <summary>
        /// ユーザーリストの取得
        /// </summary>
        /// <param name="result">結果</param>
        public async void RequestUsers(Action<List<User>> result)
        {
            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(this.host + "/api/v2/users?" + "&private_token=" + this.private_token);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Action action = () =>
                {
                    List<User> projects = UsersFactory.Create(responseBody);

                    result(projects);
                };

                var task = Task.Factory.StartNew(action);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                if (this.errorAction != null)
                {
                    this.errorAction(ex);
                }
            }
        }
    }
}
