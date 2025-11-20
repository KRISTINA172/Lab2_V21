using System;
using System.Text;

namespace Lab2_V21_3
{
   public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Завдання 3. Варіант 21");
            Console.WriteLine("1) Порахувати кількість елементів, менших за 7");
            Console.WriteLine("2) Знайти добуток елементів між першим і другим нулями\n");

            // Спосіб А: масив вводить користувач

            Console.WriteLine("СПОСІБ А (введення з клавіатури)");
            int[] arrA = InputArrayFromKeyboard();   // Метод для введення масиву вручну
            ProcessArray(arrA);  // Метод для обробки масиву (обидві задачі

            // Спосіб Б: випадкове заповнення

            Console.WriteLine("\nСПОСІБ Б (генерація випадкових значень)");
            int[] arrB = GenerateRandomArray(); // Метод для генерації випадкового масиву
            ProcessArray(arrB); 
        }

        // Метод для тестування (повертає кількість елементів < 7)
        public static int CountLessThanSeven(int[] arr) // Метод рахує, скільки чисел менше за 7
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++) // Перебирає всі елементи масиву
                if (arr[i] < 7) // Якщо чисто менше за 7, збільшуємо на 1 
                    count++; 
            return count; // Повертає кількість елементів менших за 7
        }

        // Введення масиву з клавіатури
        static int[] InputArrayFromKeyboard() // Метод для введення масиву вручну
        {
            int n; // Змінна для розміру масиву

            while (true) // Безкінечний цикл для введення розміру масиву
            {
                Console.Write("Введіть кількість елементів масиву n: ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out n) && n > 0) // Перевірка чи це додатнє число 
                    break;
                Console.WriteLine("Помилка! Введіть додатнє ціле число.");
            }

            int[] arr = new int[n]; // Створює масив на n елементів 

            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < n; i++) // Цикл для введення всіх лементів масиву
            {
                while (true)
                {
                    Console.Write($"Елемент[{i}]: ");
                    string s = Console.ReadLine();
                    int x;
                    if (int.TryParse(s, out x)) // Перевіряє чи це ціле число 
                    {
                        arr[i] = x; // Якщо так, зберігає його в масив
                        break;
                    }
                    Console.WriteLine("Помилка! Потрібне ціле число.");
                }
            }

            Console.WriteLine("\nВведений масив:");
            PrintArray(arr); // Викликає метод для друку масиву

            return arr; // Повертає масив
        }

        // Генерація випадкового масиву
        static int[] GenerateRandomArray() // Метод для генерації випадкового масиву
        {
            int n;

            while (true) // Безкінечний цикл для введення розміру масиву
            {
                Console.Write("Введіть розмір масиву n: ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out n) && n > 0) // Перевіряє чи чисто додатнє 
                    break;

                Console.WriteLine("Помилка! Потрібне додатнє число.");
            }

            int[] arr = new int[n]; // Створює масив на n еллементів
            Random rnd = new Random(); // Генератор випадкових чисел 

            for (int i = 0; i < n; i++) // Цикл для заповнення масиву випадковими числами 
            {
                arr[i] = rnd.Next(-100, 101); // Заповнює випадковими числами від -100 до 100 
            }

            Console.WriteLine("\nЗгенерований масив:");
            PrintArray(arr); // Метод для друку масиву

            return arr;
        }

        // Обробка масиву (обидві задачі)
        static void ProcessArray(int[] arr) // Метод обробки масиву (обидві задачі)
        {
            Console.WriteLine("\n Результати обчислень");

            // 1) Кількість елементів < 7
            int countLess7 = CountLessThanSeven(arr); // Метод для підрахунку елементів менших за 7 
            Console.WriteLine($"Кількість елементів, менших за 7: {countLess7}"); 

            // 2) Добуток між першим і другим нулями
            int firstZero = -1; // Змінна для індексу першого нуля
            int secondZero = -1; // Змінна для індексу другого нуля

            for (int i = 0; i < arr.Length; i++) // Цикл для пошуку перших двох нулів
            {
                if (arr[i] == 0) // Якщо елемент = 0 
                {
                    if (firstZero == -1) // Якщо це перший 0
                        firstZero = i; // Запам'ятовує індекс першого 0 
                    else // Якщо це другий 0
                    {
                        secondZero = i; // Запам'ятовує індекс другого 0
                        break;
                    }
                }
            }

            if (firstZero == -1 || secondZero == -1) // Якщо немає двох 0 
            {
                Console.WriteLine("У масиві немає двох нульових елементів → добуток неможливо знайти.");
            }
            else
            {
                int product = 1; // Змінна для добутку
                for (int i = firstZero + 1; i < secondZero; i++) // Цикл для обчислення добутку між першим і другим 0 
                {
                    product *= arr[i]; // Множить елементи 
                }
                Console.WriteLine($"Добуток елементів між першим і другим нулями: {product}");
            }
        }

        // Друк масиву 
        static void PrintArray(int[] arr) // Метод для друку масиву
        {
            Console.Write("Масив: ");
            foreach (int x in arr) // Перебирає всі елементи масиву
                Console.Write(x + " "); // Друкує елемент з пробілом
            Console.WriteLine();
        }
    }
}
