using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts
{
    [Serializable]
    public class Response
    {
        [JsonProperty("RequestId")]
        public uint RequestId { get; set; }
        
        [JsonProperty("Ok")]
        public bool Ok { get; set; }
        
        [JsonProperty("Result")]
        public string Result { get; set; }

    }
}