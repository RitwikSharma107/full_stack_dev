using System;
using CS_Assignment2;

Console.WriteLine("### Practice Arrays ###");
Practice_Arrays pa = new Practice_Arrays();

Console.WriteLine("\nQ1");
int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
pa.q1(arr);

Console.WriteLine("\nQ2");
pa.q2();

Console.WriteLine("\nQ2");
pa.q2();

Console.WriteLine("\nQ3");
pa.q3();

Console.WriteLine("\nQ4");
Console.WriteLine("Enter the array of integers (space separated):");
int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
Console.WriteLine("Enter the number of rotations:");
int k = int.Parse(Console.ReadLine());
pa.q4(array,k);

Console.WriteLine("\nQ5");
int[] arr1 = {2,1,1,2,3,3,2,2,2,1,2,2,2};
pa.q5(arr1);

Console.WriteLine("\nQ7");
int[] arr2 = {1,5,5,5,2,3,4,4,5 };
pa.q7(arr2);

Console.WriteLine("### Practice Strings ###");
Practice_Strings ps = new Practice_Strings();

Console.WriteLine("\nQ1");
Console.WriteLine("Enter String: ");
string str = Console.ReadLine();
ps.q1(str);

Console.WriteLine("\nQ2");
Console.WriteLine("Enter String: ");
string str1 = Console.ReadLine();
ps.q2(str1);

Console.WriteLine("\nQ3");
Console.WriteLine("Enter text:");
string text = Console.ReadLine();
ps.q3(text);

Console.WriteLine("\nQ4");
Console.WriteLine("Enter URL:");
string url = Console.ReadLine();
ps.q4(url);