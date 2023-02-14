using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts.EventHandler
{
    public class ScambioAccettato
    {
        [JsonProperty("id1")]
        public int mostroProposto { get; set; }
        
        [JsonProperty("id2")]
        public int mostroRichiesto { get; set; }

    }
}