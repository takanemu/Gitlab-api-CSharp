using System.Runtime.Serialization;

namespace Gitlab.Api.Library
{
    [DataContract]
    public class Projects
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}
