using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab.Api.Library
{
    public class Owner
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
