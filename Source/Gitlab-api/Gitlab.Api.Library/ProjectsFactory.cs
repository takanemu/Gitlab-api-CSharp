using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab.Api.Library
{
    internal class ProjectsFactory
    {
        internal static Project Create(string json)
        {
            var project = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            DateTime date = new DateTime();
            DateTime.TryParse(project.created_at, out date);

            Project result = new Project
            {
                Id = ((double)project.id).ToString(),
                Code = project.code,
                Name = project.name,
                Description = project.description,
                Path = project.path,
                DefaultBranch = project.default_branch,
                Private = project["private"],
                IssuesEnabled = project.issues_enabled,
                MergeRequestsEnabled = project.merge_requests_enabled,
                WallEnabled = project.wall_enabled,
                WikiEnabled = project.wiki_enabled,
                CreatedAt = date,
                Owner = OwnersFactory.Create(project.owner),
            };
            return result;
        }

        internal static List<Project> Creates(string json)
        {
            List<Project> list = new List<Project>();
            var projects = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            foreach (var item in projects)
            {
                DateTime date = new DateTime();
                bool result = DateTime.TryParse(item.created_at, out date);

                Project project = new Project
                {
                    Id = ((double)item.id).ToString(),
                    Code = item.code,
                    Name = item.name,
                    Description = item.description,
                    Path = item.path,
                    DefaultBranch = item.default_branch,
                    Private = item["private"],
                    IssuesEnabled = item.issues_enabled,
                    MergeRequestsEnabled = item.merge_requests_enabled,
                    WallEnabled = item.wall_enabled,
                    WikiEnabled = item.wiki_enabled,
                    CreatedAt = date,
                    Owner = OwnersFactory.Create(item.owner),
                };
                
                list.Add(project);
            }
            return list;
        }
    }
}
