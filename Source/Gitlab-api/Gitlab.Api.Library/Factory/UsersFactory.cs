
namespace Gitlab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal class UsersFactory
    {
        internal static User Create(string json)
        {
            var user = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            DateTime date = new DateTime();
            DateTime.TryParse(user.created_at, out date);

            int theme_id;
            int.TryParse(((double)user.theme_id).ToString(), out theme_id);

            User result = new User
            {
                Id = ((double)user.id).ToString(),
                Email = user.email,
                Name = user.name,
                Blocked = user.blocked,
                CreatedAt = date,
                Bio = user.bio,
                Skype = user.skype,
                Linkedin = user.linkedin,
                Twitter = user.twitter,
                DarkScheme = user.dark_scheme,
                ThemeId = theme_id,
            };
            return result;
        }

        internal static List<User> Creates(string json)
        {
            List<User> list = new List<User>();

            var users = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            foreach (var item in users)
            {
                DateTime date = new DateTime();
                DateTime.TryParse(item.created_at, out date);

                int theme_id;
                int.TryParse(((double)item.theme_id).ToString(), out theme_id);

                User user = new User
                {
                    Id = ((double)item.id).ToString(),
                    Email = item.email,
                    Name = item.name,
                    Blocked = item.blocked,
                    CreatedAt = date,
                    Bio = item.bio,
                    Skype = item.skype,
                    Linkedin = item.linkedin,
                    Twitter = item.twitter,
                    DarkScheme = item.dark_scheme,
                    ThemeId = theme_id,
                };

                list.Add(user);
            }
            return list;
        }
    }
}
