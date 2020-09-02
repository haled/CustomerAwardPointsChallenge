using System;

namespace CustomerPointsCalculator
{
    public static class PointsCalculator
    {
        public static int CalculatePoints(Transaction txn)
        {
            var calculatedPoints = 0;

            if(txn != null && txn.PurchaseAmount > 0.0m)
            {
                var truncatedAmount = (int) Math.Truncate(txn.PurchaseAmount);
                var twoPointEligibleAmount = 0;
                var onePointEligibleAmount = 0;

                twoPointEligibleAmount = IsGreaterThanVal(truncatedAmount,100) ? (truncatedAmount - 100) : 0;
                onePointEligibleAmount = IsGreaterThanVal(truncatedAmount,100) ? 50 : IsGreaterThanVal(truncatedAmount,50) ? truncatedAmount - 50 : 0;
                
                calculatedPoints = (2 * twoPointEligibleAmount) + onePointEligibleAmount;
            }
            
            return calculatedPoints;
        }

        public static bool IsGreaterThanVal(int testValue, int val)
        {
            return (testValue - val) > 0;
        }

        public static int CalculatePointsOrig(Transaction txn)
        {
            var calculatedPoints = 0;

            if(txn != null && txn.PurchaseAmount > 0.0m)
            {
                var truncatedAmount = (int) Math.Truncate(txn.PurchaseAmount);
                var twoPointEligibleAmount = 0;
                var onePointEligibleAmount = 0;

                if(txn.PurchaseAmount > 100.0m)
                {
                    twoPointEligibleAmount = truncatedAmount - 100;
                    onePointEligibleAmount = truncatedAmount - twoPointEligibleAmount - 50;
                }
                else if(txn.PurchaseAmount > 50.0m)
                {
                    onePointEligibleAmount = truncatedAmount - 50;
                }
                
                calculatedPoints = (2 * twoPointEligibleAmount) + onePointEligibleAmount;
            }
            
            return calculatedPoints;
        }
    }
}
