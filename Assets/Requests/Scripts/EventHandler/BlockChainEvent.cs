using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts.EventHandler
{
    [Serializable]
    public class BlockChainEvent
    {
        
        [JsonProperty("EventName")] 
        public string Name { get; set; }
        
        [JsonProperty("ReturnValue")]
        public string ReturnValue { get; set; }
        
    }
}