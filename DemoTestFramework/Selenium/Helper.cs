using System;
using NUnit.Allure.Attributes;

namespace Selenium;

public class Helper
{
    private static Random rnd = new Random();
    
    
    public static int GetRandomIntRange(int first, int second)
    {
        return rnd.Next(first, second);
    }
}