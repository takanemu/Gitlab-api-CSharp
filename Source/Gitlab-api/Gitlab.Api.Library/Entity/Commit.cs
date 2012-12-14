using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab
{
    public class Commit
    {
        public string Id { get; set; }
        public List<Parents> Parents { get; set; }
        public string Tree { get; set; }
        public string Message { get; set; }
        public Author Author { get; set; }
    }
}
