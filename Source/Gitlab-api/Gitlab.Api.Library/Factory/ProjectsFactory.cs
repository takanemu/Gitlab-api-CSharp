
namespace Gitlab
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// プロジェクトファクトリー
    /// </summary>
    internal class ProjectsFactory
    {
        /// <summary>
        /// プロジェクトクラスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>プロジェクトクラス</returns>
        internal static Project Create(string json)
        {
            return JsonConvert.DeserializeObject<Project>(json);
        }

        /// <summary>
        /// プロジェクトクラスリストの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>プロジェクトリスト</returns>
        internal static List<Project> Creates(string json)
        {
            return JsonConvert.DeserializeObject<List<Project>>(json);
        }
    }
}
