using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Scenes.TestScene.Scripts.Model
{
    [Serializable]
    public class TradeTuple
    {
        
        [JsonProperty("MonsterRequired")]
        public int MonsterRequired { get; set; }
        
        [JsonProperty("MonsterProposed")]
        public int MonsterProposed { get; set; }
        
    }
}