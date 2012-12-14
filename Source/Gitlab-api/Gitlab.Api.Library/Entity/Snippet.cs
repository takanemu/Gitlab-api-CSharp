using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab
{
    /// <summary>
    /// スニペットクラス
    /// </summary>
    public class Snippet
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public Author Author { get; set; }
        public DateTime Expires_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Created_at { get; set; }
    }
}
