
namespace Gitlab
{
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
            DateTime date = new DateTime();
            bool result = DateTime.TryParse(json.created_at, out date);

            Owner owner = new Owner
            {
                Id = ((double)json.id).ToString(),
                Email = json.email,
                Name = json.name,
                Blocked = json.blocked,
                CreatedAt = date,
            };
            return owner;
        }
    }
}
