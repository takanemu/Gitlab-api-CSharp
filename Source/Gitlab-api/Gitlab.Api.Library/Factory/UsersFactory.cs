
namespace Gitlab
{
    using Newtonsoft.Json;
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
        /// ユーザークラスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ユーザークラス</returns>
        internal static User Create(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }

        /// <summary>
        /// ユーザークラスリストの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ユーザークラス</returns>
        internal static List<User> Creates(string json)
        {
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
    }
}
