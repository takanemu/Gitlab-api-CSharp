
namespace Gitlab
{
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
        /// インスタンスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>インスタンス</returns>
        private static Project CreateInstance(dynamic json)
        {
            DateTime date = new DateTime();
            DateTime.TryParse(json.created_at, out date);

            Project result = new Project
            {
                Id = ((double)json.id).ToString(),
                Code = json.code,
                Name = json.name,
                Description = json.description,
                Path = json.path,
                DefaultBranch = json.default_branch,
                Private = json["private"],
                IssuesEnabled = json.issues_enabled,
                MergeRequestsEnabled = json.merge_requests_enabled,
                WallEnabled = json.wall_enabled,
                WikiEnabled = json.wiki_enabled,
                CreatedAt = date,
                Owner = OwnersFactory.Create(json.owner),
            };
            return result;
        }

        /// <summary>
        /// プロジェクトクラスの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>プロジェクトクラス</returns>
        internal static Project Create(string json)
        {
            var project = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            return ProjectsFactory.CreateInstance(project);
        }

        /// <summary>
        /// プロジェクトクラスリストの生成
        /// </summary>
        /// <param name="json">JSONデータ</param>
        /// <returns>プロジェクトリスト</returns>
        internal static List<Project> Creates(string json)
        {
            List<Project> list = new List<Project>();
            var projects = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            foreach (var project in projects)
            {
                list.Add(ProjectsFactory.CreateInstance(project));
            }
            return list;
        }
    }
}
