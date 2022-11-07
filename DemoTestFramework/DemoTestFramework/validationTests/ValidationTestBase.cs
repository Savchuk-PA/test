using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DemoTestFramework.helpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace DemoTestFramework.validationTests
{
    public abstract class ValidationTestBase
    {
        protected void CheckValidationResponseBySchemaFromFile(string content, string fileName)
        {
            JObject json = JObject.Parse(content);
            JSchema jSchema = JSchema.Parse(File.ReadAllText(FileHelper.GetFilePathByFileName(fileName)));
            bool result = json.IsValid(jSchema, out IList<string> messages);
            Assert.IsTrue(result, string.Join(" ,", messages.ToArray()));
        }
        
    }
}