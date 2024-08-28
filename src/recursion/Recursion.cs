using System.Numerics;

namespace recursion
{
    public class Recursion
    {
        public int SimpleRecursion(int n)
        {
            if (n == 0)
            {
                return -1;
            }
            else
            {
                return SimpleRecursion(n - 1);
            }
        }

        // Fibonacci methods

        public void FibonacciSequence(int n)
        {
            for (int i = 2; i < n; i++)
            {
                Console.WriteLine(Fibonacci(i));
            }
        }

        private int Fibonacci(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        // Factorial methods
        public void FactorialSequence(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Factorial(i));
            }
        }

        private BigInteger Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return (BigInteger) n * (BigInteger) Factorial(n - 1);
            }
        }
    }
}
