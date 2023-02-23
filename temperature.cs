using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
     {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');
        int[] intInputs = ConverArrayToInt(inputs);
        SortArray(intInputs);
        if (n < 10000 && n > 0)
        {
            var negatives = NegativeNumbers(intInputs);
            var positives = PositiveNumbers(intInputs);

            SortArray(negatives);
            SortArray(positives);
            int minPos = 0;
            int maxNeg = 0;
            maxNeg = negatives.Length > 0 ? GetLargestElementUsingFor(negatives) : 0;
            minPos = positives.Length > 0 ? GetSmallestElementFor(positives) : 0;

            if (positives.Length <= 0)
            {
                Console.WriteLine(maxNeg);
            }
            else if (negatives.Length <= 0)
            {
                Console.WriteLine(minPos);
            }
            else
            {

                if (Math.Abs(maxNeg) > minPos)
                {
                    Console.WriteLine(minPos);
                }
                else if(Math.Abs(maxNeg) == minPos)
                {
                    Console.WriteLine(minPos);
                }
                else { Console.WriteLine(maxNeg); }
            }
           
        }
        else
        {
            Console.WriteLine(0);
        }
        

        static int[] ConverArrayToInt(string[] arr)
        {
            try
            {
                int[] intArray = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    intArray[i] = int.Parse(arr[i]);
                }
                return intArray;
            }
            catch
            {
                return new int[0];
            }
        }

        static void SortArray(int[] array)
        {
            var temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if ((array[i]) >= (array[j])) 
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

         static int[] NegativeNumbers(int[] ints)
    {
        int negnumbers = 0;
        foreach (int num in ints)
        {
            if (num < 0) { negnumbers++; }
        }

        int[] negativeIntsArray = new int[negnumbers];

        for (int i = 0; i < negnumbers; i++)
        {
            negativeIntsArray[i] = ints[i];
        }

        return negativeIntsArray;
    }

    static int[] PositiveNumbers(int[] ints)
    {
        int posNumbers = 0;
        foreach (int num in ints)
        {
            if (num > 0) { posNumbers++; }
        }

        int[] positiveIntsArray = new int[posNumbers];

        for (int i = 0; i < posNumbers; i++)
        {
            positiveIntsArray[i] = ints[i + (ints.Length - posNumbers)];
        }

        return positiveIntsArray;
    }
    static int GetLargestElementUsingFor(int[] sourceArray)
    {
        int maxElement = sourceArray[0];
        for (int index = 1; index < sourceArray.Length; index++)
        {
            if (sourceArray[index] > maxElement)
                maxElement = sourceArray[index];
        }

        return maxElement;
    }

    static int GetSmallestElementFor(int[] sourceArray)
    {
        int minElement = sourceArray[0];
        for(int i = 1; i < sourceArray.Length; i++) 
        {
            if (sourceArray[i] < minElement) 
                minElement = sourceArray[i];
        }
        return minElement;
    }
        
    }
}
