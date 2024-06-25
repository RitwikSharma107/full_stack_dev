namespace CS_Assignment2;

public class Practice_Arrays
{
    public int[] arr2 = new int[10];
    public void q1(int[] arr1)
    {
        int n = arr1.Length;
        for (int i = 0; i < n; i++)
        {
            arr2[i] = arr1[i];
        }
        Console.Write("Elements of Array 1: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("\nElements of Array 2: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr2[i] + " ");
        }   
    }

    public void q2()
    {
        List<string> items = new List<string>();
        while (true)
        {
            Console.WriteLine("Current List");
            foreach(string item in items)
            {
                Console.WriteLine(item);        
            }
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
            string val = Console.ReadLine();
            if (val.StartsWith("+"))
            {
                items.Add(val.Substring(2));
            }else if (val=="--")
            {
                items.Clear();
            }
            else if (val.StartsWith("-"))
            {
                items.Remove(val.Substring(2));
            }
            else
            {
                Console.WriteLine("Invalid Input");
                break;
            }
        }
    }

    public void q3()
    {
        static int[] FindPrimesInRange(int startNum, int endNum)
        {
            int[] arr = new int[endNum-startNum+1];
            int index = 0;
            for (int i = startNum; i <= endNum; i++)
            {
                bool isPrime = true;
                if (i <= 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
            
                }

                if (isPrime)
                    arr[index++] = i;
            }
            Array.Resize(ref arr, index);
            return arr;
        }
        
        Console.WriteLine("Get prime numbers from:");
        string number1=Console.ReadLine();
        int start = int.Parse(number1);
        Console.WriteLine("Get prime numbers to:");
        string number2=Console.ReadLine();
        int end = int.Parse(number2);
        int[] arr1 = FindPrimesInRange(start,end);
        Console.WriteLine($"Prime Numbers from {start} to {end}");
        for(int i=0;i<arr1.Length;i++)
            Console.WriteLine(arr1[i]);
    }

    public void q4(int[] array, int k)
    {
        static int[] RotateRight(int[] array, int r)
        {
            int n = array.Length;
            int[] rotated = new int[n];
            for (int i = 0; i < n; i++)
            {
                rotated[(i + r) % n] = array[i];
            }
            return rotated;
        }
        
        int n = array.Length;
        int[] sum = new int[n];
        for (int r = 1; r <= k; r++)
        {
            int[] rotated = RotateRight(array, r);
            Console.WriteLine($"rotated{r}[] = {string.Join(" ", rotated)}");
            for (int i = 0; i < n; i++)
            {
                sum[i] += rotated[i];
            }
        }
        Console.WriteLine("sum[] = " + string.Join(" ", sum));
    }

    public void q5(int[] arr)
    {
        int start=0,end=-1;
        int count=1;
        int maxArray=0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                count++;
                if (maxArray < count)
                {
                    maxArray = count;
                    end = i;
                }
            }
            else
            {
                start = i;
                count = 1;
            }
        }

        for (int i = end; i > end - maxArray; i--)
        {
            Console.Write(arr[i] + " ");
        }
    }

    public void q7(int[] arr)
    {
        int n=arr.Length;
        int m=0;
        int c = 1;
        int ele = 0;
        Array.Sort(arr);
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                c++;
                if (c > m)
                {
                    m = c;
                    ele = arr[i];
                }
            }
            else
            {
                c = 1;
            }
        }
        Console.WriteLine($"Element with maximum frequency {ele}");
    }
}