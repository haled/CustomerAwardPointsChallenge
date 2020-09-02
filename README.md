# CustomerAwardPointsChallenge

## Stated Challenge
A retailer offers a rewards program to its customers, awarding points based on each recorded purchase.

A customer receives 2 points for every dollar spent over $100 in each transaction, plus 1 point for every dollar spent over $50 in each transaction

(e.g. a $120 purchase = 2x$20 + 1x$50 = 90 points).

Given a record of every transaction during a three month period, calculate the reward points earned for each customer per month and total.

* Make up a data set to best demonstrate your solution
* Check solution into GitHub

## Project Overview
This solution was written with .NET 3.1.300.

The files are laid out in this manner:

<pre>
  CustomerPointsCalculator.sln
  src
    |
    |- CustomerPointsCalculator
       |
       |- PointsCalculator.cs
       |- Transaction.cs
       |- Program.cs
       |- CustomerPointsCalculator.csproj
  tests
    |
    |- CustomerPointsCalculatorTests
       |
       |- PoinsCalculator_UT.cs
       |- CustomerPointsCalculatorTests.csproj
</pre>

## Design Thoughts

### Overall Solution Design
The "business logic" is captured in a data object, Transaction, and a static method in PointsCalculator. Many Object Oriented architects would argue that the points calculation should be a method on the Transaction object. In my experience, calculations like this tend to change with business needs, and having that calculation separated makes maintenance on the system easier. This design also allows the system to migrate into a microservices architecture when necessary.

Traditional Object Oriented design would also have pushed me to implement an interface for the PointsCalculator class. Since I took more of a Functional Programming design approach, I did not create an interface (static classes can't implement interfaces). If a signature for the CalculatePoints method is needed for compile-time checking, a delegate can be created to define the function.

### PointsCalculator
There are two implementation methods in PointsCalculator. The method named "CalculatePointsOrig" was my original implementation as I created the solution with TDD.  The current CalculatePoints method is the refactored implementation to eliminate the if blocks. You can rename the methods and run the test suite and both implementations pass.

The refactored implementation may be able to take advantage of the pattern matching changes that are coming out in C# 9. I didn't explore that avenue in this solution.