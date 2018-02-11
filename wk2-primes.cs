/*
 * This is a fun programme that tells you what primes 
 * the number entered is a product of.
 */


using System;
using System.Collections.Generic;
namespace ProjectOfPrime
{
    class Program
    {
        // method to check if a number is a prime 
        static bool isPrime(int number)
        {
            bool state = false;
            int numberOfDivisors = 0;
            for (int i = 1; i <= number; i++)
            {
                if ((number % i) == 0)
                {
                    numberOfDivisors++;
                }
            }
            if ((numberOfDivisors == 2))
            {
                state = true;
            }
            return state;
        }
        
        // method to return list of prime factors
        static List<int> highestPrimeFactor(int number)
        {
            List<int> primeFactors = new List<int>();
            List<int> primeFactorsDivisible = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (isPrime(i) && (i != number))
                {
                    primeFactors.Add(i);
                }

            }
            // now lets check if those prime factors are divisible
            for (int i = 0; i < primeFactors.Count; i++)
            {
                if (((number % primeFactors[i]) == 0) && (i != number))
                {
                    // nice to debug -- Console.WriteLine(number + " / " + primeFactors[i]);
                    primeFactorsDivisible.Add(primeFactors[i]);
                }
            }
            // add our remainder as that's also a factor
            int remainder = number;
            for (int i = 0; i < primeFactorsDivisible.Count; i++)
            {
                remainder = remainder / primeFactorsDivisible[i];
            }
            
            primeFactorsDivisible.Add(remainder);
            Console.WriteLine();
            // return thr list
            return primeFactorsDivisible;
        }


        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Hello user, please enter a number");
                List<int> primes = new List<int>();


                // Handle Prime Entry
                int thisNumber = int.Parse(Console.ReadLine());
                if (isPrime(thisNumber))
                {
                    Console.WriteLine("Prime Number so factors are: " + thisNumber);
                }
                else
                {
                    List<int> factors = highestPrimeFactor(thisNumber);
                    int factorCount = factors.Count;
                    int factorCounter = 0;
                    Console.WriteLine("Factors of " + thisNumber + " are: ");
                    for (int i = 0; i < factors.Count; i++)
                    {
                        factorCounter++;
                        if (factorCounter == (factorCount))
                        {
                            Console.Write(factors[i]);
                        }
                        else
                        {
                            Console.Write(factors[i] + " x ");
                        }
                    }
                }
            }


            catch

            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("You've done something bad. It was probably trying to break my code by sticking letters where a number should be);
            }

            Console.ReadKey();
        }
    }
}