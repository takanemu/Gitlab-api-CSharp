using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab.Api.Library
{
    public class ProjectsFactory
    {
        public static List<Project> Create(string json)
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
