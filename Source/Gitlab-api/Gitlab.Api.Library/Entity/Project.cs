using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab
{
    /// <summary>
    /// プロジェクトクラス
    /// </summary>
    public class Project
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Default_branch { get; set; }
        public bool Private { get; set; }
        public bool Issues_enabled { get; set; }
        public bool Merge_requests_enabled { get; set; }
        public bool Wall_enabled { get; set; }
        public bool Wiki_enabled { get; set; }
        public DateTime Created_at { get; set; }
        public Owner Owner { get; set; }
    }
}
