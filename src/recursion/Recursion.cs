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
    }
}
