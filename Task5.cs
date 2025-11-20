using System;
using System.Text;

namespace Lab2_V21_5
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Завдання 5. Варіант 21");
            Console.WriteLine("Операція з матрицею nxn:");
            Console.WriteLine("Замінити кожен елемент рядка, де знаходиться мінімальний елемент,");
            Console.WriteLine("сумою елементів головної діагоналі.\n");

            // Спосіб А: Введення матриці з клавіатури
            Console.WriteLine("СПОСІБ А (введення з клавіатури)");
            int[,] matrixA = InputMatrixFromKeyboard(); //Викликаємо метод для введення матриці вручну
            ProcessMatrix(matrixA); // Обробляємо матрицю 

            // Спосіб Б: Випадкова генерація 
            Console.WriteLine("\nСПОСІБ Б (генерація випадкових чисел)");
            int[,] matrixB = GenerateRandomMatrix(); //Генеруємо матрицю з випадковими числами
            ProcessMatrix(matrixB);  // Обробляємо матрицю 
        }

        // Введення матриці з клавіатури 
        static int[,] InputMatrixFromKeyboard()
        {
            int n;

            while (true) // Безкінечний цикл, поки користувач не введе правильне число
            {
                Console.Write("Введіть розмір матриці n (n>0): ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out n) && n > 0) //Якщо введено число і воно більше 0
                    break;
                Console.WriteLine("Помилка! Потрібне додатнє ціле число.");
            }

            int[,] matrix = new int[n, n]; //Cтворюємо двовимірний масив n×n

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < n; i++) // Зовнішній цикл проходить по рядках
            {
                for (int j = 0; j < n; j++) // Внутрішній цикл проходить по стовпцях
                {
                    while (true) // Цикл для перевірки правильності введення числа
                    {
                        Console.Write($"A[{i},{j}]: "); // Виводимо позицію елемента, який треба ввести
                        string s = Console.ReadLine();

                        if (int.TryParse(s, out int x)) // Перевіряємо, чи це ціле число

                        {
                            matrix[i, j] = x; // Якщо так — записуємо його в матрицю
                            break;
                        }

                        Console.WriteLine("Помилка! Потрібне ціле число.");
                    }
                }
            }

            Console.WriteLine("\nВведена матриця:");
            PrintMatrix(matrix); // Виводимо матрицю на екран

            return matrix; //  Повертаємо матрицю 
        }

        //  Генерація випадкової матриці 
        static int[,] GenerateRandomMatrix()
        {
            int n;

            while (true) // Перевіряємо правильність введення розміру
            {
                Console.Write("Введіть розмір матриці n (n>0): ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out n) && n > 0) // Якщо введено правильне число > 0 
                    break;
                Console.WriteLine("Помилка! Потрібне додатнє ціле число.");
            }

            int[,] matrix = new int[n, n]; // Створюємо нову матрицю n×n
            Random rnd = new Random(); // Створюємо об’єкт для генерації випадкових чисеk

            for (int i = 0; i < n; i++) // Проходимо по рядках
                for (int j = 0; j < n; j++) // Проходимо по стовпцях
                    matrix[i, j] = rnd.Next(-100, 101);  //  Записуємо випадкові числа від -100 до 100

            Console.WriteLine("\nЗгенерована матриця:");
            PrintMatrix(matrix);

            return matrix;
        }

        // Обробка матриці 
        static void ProcessMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0); //Отримуємо розмірність матриці(кількість рядків або стовпців)


            // 1. Знайти мінімальний елемент і його рядок
            int minValue = matrix[0, 0]; //  Припускаємо, що перший елемент – мінімальний
            int minRow = 0; // Індекс рядка, де знаходиться мінімальний елемент

            for (int i = 0; i < n; i++) //  Проходимо по всіх рядках
                for (int j = 0; j < n; j++) //  Проходимо по всіх стовпцях
                    if (matrix[i, j] < minValue) // Якщо знайдено менше значення
                    {
                        minValue = matrix[i, j]; // Оновлюємо мінімальне значення
                        minRow = i; // Запам’ятовуємо номер рядка
                    }

            Console.WriteLine($"\nМінімальний елемент: {minValue}");
            Console.WriteLine($"Він знаходиться у рядку: {minRow}");

            // 2. Обчислити суму головної діагоналі
            int diagSum = 0;   //Змінна для суми елементів головної діагоналі
            for (int i = 0; i < n; i++) // Проходимо по всіх елементах діагоналі
                diagSum += matrix[i, i]; // Додаємо елемент до суми 

            Console.WriteLine($"Сума елементів головної діагоналі: {diagSum}");

            // 3. Замінити весь рядок minRow на diagSum
            for (int j = 0; j < n; j++) //  Проходимо по всіх стовпцях у рядку з мінімальним елементом
                matrix[minRow, j] = diagSum; // Замінюємо значення в рядку на суму діагоналі


            Console.WriteLine("\nМатриця після заміни рядка:");
            PrintMatrix(matrix);
        }

        // Виведення матриці 
        static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0); // Дізнаємось розмір матриці (кількість рядків)


            for (int i = 0; i < n; i++) //  Проходимо по кожному рядку
            {
                for (int j = 0; j < n; j++) // Проходимо по кожному стовпцю
                    Console.Write(matrix[i, j] + "\t"); // Виводимо елемент і відступ
                Console.WriteLine();
            }
        }
    }
}

