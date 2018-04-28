using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LukeVo.EnvironmentSettings.Test
{

    [TestClass]
    public class EnvironmentSettingsTest
    {
        private string testFileContent;

        [TestInitialize]
        public void Initialize()
        {
            testFileContent = Utils.GetTestFileContent();
        }

        #region Process-level

        [TestMethod]
        public void TestGetInstaceProcess1()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.UserEnvironment,
                Utils.StringDeserializationMethod);

            Assert.AreEqual(this.testFileContent, result);
        }

        [TestMethod]
        public void TestGetInstaceProcess2()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.MachineEnvironment,
                Utils.StringDeserializationMethod);

            Assert.AreEqual(this.testFileContent, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceProcessNoFile1()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.UserNoFileEnvironment,
                Utils.StringDeserializationMethod);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceProcessNoFile2()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.MachineNoFileEnvironment,
                Utils.StringDeserializationMethod);
        }

        #endregion 

        #region User-level

        [TestMethod]
        public void TestGetInstaceUser()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.UserEnvironment,
                EnvironmentVariableTarget.User,
                Utils.StringDeserializationMethod);

            Assert.AreEqual(this.testFileContent, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceUserNoFile()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.UserNoFileEnvironment,
                EnvironmentVariableTarget.User,
                Utils.StringDeserializationMethod);
        }

        #endregion

        #region Machine-level

        [TestMethod]
        public void TestGetInstaceMachine()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.MachineEnvironment,
                EnvironmentVariableTarget.Machine,
                Utils.StringDeserializationMethod);

            Assert.AreEqual(this.testFileContent, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceMachineNoFile()
        {
            var result = EnvironmentSettings.GetInstance(
                Utils.MachineNoFileEnvironment,
                EnvironmentVariableTarget.Machine,
                Utils.StringDeserializationMethod);
        }

        #endregion

    }

}
