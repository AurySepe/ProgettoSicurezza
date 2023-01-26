using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts.EventHandler
{
    [Serializable]
    public class RisultatoEvent
    {
        [JsonProperty("value")] 
        public int Value { get; set; }
    }
}