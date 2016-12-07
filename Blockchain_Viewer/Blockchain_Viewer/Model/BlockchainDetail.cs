using Newtonsoft.Json;

namespace Blockchain_Viewer.Model
{
    public class BlockchainDetail
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "buy")]
        public string Buy { get; set; }
        [JsonProperty(PropertyName = "sell")]
        public string Sell { get; set; }
        [JsonProperty(PropertyName = "last")]
        public string Last { get; set; }

        public override string ToString()
        {
            return Symbol + " : " + Buy + " / " + Sell + " / " + Last;
        }
    }
}
