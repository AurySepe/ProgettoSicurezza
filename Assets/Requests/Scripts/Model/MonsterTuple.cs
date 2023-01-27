using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts.Model
{
    [Serializable]
    public class MonsterTuple
    {

        [JsonProperty("Nome")]
        public string Nome { get; set; }
        
        [JsonProperty("ImageBase64")]
        public string ImageBase64 { get; set; }
        
    }
}