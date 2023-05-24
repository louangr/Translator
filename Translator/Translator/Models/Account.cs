using System.Runtime.Serialization;

namespace Translator.Models
{
    [DataContract]
    public class Account
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "apiKey")]
        public string ApiKey { get; set; }
    }
}