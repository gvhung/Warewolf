﻿using System;
using System.IO;
using System.Security.Principal;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Wrappers;
using Dev2.Common.Wrappers;
using Dev2.Interfaces;
using Dev2.Runtime.ESB.Execution;
using Dev2.Runtime.ESB.Execution.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Warewolf.Storage;
using System.Linq;

namespace Dev2.Tests.Runtime.ESB.Execution
{
    [TestClass]
    public class Dev2StateLoggerTests
    {
        IFile _fileWrapper;
        IDirectory _directoryWrapper;
        Dev2JsonStateLogger _dev2StateLogger;
        Dev2StateAuditLogger _dev2StateAuditLogger;
        Mock<IDev2Activity> _activity;
        DetailedLogFile _detailedLog;

        [TestCleanup]
        public void Cleanup()
        {
            if (_directoryWrapper == null)
            {
                _directoryWrapper = new DirectoryWrapper();
            }
            _directoryWrapper.Delete(EnvironmentVariables.DetailLogPath, true);
        }
        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_SubscribeToEventNotifications_Tests()
        {
            TestSetup(out _fileWrapper, out _directoryWrapper, out _dev2StateLogger, out _activity, out _detailedLog);
            using (_dev2StateLogger)
            {
                var nextActivityMock = new Mock<IDev2Activity>();
                var nextActivity = nextActivityMock.Object;
                var exception = new Exception("some exception");
                var message = new { Message = "Some Message" };
                var detailMethodName = nameof(Dev2StateLogger_SubscribeToEventNotifications_Tests);

                var notifier = new StateNotifier();
                var stateLoggerMock = new Mock<IStateListener>();
                stateLoggerMock.Setup(o => o.LogPreExecuteState(_activity.Object)).Verifiable();
                stateLoggerMock.Setup(o => o.LogPostExecuteState(_activity.Object, nextActivity)).Verifiable();
                stateLoggerMock.Setup(o => o.LogExecuteException(exception, nextActivity)).Verifiable();
                stateLoggerMock.Setup(o => o.LogAdditionalDetail(message, detailMethodName)).Verifiable();
                stateLoggerMock.Setup(o => o.LogExecuteCompleteState(nextActivity)).Verifiable();
                stateLoggerMock.Setup(o => o.LogStopExecutionState(nextActivity)).Verifiable();
                var listener = stateLoggerMock.Object;
                // test
                notifier.Subscribe(listener);

                notifier.LogPreExecuteState(_activity.Object);
                notifier.LogPostExecuteState(_activity.Object, nextActivity);
                notifier.LogExecuteException(exception, nextActivity);
                notifier.LogAdditionalDetail(message, detailMethodName);
                notifier.LogExecuteCompleteState(nextActivity);
                notifier.LogStopExecutionState(nextActivity);

                // verify
                stateLoggerMock.Verify();
                notifier.Dispose();
            }
        }
        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_LogPreExecuteState_Tests()
        {
            TestSetup(out _fileWrapper, out _directoryWrapper, out _dev2StateLogger, out _activity, out _detailedLog);
            // test
            _dev2StateLogger.LogPreExecuteState(_activity.Object);
            _dev2StateLogger.Dispose();
            // verify
            var text = _fileWrapper.ReadAllText(_detailedLog.LogFilePath);
            //Expect something like: "header:LogPreExecuteState\r\n{\"timestamp\":\"2018-06-19T16:05:29.6755408+02:00\",\"NextActivity\":null}\r\n{\"DsfDataObject\":{\"ServerID\":\"00000000-0000-0000-0000-000000000000\",\"ParentID\":\"00000000-0000-0000-0000-000000000000\",\"ClientID\":\"00000000-0000-0000-0000-000000000000\",\"ExecutingUser\":\"Mock<System.Security.Principal.IIdentity:00000001>.Object\",\"ExecutionID\":null,\"ExecutionOrigin\":0,\"ExecutionOriginDescription\":null,\"ExecutionToken\":\"Mock<Dev2.Common.Interfaces.IExecutionToken:00000001>.Object\",\"IsSubExecution\":false,\"IsRemoteWorkflow\":false,\"Environment\":{\"scalars\":{},\"record_sets\":{},\"json_objects\":{}}}}\r\n"
            Assert.IsTrue(text.Contains("LogPreExecuteState"));
            Assert.IsTrue(text.Contains("timestamp"));
            Assert.IsTrue(text.Contains("NextActivity"));
            Assert.IsTrue(text.Contains("scalars"));
            Assert.IsTrue(text.Contains("record_sets"));
            Assert.IsTrue(text.Contains("json_objects"));
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_LogPostExecuteState_Tests()
        {
            TestSetup(out _fileWrapper, out _directoryWrapper, out _dev2StateLogger, out _activity, out _detailedLog);
            var previousActivity = new Mock<IDev2Activity>();
            var nextActivity = new Mock<IDev2Activity>();
            // test
            _dev2StateLogger.LogPostExecuteState(previousActivity.Object, nextActivity.Object);
            _dev2StateLogger.Dispose();
            // verify
            var text = _fileWrapper.ReadAllText(_detailedLog.LogFilePath);
            //Expect something like: "header:LogPostExecuteState\r\n{\"timestamp\":\"2018-06-19T16:05:29.6755408+02:00\",\"NextActivity\":null}\r\n{\"DsfDataObject\":{\"ServerID\":\"00000000-0000-0000-0000-000000000000\",\"ParentID\":\"00000000-0000-0000-0000-000000000000\",\"ClientID\":\"00000000-0000-0000-0000-000000000000\",\"ExecutingUser\":\"Mock<System.Security.Principal.IIdentity:00000001>.Object\",\"ExecutionID\":null,\"ExecutionOrigin\":0,\"ExecutionOriginDescription\":null,\"ExecutionToken\":\"Mock<Dev2.Common.Interfaces.IExecutionToken:00000001>.Object\",\"IsSubExecution\":false,\"IsRemoteWorkflow\":false,\"Environment\":{\"scalars\":{},\"record_sets\":{},\"json_objects\":{}}}}\r\n"
            Assert.IsTrue(text.Contains("LogPostExecuteState"));
            Assert.IsTrue(text.Contains("timestamp"));
            Assert.IsTrue(text.Contains("NextActivity"));
            Assert.IsTrue(text.Contains("scalars"));
            Assert.IsTrue(text.Contains("record_sets"));
            Assert.IsTrue(text.Contains("json_objects"));
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_LogExecuteException_Tests()
        {
            TestSetup(out _fileWrapper, out _directoryWrapper, out _dev2StateLogger, out _activity, out _detailedLog);
            // setup
            var nextActivity = new Mock<IDev2Activity>();
            var exception = new NullReferenceException();
            // test
            _dev2StateLogger.LogExecuteException(exception, nextActivity.Object);
            _dev2StateLogger.Dispose();
            // verify
            var text = _fileWrapper.ReadAllText(_detailedLog.LogFilePath);
            //Expect something like: "header:LogExecuteException{ "timestamp":"2018-06-20T08:32:01.719266+02:00","PreviousActivity":null,"Exception":"Object reference not set to an instance of an object."}{ "DsfDataObject":{ "ServerID":"00000000-0000-0000-0000-000000000000","ParentID":"00000000-0000-0000-0000-000000000000","ClientID":"00000000-0000-0000-0000-000000000000","ExecutingUser":"Mock<System.Security.Principal.IIdentity:00000001>.Object","ExecutionID":null,"ExecutionOrigin":0,"ExecutionOriginDescription":null,"ExecutionToken":"Mock<Dev2.Common.Interfaces.IExecutionToken:00000001>.Object","IsSubExecution":false,"IsRemoteWorkflow":false,"Environment":{ "scalars":{ },"record_sets":{ },"json_objects":{ } } } }""
            Assert.IsTrue(text.Contains("LogExecuteException"));
            Assert.IsTrue(text.Contains("timestamp"));
            Assert.IsTrue(text.Contains("PreviousActivity"));
            Assert.IsTrue(text.Contains("Exception"));
            Assert.IsTrue(text.Contains("scalars"));
            Assert.IsTrue(text.Contains("record_sets"));
            Assert.IsTrue(text.Contains("json_objects"));
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_LogExecuteCompleteState_Tests()
        {
            TestSetup(out _fileWrapper, out _directoryWrapper, out _dev2StateLogger, out _activity, out _detailedLog);
            var nextActivity = new Mock<IDev2Activity>();
            var exception = new NullReferenceException();
            // test
            _dev2StateLogger.LogExecuteCompleteState(nextActivity.Object);
            _dev2StateLogger.Dispose();
            // verify
            var text = _fileWrapper.ReadAllText(_detailedLog.LogFilePath);
            //Expect something like: "header:LogExecuteException{ "timestamp":"2018-06-20T08:32:01.719266+02:00","PreviousActivity":null,"Exception":"Object reference not set to an instance of an object."}{ "DsfDataObject":{ "ServerID":"00000000-0000-0000-0000-000000000000","ParentID":"00000000-0000-0000-0000-000000000000","ClientID":"00000000-0000-0000-0000-000000000000","ExecutingUser":"Mock<System.Security.Principal.IIdentity:00000001>.Object","ExecutionID":null,"ExecutionOrigin":0,"ExecutionOriginDescription":null,"ExecutionToken":"Mock<Dev2.Common.Interfaces.IExecutionToken:00000001>.Object","IsSubExecution":false,"IsRemoteWorkflow":false,"Environment":{ "scalars":{ },"record_sets":{ },"json_objects":{ } } } }""
            Assert.IsTrue(text.Contains("LogExecuteCompleteState"));
            Assert.IsTrue(text.Contains("timestamp"));
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_LogStopExecutionState_Tests()
        {
            TestSetup(out _fileWrapper, out _directoryWrapper, out _dev2StateLogger, out _activity, out _detailedLog);
            var nextActivity = new Mock<IDev2Activity>();
            var exception = new NullReferenceException();
            // test
            _dev2StateLogger.LogStopExecutionState(nextActivity.Object);
            _dev2StateLogger.Dispose();
            // verify
            var text = _fileWrapper.ReadAllText(_detailedLog.LogFilePath);
            //Expect something like: "header:LogStopExecutionState\r\n{\"timestamp\":\"2018-06-25T09:50:55.1624974+02:00\"}\r\n{\"DsfDataObject\":{\"ServerID\":\"00000000-0000-0000-0000-000000000000\",\"ParentID\":\"00000000-0000-0000-0000-000000000000\",\"ClientID\":\"00000000-0000-0000-0000-000000000000\",\"ExecutingUser\":\"Mock<System.Security.Principal.IIdentity:00000001>.Object\",\"ExecutionID\":null,\"ExecutionOrigin\":0,\"ExecutionOriginDescription\":null,\"ExecutionToken\":\"Mock<Dev2.Common.Interfaces.IExecutionToken:00000001>.Object\",\"IsSubExecution\":false,\"IsRemoteWorkflow\":false,\"Environment\":{\"Environment\":{\"scalars\":{},\"record_sets\":{},\"json_objects\":{}},\"Errors\":[],\"AllErrors\":[]}}}\r\nheader:LogStopExecutionState\r\n{\"timestamp\":\"2018-06-25T09:52:02.3074228+02:00\"}\r\n{\"DsfDataObject\":{\"ServerID\":\"00000000-0000-0000-0000-000000000000\",\"ParentID\":\"00000000-0000-0000-0000-000000000000\",\"ClientID\":\"00000000-0000-0000-0000-000000000000\",\"ExecutingUser\":\"Mock<System.Security.Principal.IIdentity:00000001>.Object\",\"ExecutionID\":null,\"ExecutionOrigin\":0,\"ExecutionOriginDescription\":null,\"ExecutionToken\":\"Mock<Dev2.Common.Interfaces.IExecutionToken:00000001>.Object\",\"IsSubExecution\":false,\"IsRemoteWorkflow\":false,\"Environment\":{\"Environment\":{\"scalars\":{},\"record_sets\":{},\"json_objects\":{}},\"Errors\":[],\"AllErrors\":[]}}}\r\nheader:LogStopExecutionState\r\n{\"timestamp\":\"2018-06-25T09:52:31.2454735+02:00\"}\r\n{\"DsfDataObject\":{\"ServerID\":\"00000000-0000-0000-0000-000000000000\",\"ParentID\":\"00000000-0000-0000-0000-000000000000\",\"ClientID\":\"00000000-0000-0000-0000-000000000000\",\"ExecutingUser\":\"Mock<System.Security.Principal.IIdentity:00000001>.Object\",\"ExecutionID\":null,\"ExecutionOrigin\":0,\"ExecutionOriginDescription\":null,\"ExecutionToken\":\"Mock<Dev2.Common.Interfaces.IExecutionToken:00000001>.Object\",\"IsSubExecution\":false,\"IsRemoteWorkflow\":false,\"Environment\":{\"Environment\":{\"scalars\":{},\"record_sets\":{},\"json_objects\":{}},\"Errors\":[],\"AllErrors\":[]}}}\r\n"
            Assert.IsTrue(text.Contains("LogStopExecutionState"));
            Assert.IsTrue(text.Contains("timestamp"));
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_Given_LogFile_AlreadyExists()
        {
            var streamWriter = TextWriter.Synchronized(new StreamWriter(new MemoryStream()));
            var mockedStream = new Mock<IDev2StreamWriter>();
            mockedStream.Setup(p => p.SynchronizedTextWriter).Returns(streamWriter);
            var mockedDataObject = SetupDataObject();
            var mockedFileWrapper = new Mock<IFile>();
            mockedFileWrapper.Setup(p => p.AppendText(It.IsAny<string>())).Returns(mockedStream.Object);
            mockedFileWrapper.Setup(p => p.Exists(It.IsAny<string>())).Returns(true);
            mockedFileWrapper.Setup(p => p.GetLastWriteTime(It.IsAny<string>())).Returns(DateTime.Today.AddDays(-1));
            _dev2StateLogger = GetDev2JsonStateLogger(mockedFileWrapper.Object, mockedDataObject);
            var nextActivity = new Mock<IDev2Activity>();
            // test
            _dev2StateLogger.Dispose();
            // verify
            mockedFileWrapper.Verify(p => p.Copy(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce());
            mockedFileWrapper.Verify(p => p.AppendText(It.IsAny<string>()), Times.AtLeastOnce());
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_Given_LogFile_AlreadyExists_And_Is_More_Than_2_Days_Old()
        {
            var streamWriter = TextWriter.Synchronized(new StreamWriter(new MemoryStream()));
            var mockedStream = new Mock<IDev2StreamWriter>();
            mockedStream.Setup(p => p.SynchronizedTextWriter).Returns(streamWriter);
            var mockedDataObject = SetupDataObject();
            var mockedFileWrapper = new Mock<IFile>();
            var zipWrapper = new Mock<IZipFile>();
            zipWrapper.Setup(p => p.CreateFromDirectory(It.IsAny<string>(), It.IsAny<string>()));
            mockedFileWrapper.Setup(p => p.AppendText(It.IsAny<string>())).Returns(mockedStream.Object);
            mockedFileWrapper.Setup(p => p.Exists(It.IsAny<string>())).Returns(true);
            mockedFileWrapper.Setup(p => p.GetLastWriteTime(It.IsAny<string>())).Returns(DateTime.Today.AddDays(-5));
            _dev2StateLogger = GetDev2JsonStateLogger(mockedFileWrapper.Object, mockedDataObject, zipWrapper.Object);
            var nextActivity = new Mock<IDev2Activity>();
            // test
            _dev2StateLogger.Dispose();
            // verify
            mockedFileWrapper.Verify(p => p.Copy(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce());
            mockedFileWrapper.Verify(p => p.AppendText(It.IsAny<string>()), Times.AtLeastOnce());
            zipWrapper.Verify(p => p.CreateFromDirectory(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce());

        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateLogger_Given_LogFile_AlreadyExists_And_Is_More_Than_30_Days_Old()
        {            
            var streamWriter = TextWriter.Synchronized(new StreamWriter(new MemoryStream()));
            var mockedStream = new Mock<IDev2StreamWriter>();
            mockedStream.Setup(p => p.SynchronizedTextWriter).Returns(streamWriter);
            var mockedDataObject = SetupDataObject();
            var mockedFileWrapper = new Mock<IFile>();
            var zipWrapper = new Mock<IZipFile>();
            zipWrapper.Setup(p => p.CreateFromDirectory(It.IsAny<string>(), It.IsAny<string>()));
            mockedFileWrapper.Setup(p => p.AppendText(It.IsAny<string>())).Returns(mockedStream.Object);
            mockedFileWrapper.Setup(p => p.Exists(It.IsAny<string>())).Returns(true);
            mockedFileWrapper.Setup(p => p.GetLastWriteTime(It.IsAny<string>())).Returns(DateTime.Today.AddDays(-45));
            _dev2StateLogger = GetDev2JsonStateLogger(mockedFileWrapper.Object, mockedDataObject, zipWrapper.Object);
            // test
            _dev2StateLogger.Dispose();
            // verify
            mockedFileWrapper.Verify(p => p.Copy(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce());
            mockedFileWrapper.Verify(p => p.AppendText(It.IsAny<string>()), Times.AtLeastOnce());
            mockedFileWrapper.Verify(p => p.Delete(It.IsAny<string>()), Times.AtLeastOnce());
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateAuditLogger_LogExecuteCompleteState_Tests()
        {
            var expectedWorkflowId = Guid.NewGuid();
            var expectedExecutionId = Guid.NewGuid();
            var nextActivity = new Mock<IDev2Activity>();
            var expectedWorkflowName = "LogExecuteCompleteState_Workflow";
            TestAuditSetupWithAssignedInputs(expectedWorkflowId, expectedWorkflowName, expectedExecutionId, out _dev2StateAuditLogger, out _activity);
            // test
            _dev2StateAuditLogger.LogExecuteCompleteState(nextActivity.Object);

            // verify
            var str = expectedWorkflowId.ToString();
            var results = Dev2StateAuditLogger.Query(a => (a.WorkflowID.Equals(str)
                || a.WorkflowName.Equals("LogExecuteCompleteState")
                || a.ExecutionID.Equals("")
                || a.AuditType.Equals("")));
            _dev2StateAuditLogger.Dispose();

            Assert.IsTrue(results.FirstOrDefault(a => a.WorkflowID == str) != null);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateAuditLogger_LogExecuteException_Tests()
        {
            var expectedWorkflowId = Guid.NewGuid();
            var expectedExecutionId = Guid.NewGuid();
            var expectedWorkflowName = "LogExecuteException_Workflow";
            TestAuditSetupWithAssignedInputs(expectedWorkflowId, expectedWorkflowName, expectedExecutionId, out _dev2StateAuditLogger, out _activity);
            // test
            var activity = new Mock<IDev2Activity>();
            var exception = new Mock<Exception>();
            _dev2StateAuditLogger.LogExecuteException(exception.Object, activity.Object);

            // verify
            var str = expectedWorkflowId.ToString();
            var results = Dev2StateAuditLogger.Query(a => (a.WorkflowID.Equals(str)
                || a.WorkflowName.Equals("LogExecuteException")
                || a.ExecutionID.Equals("")
                || a.AuditType.Equals("")));
            _dev2StateAuditLogger.Dispose();

            Assert.IsTrue(results.FirstOrDefault(a => a.WorkflowID == str) != null);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateAuditLogger_LogPostExecuteState_Tests()
        {
            var expectedWorkflowId = Guid.NewGuid();
            var expectedExecutionId = Guid.NewGuid();
            var expectedWorkflowName = "LogPostExecuteState_Workflow";
            TestAuditSetupWithAssignedInputs(expectedWorkflowId, expectedWorkflowName, expectedExecutionId, out _dev2StateAuditLogger, out _activity);
            // test
            var previousActivity = new Mock<IDev2Activity>();
            var nextActivity = new Mock<IDev2Activity>();
            _dev2StateAuditLogger.LogPostExecuteState(previousActivity.Object, nextActivity.Object);

            // verify
            var str = expectedWorkflowId.ToString();
            var results = Dev2StateAuditLogger.Query(a => (a.WorkflowID.Equals(str)
                || a.WorkflowName.Equals("LogPostExecuteState")
                || a.ExecutionID.Equals("")
                || a.AuditType.Equals("")));
            _dev2StateAuditLogger.Dispose();

            Assert.IsTrue(results.FirstOrDefault(a => a.WorkflowID == str) != null);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateAuditLogger_LogAdditionalDetail_Tests()
        {
            var expectedWorkflowId = Guid.NewGuid();
            var expectedExecutionId = Guid.NewGuid();
            var expectedWorkflowName = "LogAdditionalDetail_Workflow";
            TestAuditSetupWithAssignedInputs(expectedWorkflowId, expectedWorkflowName, expectedExecutionId, out _dev2StateAuditLogger, out _activity);
            // test
            var additionalDetailObject = new { Message = "Some Message" };
            _dev2StateAuditLogger.LogAdditionalDetail(additionalDetailObject, "");


            // verify
            var str = expectedWorkflowId.ToString();
            var results = Dev2StateAuditLogger.Query(a => (a.WorkflowID.Equals(str)
                || a.WorkflowName.Equals("LogAdditionalDetail")
                || a.ExecutionID.Equals("")
                || a.AuditType.Equals("")));
            _dev2StateAuditLogger.Dispose();

            Assert.IsTrue(results.FirstOrDefault(a => a.WorkflowID == str) != null);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void Dev2StateAuditLogger_LogPreExecuteState_Tests()
        {
            var expectedWorkflowId = Guid.NewGuid();
            var expectedExecutionId = Guid.NewGuid();
            var expectedWorkflowName = "LogPreExecuteState_Workflow";
            TestAuditSetupWithAssignedInputs(expectedWorkflowId, expectedWorkflowName, expectedExecutionId, out _dev2StateAuditLogger, out _activity);
            // test
            _dev2StateAuditLogger.LogPreExecuteState(_activity.Object);
            // verify
            var str = expectedWorkflowId.ToString();
            var results = Dev2StateAuditLogger.Query(item => true);
            _dev2StateAuditLogger.Dispose();

            foreach (var item in results)
            {

            }

            var result = results.FirstOrDefault(a => a.WorkflowID == str);
            Assert.IsTrue(result != null);
            Assert.AreEqual("{\"Environment\":{\"scalars\":{},\"record_sets\":{},\"json_objects\":{}},\"Errors\":[],\"AllErrors\":[]}",
                            result.Environment);
        }
        
        private static void TestSetup(out IFile fileWrapper, out IDirectory directoryWrapper, out Dev2JsonStateLogger dev2StateLogger, out Mock<IDev2Activity> activity, out DetailedLogFile detailedLog)
        {
            // setup
            Mock<IDSFDataObject> mockedDataObject = SetupDataObject();
            fileWrapper = new FileWrapper();
            directoryWrapper = new DirectoryWrapper();
            activity = new Mock<IDev2Activity>();
            dev2StateLogger = GetDev2JsonStateLogger(fileWrapper, mockedDataObject);
            detailedLog = SetupDetailedLog(dev2StateLogger);
        }
        
        private static Dev2JsonStateLogger GetDev2JsonStateLogger(IFile fileWrapper, Mock<IDSFDataObject> mockedDataObject, IZipFile zipWrapper = null)
        {
            return new Dev2JsonStateLogger(mockedDataObject.Object, fileWrapper, zipWrapper);
        }
        private static Dev2StateAuditLogger GetDev2AuditStateLogger(Mock<IDSFDataObject> mockedDataObject)
        {
            return new Dev2StateAuditLogger(mockedDataObject.Object);
        }

        private static void TestAuditSetupWithAssignedInputs(Guid resourceId, string workflowName, Guid executionId, out Dev2StateAuditLogger dev2AuditStateLogger, out Mock<IDev2Activity> activity)
        {
            // setup
            Mock<IDSFDataObject> mockedDataObject = SetupDataObjectWithAssignedInputs(resourceId, workflowName, executionId);

            activity = new Mock<IDev2Activity>();
            dev2AuditStateLogger = GetDev2AuditStateLogger(mockedDataObject);
        }

        private static Mock<IDSFDataObject> SetupDataObjectWithAssignedInputs(Guid resourceId, string workflowName, Guid executionId)
        {
            // mocks
            var mockedDataObject = new Mock<IDSFDataObject>();
            mockedDataObject.Setup(o => o.Environment).Returns(() => new ExecutionEnvironment());
            mockedDataObject.Setup(o => o.ServiceName).Returns(() => workflowName);
            mockedDataObject.Setup(o => o.ResourceID).Returns(() => resourceId);
            mockedDataObject.Setup(o => o.ExecutionID).Returns(() => executionId);
            var principal = new Mock<IPrincipal>();
            principal.Setup(o => o.Identity).Returns(() => new Mock<IIdentity>().Object);
            mockedDataObject.Setup(o => o.ExecutingUser).Returns(() => principal.Object);
            mockedDataObject.Setup(o => o.ExecutionToken).Returns(() => new Mock<IExecutionToken>().Object);
            return mockedDataObject;
        }



        private static Mock<IDSFDataObject> SetupDataObject()
        {
            // mocks
            var mockedDataObject = new Mock<IDSFDataObject>();
            mockedDataObject.Setup(o => o.Environment).Returns(() => new ExecutionEnvironment());
            mockedDataObject.Setup(o => o.ServiceName).Returns(() => "Some Workflow");
            mockedDataObject.Setup(o => o.ResourceID).Returns(() => Guid.NewGuid());
            var principal = new Mock<IPrincipal>();
            principal.Setup(o => o.Identity).Returns(() => new Mock<IIdentity>().Object);
            mockedDataObject.Setup(o => o.ExecutingUser).Returns(() => principal.Object);
            mockedDataObject.Setup(o => o.ExecutionToken).Returns(() => new Mock<IExecutionToken>().Object);
            return mockedDataObject;
        }
        private static DetailedLogFile SetupDetailedLog(Dev2JsonStateLogger dev2StateLogger)
        {
            var privateObject = new PrivateObject(dev2StateLogger);
            var detailedLog = privateObject.GetField("_detailedLogFile") as DetailedLogFile;
            return detailedLog;
        }
    }
}