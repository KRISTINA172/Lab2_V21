using Lab2_V21_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_V21_3.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_CountLessThanSeven() // Тест для методу CountLessThanSeven
        {
            
            int[] arr = { 2, 10,1 };   // Вхідні дані

            int expected = 2; // Очікуваний результат

            int actual = Program.CountLessThanSeven(arr); // Виклик методу 

            Assert.AreEqual(expected, actual, //Перевірка
                "Кількість елементів < 7 обчислена неправильно.");
        }
    }
}
