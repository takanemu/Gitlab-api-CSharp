
namespace Gitlab
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// セッションクラスファクトリー
    /// </summary>
    internal class SessionFactory
    {
        /// <summary>
        /// セッションクラスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>セッションクラス</returns>
        internal static Session Create(string json)
        {
            return JsonConvert.DeserializeObject<Session>(json);
        }
    }
}
