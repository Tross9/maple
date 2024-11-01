using System;

namespace MapleSugar.Models
{
    public class WorkCollectedItem
    {
        // public DateTime CollectedDate { get; set; }

        public int TreeNumber { get; set; }

        public int SubTreeNumber { get; set; }

        public double CollectedAmount { get; set; }

        public double TotalCollected
        {
            get => CollectedAmount + TotalCollected;
        }

    }
}
