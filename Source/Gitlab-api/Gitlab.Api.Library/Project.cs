using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab.Api.Library
{
    public class Project
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string DefaultBranch { get; set; }
        public bool Private { get; set; }
        public bool IssuesEnabled { get; set; }
        public bool MergeRequestsEnabled { get; set; }
        public bool WallEnabled { get; set; }
        public bool WikiEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public Owner Owner { get; set; }
    }
}
