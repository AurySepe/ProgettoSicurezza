using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts.EventHandler
{
    [Serializable]
    public class PropostaScambio
    {

        [JsonProperty("id1")]
        public int mostroProposto { get; set; }
        
        [JsonProperty("id2")]
        public int mostroRichiesto { get; set; }
        
    }
}