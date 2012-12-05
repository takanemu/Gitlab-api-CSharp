using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab.Api.Library
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
        public DateTime ExpiresAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
