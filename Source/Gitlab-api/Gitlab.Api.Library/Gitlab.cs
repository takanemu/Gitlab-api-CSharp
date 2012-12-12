
namespace Gitlab
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
        /// GET取得
        /// </summary>
        /// <param name="uri">アドレス</param>
        /// <returns>JSON</returns>
        private async Task<string> HttopGet(string uri)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        /// <summary>
        /// POST取得
        /// </summary>
        /// <param name="uri">アドレス</param>
        /// <param name="content">パラメーター</param>
        /// <returns>HttpResponseMessage</returns>
        private async Task<HttpResponseMessage> HttpPost(string uri, FormUrlEncodedContent content)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(uri, content);

            return response;
        }

        /// <summary>
        /// セッションの取得
        /// </summary>
        /// <param name="email">電子メール</param>
        /// <param name="password">パスワード</param>
        /// <param name="result">完了コールバック関数</param>
        /// <returns>結果</returns>
        public async Task<bool> RequestSessionAsync(string email, string password)
        {
            try
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "email", email },
                    { "password", password },
                });

                string uri = string.Format("{0}/api/v2/session", this.host);

                HttpResponseMessage response = await this.HttpPost(uri, content);

                if (response.IsSuccessStatusCode == false)
                {
                    return false;
                }
                string responseBody = response.Content.ReadAsStringAsync().Result;

                Session session = SessionFactory.Create(responseBody);

                // プライベートトークンの取得
                this.private_token = session.PrivateToken;
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// プロジェクトリストの取得
        /// </summary>
        /// <returns>プロジェクトリスト</returns>
        public async Task<List<Project>> RequestProjectsAsync()
        {
            List<Project> projects = new List<Project>();

            try
            {
                string uri = string.Format("{0}/api/v2/projects?private_token={1}", this.host, this.private_token);

                string responseBody = await this.HttopGet(uri);

                projects = ProjectsFactory.Creates(responseBody);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
            }
            return projects;
        }

        /// <summary>
        /// プロジェクトの取得
        /// </summary>
        /// <param name="id">プロジェクトID</param>
        /// <returns>プロジェクト情報</returns>
        public async Task<Project> RequestProjectAsync(string id)
        {
            Project project = null;

            try
            {
                string uri = string.Format("{0}/api/v2/projects/{1}?private_token={2}", this.host, id, this.private_token);

                string responseBody = await this.HttopGet(uri);

                project = ProjectsFactory.Create(responseBody);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
            }
            return project;
        }

        /// <summary>
        /// プロジェクトの作成
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="path"></param>
        /// <param name="description"></param>
        /// <param name="default_branch"></param>
        /// <param name="issues_enabled"></param>
        /// <param name="wall_enabled"></param>
        /// <param name="merge_requests_enabled"></param>
        /// <param name="wiki_enabled"></param>
        /// <param name="result"></param>
        /// <returns>結果</returns>
        public async Task<bool> CreateProjectAsync(
            string name,
            string code,
            string path,
            string description,
            string default_branch,
            bool? issues_enabled,
            bool? wall_enabled,
            bool? merge_requests_enabled,
            bool? wiki_enabled)
        {
            try
            {
                var dic = new Dictionary<string, string>
                {
                    { "name", name },
                };
                
                // オプション
                if (!string.IsNullOrEmpty(code))
                {
                    dic.Add("code", code);
                }
                if (!string.IsNullOrEmpty(path))
                {
                    dic.Add("path", path);
                }
                if (!string.IsNullOrEmpty(description))
                {
                    dic.Add("description", description);
                }
                if (!string.IsNullOrEmpty(default_branch))
                {
                    dic.Add("default_branch", default_branch);
                }
                if (issues_enabled != null)
                {
                    dic.Add("issues_enabled", issues_enabled.ToString());
                }
                if (wall_enabled != null)
                {
                    dic.Add("wall_enabled", wall_enabled.ToString());
                }
                if (merge_requests_enabled != null)
                {
                    dic.Add("merge_requests_enabled", merge_requests_enabled.ToString());
                }
                if (wiki_enabled != null)
                {
                    dic.Add("wiki_enabled", wiki_enabled.ToString());
                }
                var content = new FormUrlEncodedContent(dic);

                string uri = string.Format("{0}/api/v2/projects?private_token={1}", this.host, this.private_token);

                HttpResponseMessage response = await this.HttpPost(uri, content);

                if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // 登録失敗
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    // 権限なし
                }
                return false;
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
                return false;
            }
        }

        /// <summary>
        /// チームメンバーリスト取得
        /// </summary>
        /// <param name="id">プロジェクトID</param>
        /// <returns>チームメンバーリスト</returns>
        public async Task<List<ProjectTeamMember>> RequestProjectTeamMembers(string id)
        {
            List<ProjectTeamMember> members = new List<ProjectTeamMember>();

            try
            {
                string uri = string.Format("{0}/api/v2/projects/{1}/members?private_token={2}", this.host, id, this.private_token);

                string responseBody = await this.HttopGet(uri);

                members = ProjectTeamMemberFactory.Creates(responseBody);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
            }
            return members;
        }

        /// <summary>
        /// チームメンバー取得
        /// </summary>
        /// <param name="projectId">プロジェクトID</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>チームメンバークラス</returns>
        public async Task<ProjectTeamMember> RequestProjectTeamMember(string projectId, string userId)
        {
            ProjectTeamMember member = null;

            try
            {
                string uri = string.Format("{0}/api/v2/projects/{1}/members/{2}?private_token={3}", this.host, projectId, userId, this.private_token);

                string responseBody = await this.HttopGet(uri);

                member = ProjectTeamMemberFactory.Create(responseBody);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
            }
            return member;
        }

        // TODO:
        // Get project team member
        // Add project team member
        // Edit project team member
        // Remove project team member
        // List project hooks
        // Get project hook
        // Add project hook
        // Edit project hook
        // Delete project hook

        /// <summary>
        /// ユーザーリストの取得
        /// </summary>
        /// <returns>ユーザーリスト</returns>
        public async Task<List<User>> RequestUsersAsync()
        {
            List<User> users = new List<User>();

            try
            {
                string uri = string.Format("{0}/api/v2/users?private_token={1}", this.host, this.private_token);

                string responseBody = await this.HttopGet(uri);

                users = UsersFactory.Creates(responseBody);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
            }
            return users;
        }

        /// <summary>
        /// ユーザーの取得
        /// </summary>
        /// <param name="id">ユーザーID</param>
        /// <returns>結果</returns>
        public async Task<User> RequestUserAsync(string id)
        {
            User user = null;

            try
            {
                string uri = string.Format("{0}/api/v2/users/{1}?private_token={2}", this.host, id, this.private_token);

                string responseBody = await this.HttopGet(uri);

                user = UsersFactory.Create(responseBody);
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
            }
            return user;
        }

        /// <summary>
        /// 鍵の追加
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="key">鍵</param>
        /// <param name="result">結果</param>
        public async Task<bool> AddSSHkeyAsync(string title, string key)
        {
            try
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "title", title },
                    { "key", key },
                });

                string uri = string.Format("{0}/api/v2/user/keys?private_token={1}", this.host, this.private_token);

                HttpResponseMessage response = await this.HttpPost(uri, content);

                if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    //string responseBody = response.Content.ReadAsStringAsync().Result;
                    return true;
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // 登録失敗
                }
                return false;
            }
            catch (HttpRequestException ex)
            {
                // 例外処理
                this.NotifyException(ex);
                return false;
            }
        }

        // TODO:
        // User creation
        // Current user
        // List SSH keys
        // Single SSH key
        // Delete SSH key

        private void NotifyException(Exception exception)
        {
            if (this.errorAction != null)
            {
                this.errorAction(exception);
            }
        }

    }
}
