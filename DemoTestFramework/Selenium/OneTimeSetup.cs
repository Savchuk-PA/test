using System;
using System.IO;
using NUnit.Framework;

[SetUpFixture]
public class OneTimeSetup
{
    [OneTimeSetUp]
    public void Init()
    {
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        Environment.CurrentDirectory = directory.Substring(0, directory.IndexOf("bin"));
    }
}