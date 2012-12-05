
namespace Gitlab.Api.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// セッションクラス
    /// </summary>
    public class Session
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PrivateToken { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
