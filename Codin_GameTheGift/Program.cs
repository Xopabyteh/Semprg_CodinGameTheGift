using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        var participantsCount = int.Parse(Console.ReadLine());
        var giftCost = int.Parse(Console.ReadLine());
        var budgets = new int[participantsCount];

        for (int i = 0; i < participantsCount; i++)
        {
            int budget = int.Parse(Console.ReadLine());
            budgets[i] = budget;
        }

        // Given a list of budgets, find a way to distribute the gift cost
        // such that the maximum budget given is minimized.
        // Algorithm:
        // 1. Sort the budgets in ascending order.
        // 2. Calculate the average budget.
        // 3. For each participant (budget)
        //      if his budget is less than average:
        //          he uses all his budget.
        //      else:
        //          he uses the average budget.
        //      add what he used to the total
        //      calculate the new average.
        //  4. If the total is less than the gift cost, print "IMPOSSIBLE" (done by subtracting the total from the gift cost)

        var cashGiven = new int[participantsCount];

        // Sort in ascending order
        Array.Sort(budgets);
        
        // Starting average
        var average = CalculateAverage(giftCost, participantsCount);

        for (int i = 0; i < participantsCount; i++)
        {
            var budget = budgets[i];
            int used;

            if (budget < average)
            {
                // Use all the budget
                used = budget;
            }
            else
            {
                // Use the average budget
                used = average;
            }

            giftCost -= used;
            cashGiven[i] = used;
            
            // Recalculate the average for the remaining participants (if there are any left)
            if(participantsCount - i - 1 == 0)
            {
                // No participants left, break the loop
                break;
            }
            average = CalculateAverage(giftCost, participantsCount - i - 1);
        }

        // Check if there is enough money to distribute
        if (giftCost > 0)
        {
            // -> Not enough money to distribute
            Console.WriteLine("IMPOSSIBLE");
            return;
        }

        // Print final result
        Array.Sort(cashGiven);
        for (int i = 0; i < participantsCount; i++)
        {
            Console.WriteLine(cashGiven[i]);
        }
    }

    static int CalculateAverage(int giftCost, int forParticipantCount)
    {
        return giftCost / forParticipantCount;
    }
}