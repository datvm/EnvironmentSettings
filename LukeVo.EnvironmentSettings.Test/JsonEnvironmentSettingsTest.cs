using LukeVo.EnvironmentSettings.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LukeVo.EnvironmentSettings.Test
{
    [TestClass]
    public class JsonEnvironmentSettingsTest
    {
        private TestFileViewModel testFileContent;

        [TestInitialize]
        public void Initialize()
        {
            testFileContent = Utils.GetTestFileObject();
        }

        #region Process-level

        [TestMethod]
        public void TestGetInstaceProcess1()
        {
            var result = JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.UserEnvironment);

            Assert.AreEqual(this.testFileContent.Content, result.Content);
        }

        [TestMethod]
        public void TestGetInstaceProcess2()
        {
            var result = JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.MachineEnvironment);

            Assert.AreEqual(this.testFileContent.Content, result.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceProcessNoFile1()
        {
            JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.UserNoFileEnvironment);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceProcessNoFile2()
        {
            JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.MachineNoFileEnvironment);
        }

        #endregion 

        #region User-level

        [TestMethod]
        public void TestGetInstaceUser()
        {
            var result = JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.UserEnvironment,
                EnvironmentVariableTarget.User);

            Assert.AreEqual(this.testFileContent.Content, result.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceUserNoFile()
        {
            JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.UserNoFileEnvironment,
                EnvironmentVariableTarget.User);
        }

        #endregion

        #region Machine-level

        [TestMethod]
        public void TestGetInstaceMachine()
        {
            var result = JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.MachineEnvironment,
                EnvironmentVariableTarget.Machine);

            Assert.AreEqual(this.testFileContent.Content, result.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetInstaceMachineNoFile()
        {
            JsonEnvironmentSettings.GetInstance<TestFileViewModel>(
                Utils.MachineNoFileEnvironment,
                EnvironmentVariableTarget.Machine);
        }

        #endregion

    }
}
