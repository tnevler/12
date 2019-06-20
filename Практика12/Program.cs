using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика12
{
    class Program
    {
        static public void Show(int[] arr)
        {
            foreach (int mas in arr) Console.Write(mas + " ");
        }
        static int[] BubbleSort(int[] arr)
        {
            int CountChange = 0; // кол-во перестановок
            int CountCompare = 0; // кол-во сравнений в теле цикла
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        CountCompare++;
                        CountChange++;
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    else CountCompare++;
                }
            }
            Show(arr);
            Console.WriteLine("\nКол-во перестановок: " + CountChange);
            Console.WriteLine("Кол-во сравнений: " + CountCompare);
            Console.WriteLine();
            return arr;
        }

        private static int[] CountingSort(int[] arr)
        {
            int CountChange = 0; // кол-во перестановок
            int CountCompare = 0; // кол-во сравнений в теле цикла

            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    CountCompare++;
                }
                else CountCompare++;
            }

            int[] count = new int[max + 1];
            int z = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i]]++;
            }
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    arr[z] = i;
                    z++;
                    count[i]--;
                }
            }
            Show(arr);
            Console.WriteLine("\nКол-во перестановок: " + CountChange);
            Console.WriteLine("Кол-во сравнений: " + CountCompare);
            Console.WriteLine();
            return arr;
        }

        static public int ReadIntNumber(string stringForUser, int left, int right)
        {
            bool okInput = false;
            int number = -100;
            do
            {
                Console.WriteLine(stringForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number < right) okInput = true;
                    else
                    {
                        Console.WriteLine("Неверно введено число!");
                        okInput = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверно введено число!");
                    okInput = false;
                }
            } while (!okInput);
            return number;
        }

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int n = ReadIntNumber("Введите размер массива: ", 1, 51);

            int[] arr1 = new int[n];// массив, упорядоченный по возрастанию
            for (int i=0; i<n; i++)
            {
                arr1[i] = i+1;
            }
            int[] arr2 = new int[n];// массив, упорядоченный по убыванию
            for (int i = 0; i < n; i++)
            {
                arr2[i] = n-i;
            }
            int[] arr3 = new int[n];// неупорядоченный массив
            for (int i=0; i<n; i++)
            {
                arr3[i] = rnd.Next(1, n+1);
            }

            int[] arr4 = new int[n];
            Array.Copy(arr1, arr4, n);

            int[] arr5 = new int[n];
            Array.Copy(arr2, arr5, n);

            int[] arr6 = new int[n];
            Array.Copy(arr3, arr6, n);

            Console.WriteLine("Массив упорядоченный по возрастанию:");
            Show(arr1);

            Console.WriteLine("\nМассив упорядоченный по убыванию:");
            Show(arr2);

            Console.WriteLine("\nНеупорядоченный массив:");
            Show(arr3);



            //1
            Console.WriteLine("\n\nСортировка пузырьком:");

            Console.WriteLine("Массив упорядоченный по возрастанию:");
            arr1 = BubbleSort(arr1);

            Console.WriteLine("Массив упорядоченный по убыванию:");
            arr2 = BubbleSort(arr2);

            Console.WriteLine("Неупорядоченный массив:");
            arr3 = BubbleSort(arr3);


            //2
            Console.WriteLine("Сортировка подсчётом:");

            Console.WriteLine("Массив упорядоченный по возрастанию:");
            arr4 = CountingSort(arr4);

            Console.WriteLine("Массив упорядоченный по убыванию:");
            arr5 = CountingSort(arr5);

            Console.WriteLine("Неупорядоченный массив:");
            arr6 = CountingSort(arr6);
            Console.ReadKey();
        }
    }
}
