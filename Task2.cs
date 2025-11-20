using System;                      
using System.Text;                 // Дозволяє налаштувати кодування тексту (UTF-8)

namespace Lab2_V21_2               // Простір імен
{
    class Program                  // Основний клас програми
    {
        // Значення з мого варіанта
        const double A = -Math.PI / 2;      // Початкове значення x (ліве значення інтервалу)
        const double B = -3 * Math.PI / 2;  // Кінцеве значення x (праве значення інтервалу)
        const double DX = Math.PI / 10;     // Крок зміни x (на скільки x змінюється кожного разу)

        static void Main()                   
        {
            Console.OutputEncoding = Encoding.UTF8;   // Увімкнення українських символів у консолі

            Console.WriteLine("Завдання 2: Обчислення функції на інтервалі");  // Заголовок програми
            Console.WriteLine("Функція: y = x^2 * cos(x)");                    // Формула
            Console.WriteLine($"Інтервал: від {A:F3} до {B:F3} з кроком {DX:F3}\n");  // Вивід меж і кроку інтервалу

            ExecuteTask2();  // Виклик методу, який виконує все завдання
        }

        // Завдання 2
        static void ExecuteTask2()   // Метод для виконання обчислень
        {
            double dx = DX;          // Створюю змінну-крок, щоб можна було змінювати її

            // Якщо початок інтервалу більший за кінець, а крок додатний — міняємо крок на від’ємний, бо ми йдемо з більшого значення до меншого 
            if (A > B && dx > 0) dx = -dx; 

            Console.WriteLine("--- Таблиця (WHILE) ---");    // Заголовок таблиці
            CalculateFunctionWhile(A, B, dx);                // Виклик обчислень через цикл while

            Console.WriteLine("\n--- Таблиця (DO...WHILE) ---"); // Заголовок таблиці для do..while
            CalculateFunctionDoWhile(A, B, dx);                  // Виклик обчислень через do..while
        }

        // while
        static void CalculateFunctionWhile(double a, double b, double dx)   // Обчислення через while
        {
            PrintTableHeading();   // Шапка таблиці

            double x = a;          // Початкове значення x
            while (x >= b)         // Умова: поки x не менше кінця інтервалу
            {
                ProcessIteration(x);   // Обчислення y і вивід одного рядка таблиці
                x += dx;               // Зміна x на наступний крок
            }

            PrintTableFooter();        // Закриття таблиці
        }

        // do...while
        static void CalculateFunctionDoWhile(double a, double b, double dx)  // Обчислення через do  while
        {
            PrintTableHeading();   // Шапка таблиці

            double x = a;          // Початкове значення x
            do
            {
                ProcessIteration(x);   // Обчислення одного рядка
                x += dx;               // Збільшуємо або зменшуємо x
            }
            while (x >= b);             // Перевірка умови після виконання циклу

            PrintTableFooter();         // Кінець таблиці
        }

        // Обчислення одного рядка таблиці
        static void ProcessIteration(double x)   // Метод, який обчислює y при даному x
        {
            double y = x * x * Math.Cos(x);      // Формула y = x^2 * cos(x)

            // Вивід x і y у вигляді таблиці з 3 знаками після коми
            Console.WriteLine($"| {x,8:F3} | {y,12:F3} |");
        }

        // Таблиця
        static void PrintTableHeading()          // Малює верхню частину таблиці
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("|    x     |     y = f(x)      |");
            Console.WriteLine("---------------------------------");
        }

        static void PrintTableFooter()           // Малює нижню частину таблиці
        {
            Console.WriteLine("---------------------------------");
        }
    }
}
