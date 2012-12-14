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
    public class RepositoryCommit
    {
        public string Id { get; set; }
        public string Short_id { get; set; }
        public string Title { get; set; }
        public string Author_name { get; set; }
        public string Author_email { get; set; }
        public DateTime Created_at { get; set; }
    }
}
