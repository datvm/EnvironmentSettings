using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LukeVo.EnvironmentSettings
{

    public static class EnvironmentSettings
    {

        public static T GetInstance<T>(string environmentName, Func<string, T> deserializationMethod)
        {
            return GetInstance(environmentName, EnvironmentVariableTarget.Process, deserializationMethod);
        }

        public static T GetInstance<T>(string environmentName, EnvironmentVariableTarget environmentVariableTarget, Func<string, T> deserializationMethod)
        {
            var environmentVariableValue = Environment.GetEnvironmentVariable(environmentName, environmentVariableTarget);

            if (string.IsNullOrEmpty(environmentVariableValue) || !File.Exists(environmentVariableValue))
            {
                throw new FileNotFoundException($"Environment Variable Name: \"{environmentName}\", Value: \"{environmentVariableValue}\".");
            }

            var fileContent = File.ReadAllText(environmentVariableValue);
            return deserializationMethod(fileContent);
        }

    }

}
