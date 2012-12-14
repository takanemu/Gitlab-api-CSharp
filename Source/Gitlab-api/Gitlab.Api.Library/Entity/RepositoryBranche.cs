using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryBranche
    {
        public string Name { get; set; }
        public List<Commit> Commit { get; set; }
        public Committer Committer { get; set; }
        public DateTime Authored_date { get; set; }
        public DateTime Committed_date { get; set; }
    }
}
