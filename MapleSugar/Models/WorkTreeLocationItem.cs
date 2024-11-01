namespace MapleSugar.Models
{
    public class WorkTreeLocationItem
    {
        public int WorkSector { get; set; }

        public int WorkTreeNumber { get; set; }

        public int WorkSubTreeNumber { get; set; }

        public string ?WorkTreeSubLetter { get; set; }

        public string ?WorkTreeLocation { get; set; }

        public double WorkCircumference { get; set; }

        public int WorkReprintTag { get; set; }

        public int WorkTapTube { get; set; }

        public double WorkTreeCombineWith { get; set; }

        public string ?WorkComments { get; set; }

        public double WorkGridX { get; set; }

        public double WorkGridY { get; set; }

        public int WorkTapped { get; set; }

        public double WorkLatSec { get; set; }

        public double WorkLonSec { get; set; }

        public string ?WorkContainer { get; set; }
    }
}
