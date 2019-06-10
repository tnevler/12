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
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int[] arr1 = { 1, 3, 7, 9, 10, 15, 24, 30, 34, 40, 41, 43, 55, 56, 60, 62, 67, 70, 81, 90 };
            int[] arr2 = { 90, 81, 79, 77, 73, 70, 98, 65, 64, 50, 45, 39, 30, 25, 24, 19, 15, 10, 5, 2 };
            int[] arr3 = { 77, 50, 40, 3, 45, 15, 57, 69, 40, 40, 43, 64, 5, 13, 86, 40, 52, 75, 50, 85 };

            Console.WriteLine("Массив упорядоченный по возрастанию:");
            Show(arr1);

            Console.WriteLine("\nМассив упорядоченный по убыванию:");
            Show(arr2);

            Console.WriteLine("\nНеупорядоченный массив:");
            Show(arr3);
            Console.WriteLine("\n\nСортировка пузырьком:");

            arr1 = BubbleSort(arr1);
            arr2 = BubbleSort(arr2);
            arr3 = BubbleSort(arr3);

            Console.WriteLine("Сортировка подсчётом:");
            int[] arr4 = { 1, 3, 7, 9, 10, 15, 24, 30, 34, 40, 41, 43, 55, 56, 60, 62, 67, 70, 81, 90 };
            int[] arr5 = { 90, 81, 79, 77, 73, 70, 98, 65, 64, 50, 45, 39, 30, 25, 24, 19, 15, 10, 5, 2 };
            int[] arr6 = { 77, 50, 40, 3, 45, 15, 57, 69, 40, 40, 43, 64, 5, 13, 86, 40, 52, 75, 50, 85 };

            arr4 = CountingSort(arr4);
            arr5 = CountingSort(arr5);
            arr6 = CountingSort(arr6);
            Console.ReadKey();
        }
    }
}
