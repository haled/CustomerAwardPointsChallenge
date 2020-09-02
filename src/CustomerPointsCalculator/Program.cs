using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPointsCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // set up test data
            var transactions = new List<Transaction>();
            for(int i = 9; i <= 200; i++)
            {
                var txn = new Transaction {
                    PurchaseDate = DateTime.Now,
                    PurchaseAmount = i * 5.0m
                };
                transactions.Add(txn);
            }

            // aggregate the points
            var totalPoints = transactions.Sum(txn => PointsCalculator.CalculatePoints(txn));

            foreach(var t in transactions)
            {
                Console.WriteLine("{0} -> ${1}", t.PurchaseDate, t.PurchaseAmount);
            }
            Console.WriteLine("The total points = {0}", totalPoints);
        }
    }
}
