using Newtonsoft.Json;
using System;

namespace LukeVo.EnvironmentSettings.Json
{

    public static class JsonEnvironmentSettings
    {

        public static T GetInstance<T>(string environmentName)
        {
            return GetInstance<T>(environmentName, EnvironmentVariableTarget.Process);
        }

        public static T GetInstance<T>(string environmentName, EnvironmentVariableTarget environmentVariableTarget)
        {
            return EnvironmentSettings.GetInstance(environmentName, environmentVariableTarget,
                (fileContent) => JsonConvert.DeserializeObject<T>(fileContent));
        }

    }

}
