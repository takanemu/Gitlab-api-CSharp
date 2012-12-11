using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gitlab
{
    internal class ResultMessage
    {
        public string Message { get; set; }

        internal static ResultMessage MessageFactory(string json)
        {
            var message = Codeplex.Data.DynamicJson.Parse(json, System.Text.UTF8Encoding.UTF8);

            ResultMessage result = new ResultMessage
            {
                Message = message.message,
            };
            return result;
        }
    }
}
