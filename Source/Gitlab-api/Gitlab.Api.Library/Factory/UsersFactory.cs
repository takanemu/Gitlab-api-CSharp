
namespace Gitlab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ユーザークラスファクトリー
    /// </summary>
    internal class UsersFactory
    {
        /// <summary>
        /// インスタンスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>インスタンス</returns>
        private static User CreateInstance(dynamic json)
        {
            DateTime date = new DateTime();
            DateTime.TryParse(json.created_at, out date);

            int theme_id;
            int.TryParse(((double)json.theme_id).ToString(), out theme_id);

            User result = new User
            {
                Id = ((double)json.id).ToString(),
                Email = json.email,
                Name = json.name,
                Blocked = json.blocked,
                CreatedAt = date,
                Bio = json.bio,
                Skype = json.skype,
                Linkedin = json.linkedin,
                Twitter = json.twitter,
                DarkScheme = json.dark_scheme,
                ThemeId = theme_id,
            };
            return result;
        }

        /// <summary>
        /// ユーザークラスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ユーザークラス</returns>
        internal static User Create(string json)
        {
            var user = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            return UsersFactory.CreateInstance(user);
        }

        /// <summary>
        /// ユーザークラスリストの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ユーザークラス</returns>
        internal static List<User> Creates(string json)
        {
            List<User> list = new List<User>();

            var users = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            foreach (var user in users)
            {
                list.Add(UsersFactory.CreateInstance(user));
            }
            return list;
        }
    }
}
