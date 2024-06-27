namespace CS_Assignment3;

public class Working_with_methods
{
    public void q1()
    {
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);
    }
    private int[] GenerateNumbers()
    {
        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arr[i] = i + 1;
        }
        return arr;
    }

    private int[] Reverse(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n / 2; i++)
        {
            (arr[i], arr[n - i - 1]) = (arr[n - i - 1], arr[i]);
        }
        return arr;
    }

    private void PrintNumbers(int[] arr)
    {
        Console.Write("Revered array: ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
    }
    
    public void q2()
    {
        Console.Write("Print Fibonacci Sequence: ");
        for (int i = 1; i <= 10; i++)
        {
            Console.Write(Fibonacci(i)+" ");
        }
    }

    private int Fibonacci(int n)
    {
        if (n == 1 || n == 2)
            return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}