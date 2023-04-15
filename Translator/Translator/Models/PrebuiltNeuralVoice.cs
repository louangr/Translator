using System.Runtime.Serialization;

namespace Translator.Models
{
    [DataContract]
    public class PrebuiltNeuralVoice
    {

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "voiceName")]
        public string VoiceName { get; set; }

        [DataMember(Name = "styleSupport")]
        public string StyleSupport { get; set; }
    }
}