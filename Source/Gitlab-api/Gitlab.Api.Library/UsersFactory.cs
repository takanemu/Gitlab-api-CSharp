
namespace Gitlab.Api.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UsersFactory
    {
        public static List<User> Create(string json)
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
