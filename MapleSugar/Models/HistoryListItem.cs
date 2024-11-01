using Newtonsoft.Json;

namespace MapleSugar.Models
{
    public class HistoryListItem
    {
        [JsonProperty("Year")]
        public string ?CollectionYear { get; set; }

        [JsonProperty("Amountc")]
        public float Amountc { get; set; }

        [JsonProperty("Amountb")]
        public float Amountb { get; set; }

        [JsonProperty("Amountf")]
        public float Amountf { get; set; }

        [JsonProperty("Amountl")]
        public float Amountl { get; set; }

        [JsonProperty("Unit")]
        public string ?Unit { get; set; }

    }
}
