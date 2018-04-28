using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LukeVo.EnvironmentSettings.Test
{

    internal static class Utils
    {
        private const string TestFilePath = "testfile.json";
        public const string UserEnvironment = "TestUserEnvironment";
        public const string UserNoFileEnvironment = "TestUserNoFileEnvironment";
        public const string MachineEnvironment = "TestMachineEnvironment";
        public const string MachineNoFileEnvironment = "TestMachineNoFileEnvironment";


        public static string GetTestFileContent()
        {
            return File.ReadAllText(TestFilePath);
        }

        public static TestFileViewModel GetTestFileObject()
        {
            return JsonConvert.DeserializeObject<TestFileViewModel>(
                GetTestFileContent());
        }

        public static string StringDeserializationMethod(string input)
        {
            return input;
        }

    }

}
