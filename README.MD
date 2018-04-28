This is a simple package for loading settings file from Environment Variable.

# Installing
You can install the package from Nuget:

    Install-Package LukeVo.EnvironmentSettings
If you want to use JSON, a package with [Newtonsoft JSON.NET](https://www.newtonsoft.com/json) dependency can be found here:

    Install-Package LukeVo.EnvironmentSettings.Json

# Usage
The package contains only a static utility class:

        var settings = EnvironmentSettings.GetInstance(
            "MyAppSettingsPath",
            (fileContent) => fileContent);
The first parameter is the name of the **Environment Variable**. The value should be the path to a file. `fileContent` will be the content of the file, and you can then proceed with processing the input string (in the example above it simply returns the same string from the content of the file).
You can also specific where to search the value (Process - default, User or Machine):

	    var settings = EnvironmentSettings.GetInstance(
	        "MyAppSettingsPath",
	        EnvironmentVariableTarget.Machine,
	        (fileContent) => fileContent);
If you use the JSON package, you can also deserialize immediately into an object:

        var result = JsonEnvironmentSettings.GetInstance<MyAppSettings>(
            "MyAppSettingsPath");
# Contribution
Please feel free to fork or submit issues if you find a bug or need some feature added.