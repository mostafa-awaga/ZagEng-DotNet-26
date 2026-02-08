using System;
namespace TaskOne
{
    class Program
    {
        //Question 3
        class Result
        {
            public List<int> EvenNum = new List<int>();
            public List<int> OddNum = new List<int>();
            public List<int> PrimeNum = new List<int>();
        }

        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        static bool IsPrime(int n)
        { 
            if (n < 2) return false;

            for (int i = 2; i < n; i++)
            {
                if(n % i == 0) return false;
            }
            return true;
        }

        class Classifier
        {
            public Result Classify(List<int> numbers)
            { 
                Result result = new Result();
                foreach (int n in numbers)
                {
                    if (n % 2 == 0)
                    {
                        result.EvenNum.Add(n);
                    }
                    else
                    {
                        result.OddNum.Add(n);
                    }
                    if (IsPrime(n))
                    {
                        result.PrimeNum.Add(n);
                    }
                }
                return result;
            }
        }



        static void Main(string[] args)
        {
            List<int> numbers = new List<int>
            { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Classifier C = new Classifier();
            Result r = C.Classify(numbers);

            Console.Write("Even: ");
            foreach (int n in r.EvenNum)
            {
                Console.Write(n + " ");
            }

            Console.Write("\nOdd: ");
            foreach (int n in r.OddNum)
            {
                Console.Write(n + " ");
            }

            Console.Write("\nPrime: ");
            foreach (int n in r.PrimeNum)
            {
                Console.Write(n + " ");

            }
        }
    }
}