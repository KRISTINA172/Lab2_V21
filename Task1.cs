using System;
using System.Text;

namespace Lab2_V21_1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; //українська локалізація

            Console.WriteLine("Введіть номер місяця:");
            int month = Convert.ToInt32(Console.ReadLine());

            switch (month)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine("Зима");
                    break;

                case 3:
                case 4:
                case 5:
                    Console.WriteLine("Весна");
                    break;

                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Літо");
                    break;

                case 9:
                case 10:
                case 11:
                    Console.WriteLine("Осінь");
                    break;

                default:
                    Console.WriteLine("Некоректний номер місяця");
                    break;
            }
        }
    }
}

