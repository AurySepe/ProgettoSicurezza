using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts
{
    [Serializable]
    public class Request
    {
        [JsonProperty("RequestId")]
        public uint RequestId { get; set; }
        
        [JsonProperty("Uri")]
        public String Uri { get; set; }
        
        [JsonProperty("Data")]
        public string Data { get; set; }
    }
}