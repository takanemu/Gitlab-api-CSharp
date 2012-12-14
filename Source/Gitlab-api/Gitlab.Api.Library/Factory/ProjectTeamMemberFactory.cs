
namespace Gitlab
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// プロジェクトチームメンバーファクトリー
    /// </summary>
    internal class ProjectTeamMemberFactory
    {
        /// <summary>
        /// ロジェクトチームメンバークラスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ロジェクトチームメンバークラス</returns>
        internal static ProjectTeamMember Create(string json)
        {
            return JsonConvert.DeserializeObject<ProjectTeamMember>(json);
        }
        
        /// <summary>
        /// ロジェクトチームメンバークラスリストの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ロジェクトチームメンバークラスリスト</returns>
        internal static List<ProjectTeamMember> Creates(string json)
        {
            return JsonConvert.DeserializeObject<List<ProjectTeamMember>>(json);
        }
    }
}
