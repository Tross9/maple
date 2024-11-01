namespace MapleSugar.Models
{
    public class WorkCheckListItem
    {
        public int SortField { get; set; }
        public int Sector { get; set; }

        public int TreeNumber { get; set; }

        public int SubTreeNumber { get; set; }

        public string ?TreeSubLetter { get; set; }

        public string ?TreeLocation { get; set; }

        public double Circumference { get; set; }

        public int TreeReprintTag { get; set; }

        public int TreeTapTube { get; set; }

        public double TreeCombineWith { get; set; }

        public string ?Comments { get; set; }

        public double GridX { get; set; }

        public double Gridy { get; set; }

        public int tapped { get; set; }

        public double LatSec { get; set; }

        public double LonSec { get; set; }

        public string ?Container { get; set; }

    }
}
