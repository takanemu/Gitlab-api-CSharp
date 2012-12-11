
namespace Gitlab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ProjectTeamMemberFactory
    {
        internal static List<ProjectTeamMember> Creates(string json)
        {
            List<ProjectTeamMember> list = new List<ProjectTeamMember>();

            var members = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            foreach (var member in members)
            {
                DateTime date = new DateTime();
                DateTime.TryParse(member.created_at, out date);

                ProjectTeamMember teamMember = new ProjectTeamMember
                {
                    Id = ((double)member.id).ToString(),
                    Email = member.email,
                    Name = member.name,
                    Blocked = member.blocked,
                    CreatedAt = date,
                    AccessLevel = (int)member.access_level,
                };

                list.Add(teamMember);
            }
            return list;
        }
    }
}
