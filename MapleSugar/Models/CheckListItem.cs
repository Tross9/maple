using Newtonsoft.Json;

namespace MapleSugar.Models
{
    public class CheckListItem
    {
        [JsonProperty("SortField")]
        public int SortField { get; set; }

        [JsonProperty("Sector")]
        public int Sector { get; set; }

        [JsonProperty("TreeNumber")]
        public int TreeNumber { get; set; }

        [JsonProperty("SubTreeNumber")]
        public int SubTreeNumber { get; set; }

        [JsonProperty("TreeSubLetter")]
        public string ?TreeSubLetter { get; set; }

        [JsonProperty("TreeLocation")]
        public string ?TreeLocation { get; set; }

        [JsonProperty("Circumference")]
        public double Circumference { get; set; }

        [JsonProperty("TreeReprintTag")]
        public int TreeReprintTag { get; set; }

        [JsonProperty("TreeTapTube")]
        public int TreeTapTube { get; set; }

        [JsonProperty("TreeCombineWith")]
        public double TreeCombineWith { get; set; }

        [JsonProperty("Comments")]
        public string ?Comments { get; set; }

        [JsonProperty("GridX")]
        public double GridX { get; set; }

        [JsonProperty("GridY")]
        public double GridY { get; set; }

        [JsonProperty("Tapped")]
        public int Tapped { get; set; }

        [JsonProperty("LatSec")]
        public double LatSec { get; set; }

        [JsonProperty("LonSec")]
        public double LonSec { get; set; }

        [JsonProperty("Container")]
        public string ?Container { get; set; }

    }
}

