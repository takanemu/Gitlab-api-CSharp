
namespace Gitlab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// プロジェクトチームメンバークラス
    /// </summary>
    public class ProjectTeamMember
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool Blocked { get; set; }
        public DateTime Created_at { get; set; }
        public int Access_level { get; set; }
    }
}
