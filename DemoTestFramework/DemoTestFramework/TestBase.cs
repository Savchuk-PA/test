using System.Collections.Generic;
using NUnit.Framework;

namespace DemoTestFramework
{
    public abstract class TestBase
    {
        protected const string Host = "https://swapi.dev/api";
        private static List<string> Errors;
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // настройки перед вообще всеми тестами
        }

        [SetUp]
        public void Setup()
        {
            Errors = new List<string>();
        }
        
        [TearDown]
        public void TearDown()
        {
            Assert.IsEmpty(Errors, 
                $"Значения не соответствуют ожидаемым по: {string.Join("\n", Errors)}");
        }


        protected static void CustomAssertAreEqual(string expected, string actual, string message = "")
        {
            if (expected != actual) { Errors.Add(message + $" Ожидали {expected}. Получили: {actual}");}
        }
        
        protected static void CustomAssertAreEqual(int expected, int actual, string message = "")
        {
            if (expected != actual) { Errors.Add(message + $" Ожидали {expected}. Получили: {actual}");}
        }
        
        protected static void CustomAssertIsNull(string expected, string message = "")
        {
            if (!string.IsNullOrEmpty(expected)) { Errors.Add(message + $" Ожидали пустое значение. Получили {expected}");}
        }
        
        protected static void CustomAssertIsNotNull(string expected, string message = "")
        {
            if (string.IsNullOrEmpty(expected)) { Errors.Add(message + $" Ожидали не пустое значение. Получили {expected}");}
        }
    }
}