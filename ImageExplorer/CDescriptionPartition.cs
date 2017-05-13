using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageExplorer
{
    //--------------------------------------------------------------------------------------
    // class CDescriptionPartition
    //--------------------------------------------------------------------------------------
    public class CDescriptionPartition
    {
        public int TopWeight{get; set;}
        public int BottomWeight { get; set; }
        public double AverageTop { get; set; }
        public double AverageBottom { get; set; }
        public double TopDevision { get; set; }
        public double BottomDevision { get; set; }
        //--------------------------------------------------------------------------------------
        public CDescriptionPartition(int pTopWeight, int pBottomWeight,
            double pAverageTop, double pAverageBottom,
            double pTopDevision, double pBottomDevision)
        {
            TopWeight = pTopWeight;
            BottomWeight = pBottomWeight;
            AverageTop = pAverageTop;
            AverageBottom = pAverageBottom;
            TopDevision = pTopDevision;
            BottomDevision = pBottomDevision;
        }
    }
    //--------------------------------------------------------------------------------------
}
