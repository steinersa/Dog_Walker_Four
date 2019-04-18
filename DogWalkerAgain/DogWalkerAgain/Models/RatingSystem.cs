using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalkerAgain.Models
{
    public class RatingSystem
    {
        public double RatingNumberViewer(int RatingsSoFar, int NewRating)
        {
            double GeneralRateNumber = (RatingsSoFar + NewRating);

            double TotalRateNumber = (GeneralRateNumber / 2);

            return (TotalRateNumber);
        }
    }
}