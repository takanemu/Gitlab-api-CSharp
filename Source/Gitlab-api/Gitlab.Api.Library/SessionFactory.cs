using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab.Api.Library
{
    internal class SessionFactory
    {
        internal static Session Create(string json)
        {
            var session = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            DateTime date = new DateTime();
            DateTime.TryParse(session.created_at, out date);

            Session result = new Session
            {
                Id = ((double)session.id).ToString(),
                Email = session.email,
                Name = session.name,
                Blocked = session.blocked,
                PrivateToken = session.private_token,
                CreatedAt = date,
            };
            return result;
        }
    }
}
