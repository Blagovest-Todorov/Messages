using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine() ////   9992 562 8933 // 
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();  //create list of nums /

            List<int> sumDigitsNums = new List<int>(nums.Count);  /// SumDigits /
           // List<string> symbols = new List<string>();

            List<char> text = Console.ReadLine()
                        .ToList();

            List<char> chars = new List<char>();
            // string text = Console.ReadLine();

            for (int i = 0; i < nums.Count; i++)
            {
                int currElement = nums[i]; // take currcnt element and calculate its digits sum 
                int currElNum = currElement;

                int index = SumDigits(currElNum); // sumDigits == Index 

                sumDigitsNums.Add(index); // We fill the  List with sum of each numbers

                if (index < text.Count)
                {
                    char currSymbol = text[index];
                    chars.Add(currSymbol);
                    text.RemoveAt(index);
                }
                else if (index == text.Count)  /// here only if it is not ok .//it wants if else
                {
                    index = 0;
                    char currSymbol = text[index];
                    chars.Add(currSymbol);
                    text.RemoveAt(index);
                }
                else // (index > text.Count)  // idx = 10 ,  Hello / 0 1 2 3 4 / -> 5 6 4 8 9 10
                {                    
                    index = index % 28;   // Length =28 , 28 symbols // index = index - text.Count;
                    char currSymbol = text[index];  // text.Length = 5 - > repeating t every 5 symbol/
                    chars.Add(currSymbol);
                    text.RemoveAt(index);
                }                
            }

            foreach (var item in chars)
            {
                Console.Write(item);
            }            
            
            static int SumDigits(int currElNum)
            {
                int sum = 0;

                while (currElNum > 0)      
                {
                    int currDigit = currElNum % 10;
                    sum += currDigit;
                    currElNum = currElNum / 10;
                }

                return sum;
            }
        }
    }
}
