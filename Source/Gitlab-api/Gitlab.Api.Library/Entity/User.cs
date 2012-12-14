
namespace Gitlab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ユーザークラス
    /// </summary>
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool Blocked { get; set; }
        public DateTime Created_at { get; set; }
        public string Bio { get; set; }
        public string Skype { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public bool DarkScheme { get; set; }
        public int ThemeId { get; set; }
    }
}
