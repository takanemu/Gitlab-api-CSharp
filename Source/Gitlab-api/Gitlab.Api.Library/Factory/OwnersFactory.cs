
namespace Gitlab
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 所有者ファクトリークラス
    /// </summary>
    internal class OwnersFactory
    {
        /// <summary>
        /// 所有者クラス生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>所有者クラス</returns>
        internal static Owner Create(dynamic json)
        {
            return JsonConvert.DeserializeObject<Owner>(json);
        }
    }
}
