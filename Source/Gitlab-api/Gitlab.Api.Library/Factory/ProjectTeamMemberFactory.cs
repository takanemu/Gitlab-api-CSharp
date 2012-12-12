
namespace Gitlab
{
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
        /// インスタンスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>インスタンス</returns>
        private static ProjectTeamMember CreateInstance(dynamic json)
        {
            DateTime date = new DateTime();
            DateTime.TryParse(json.created_at, out date);

            ProjectTeamMember result = new ProjectTeamMember
            {
                Id = ((double)json.id).ToString(),
                Email = json.email,
                Name = json.name,
                Blocked = json.blocked,
                CreatedAt = date,
                AccessLevel = (int)json.access_level,
            };
            return result;
        }

        /// <summary>
        /// ロジェクトチームメンバークラスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ロジェクトチームメンバークラス</returns>
        internal static ProjectTeamMember Create(string json)
        {
            var user = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            return ProjectTeamMemberFactory.CreateInstance(user);
        }
        
        /// <summary>
        /// ロジェクトチームメンバークラスリストの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>ロジェクトチームメンバークラスリスト</returns>
        internal static List<ProjectTeamMember> Creates(string json)
        {
            List<ProjectTeamMember> list = new List<ProjectTeamMember>();

            var members = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            foreach (var member in members)
            {
                list.Add(ProjectTeamMemberFactory.CreateInstance(member));
            }
            return list;
        }
    }
}
