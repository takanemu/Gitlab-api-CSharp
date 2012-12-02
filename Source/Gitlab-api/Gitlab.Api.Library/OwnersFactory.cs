using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab.Api.Library
{
    public class OwnersFactory
    {
        public static Owner Create(dynamic json)
        {
            DateTime date = new DateTime();
            bool result = DateTime.TryParse(json.created_at, out date);

            Owner owner = new Owner
            {
                Id = ((double)json.id).ToString(),
                Email = json.email,
                Name = json.name,
                Blocked = json.blocked,
                CreatedAt = date,
            };
            return owner;
        }
    }
}
