
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
        private string host;
        private string private_token;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Gitlab()
        {
        }

        public Gitlab(string host, string private_token)
        {
            this.host = host;
            this.private_token = private_token;
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
                // TODO:例外処理
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
                // TODO:例外処理
            }
        }
    }
}
