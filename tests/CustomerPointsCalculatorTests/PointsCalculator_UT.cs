using System;
using Xunit;
using CustomerPointsCalculator;

namespace CustomerPointsCalculatorTests
{
    public class PointsCalculator_UT
    {
        [Fact]
        public void CalculatePointsTakesATransactionAndReturnsAnInt()
        {
            var testTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = 0.0m
            };

            var result = PointsCalculator.CalculatePoints(testTransaction);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculatePointsReturnsZeroIfPurchaseAmountIsNotPositive()
        {
            var negativeTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = -3.0m
            };

            var negativeResult = PointsCalculator.CalculatePoints(negativeTransaction);

            Assert.Equal(0, negativeResult);

            var zeroTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = 0.0m
            };

            var zeroResult = PointsCalculator.CalculatePoints(zeroTransaction);

            Assert.Equal(0, zeroResult);
        }

        [Fact]
        public void CalculatePointsReturnsZeroForPurchasesUnderFiftyDollars()
        {
            var testTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = 49.99m
            };

            var result = PointsCalculator.CalculatePoints(testTransaction);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculatePointsReturnsOnePointForEveryDollarOverFiftyDollars()
        {
            var testTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = 60.50m
            };

            var result = PointsCalculator.CalculatePoints(testTransaction);

            Assert.Equal(10, result);
        }

        [Fact]
        public void CalculatePointsReturnsTwoPointsForEveryDollarOverOneHundred()
        {
            var testTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = 120.50m
            };

            var result = PointsCalculator.CalculatePoints(testTransaction);

            Assert.Equal(90, result);
        }

        [Fact]
        public void CalculatePointsReturnsNoPointsForExactlyFiftyDollars()
        {
            var testTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = 50.0m
            };

            var result = PointsCalculator.CalculatePoints(testTransaction);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculatePointsReturnsFiftyPointsForExactlyOneHundredDollars()
        {
            var testTransaction = new Transaction {
                PurchaseDate = DateTime.Now,
                PurchaseAmount = 100.0m
            };

            var result = PointsCalculator.CalculatePoints(testTransaction);

            Assert.Equal(50, result);
        }

        [Fact]
        public void IsGreaterThanValReturnsTrueCorrectly()
        {
            var result = PointsCalculator.IsGreaterThanVal(2,1);
            Assert.True(result);
        }

        [Fact]
        public void IsGreaterThanValReturnsFalseCorrectly()
        {
            var result = PointsCalculator.IsGreaterThanVal(1,2);
            Assert.False(result);
        }

        [Fact]
        public void IsGreaterThanValReturnsFalseForSameValues()
        {
            var result = PointsCalculator.IsGreaterThanVal(2,2);
            Assert.False(result);
        }
    }
}
