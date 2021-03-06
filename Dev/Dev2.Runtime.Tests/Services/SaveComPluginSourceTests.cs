using System;
using System.Collections.Generic;
using System.Text;
using Dev2.Common.ExtMethods;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.Enums;
using Dev2.Communication;
using Dev2.Runtime.ESB.Management.Services;
using Dev2.Runtime.Interfaces;
using Dev2.Runtime.ServiceModel.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Serialization;

namespace Dev2.Tests.Runtime.Services
{
    [TestClass]
    public class SaveComPluginSourceTests
    {
        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        [TestCategory("GetResourceID")]
        public void GetResourceID_ShouldReturnEmptyGuid()
        {
            //------------Setup for test--------------------------
            var saveComPluginSource = new SaveComPluginSource();

            //------------Execute Test---------------------------
            var resId = saveComPluginSource.GetResourceID(new Dictionary<string, StringBuilder>());
            //------------Assert Results-------------------------
            Assert.AreEqual(Guid.Empty, resId);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        [TestCategory("GetResourceID")]
        public void GetAuthorizationContextForService_ShouldReturnContext()
        {
            //------------Setup for test--------------------------
            var saveComPluginSource = new SaveComPluginSource();

            //------------Execute Test---------------------------
            var resId = saveComPluginSource.GetAuthorizationContextForService();
            //------------Assert Results-------------------------
            Assert.AreEqual(AuthorizationContext.Contribute, resId);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        [TestCategory("SaveComPluginSource_HandlesType")]
        public void SaveComPluginSource_HandlesType_ExpectName()
        {
            //------------Setup for test--------------------------
            var saveComPluginSource = new SaveComPluginSource();


            //------------Execute Test---------------------------

            //------------Assert Results-------------------------
            Assert.AreEqual("SaveComPluginSource", saveComPluginSource.HandlesType());
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        [TestCategory("SaveComPluginSource_HandlesType")]
        public void SaveComPluginSource_CreateServiceEntry_ExpectActions()
        {
            //------------Setup for test--------------------------
            var saveComPluginSource = new SaveComPluginSource();


            //------------Execute Test---------------------------
            var dynamicService = saveComPluginSource.CreateServiceEntry();
            //------------Assert Results-------------------------
            Assert.IsNotNull(dynamicService);
            Assert.IsNotNull(dynamicService.Actions);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        [TestCategory("SaveComPluginSource_Execute")]
        public void SaveComPluginSource_Execute_NullValues_ErrorResult()
        {
            //------------Setup for test--------------------------
            var saveComPluginSource = new SaveComPluginSource();
            var serializer = new Dev2JsonSerializer();
            //------------Execute Test---------------------------
            var jsonResult = saveComPluginSource.Execute(null, null);
            var result = serializer.Deserialize<ExecuteMessage>(jsonResult);
            //------------Assert Results-------------------------
            Assert.IsTrue(result.HasError);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        [TestCategory("SaveComPluginSource_Execute")]
        public void SaveComPluginSource_Execute_ResourceIDNotPresent_ErrorResult()
        {
            //------------Setup for test--------------------------
            var values = new Dictionary<string, StringBuilder> { { "item", new StringBuilder() } };
            var saveComPluginSource = new SaveComPluginSource();
            var serializer = new Dev2JsonSerializer();
            //------------Execute Test---------------------------
            var jsonResult = saveComPluginSource.Execute(values, null);
            var result = serializer.Deserialize<ExecuteMessage>(jsonResult);
            //------------Assert Results-------------------------
            Assert.IsTrue(result.HasError);
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        public void Execute_GivenResourceDefination_ShouldSaveNewSourceReturnResourceDefinationMsg()
        {
            //---------------Set up test pack-------------------
            var serializer = new Dev2JsonSerializer();
            var source = new ComPluginSourceDefinition()
            {
                Id = Guid.Empty,
                ResourceName = "Name",
                ClsId = Guid.NewGuid().ToString(),
                ResourcePath = Environment.CurrentDirectory,
                SelectedDll = new DllListing() { Name = "k"}
            };
            var compressedExecuteMessage = new CompressedExecuteMessage();
            var serializeToJsonString = source.SerializeToJsonString(new DefaultSerializationBinder());
            compressedExecuteMessage.SetMessage(serializeToJsonString);
            var values = new Dictionary<string, StringBuilder>
            {
                { "ComPluginSource", source.SerializeToJsonStringBuilder() }
            };
            var catalog = new Mock<IResourceCatalog>();
            catalog.Setup(resourceCatalog => resourceCatalog.GetResource(It.IsAny<Guid>(), source.ResourceName));
            catalog.Setup(resourceCatalog => resourceCatalog.SaveResource(It.IsAny<Guid>(), It.IsAny<IResource>(),It.IsAny<string>()));
            var saveComPluginSource = new SaveComPluginSource(catalog.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var jsonResult = saveComPluginSource.Execute(values, null);
            var result = serializer.Deserialize<ExecuteMessage>(jsonResult);
            //---------------Test Result -----------------------
            Assert.IsFalse(result.HasError);
            catalog.Verify(resourceCatalog => resourceCatalog.GetResource(It.IsAny<Guid>(), source.ResourceName));
            catalog.Verify(resourceCatalog => resourceCatalog.SaveResource(It.IsAny<Guid>(), It.IsAny<IResource>(), It.IsAny<string>()));
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        [Owner("Nkosinathi Sangweni")]
        public void Execute_GivenResourceDefination_GivenExising_ShouldReturnResourceDefinationMsg()
        {
            //---------------Set up test pack-------------------
            var serializer = new Dev2JsonSerializer();
            var source = new ComPluginSourceDefinition()
            {
                Id = Guid.Empty,
                ResourceName = "Name",
                ClsId = Guid.NewGuid().ToString(),
                ResourcePath = Environment.CurrentDirectory,
                SelectedDll = new DllListing() { Name = "k"}

            };
            var compressedExecuteMessage = new CompressedExecuteMessage();
            var serializeToJsonString = source.SerializeToJsonString(new DefaultSerializationBinder());
            compressedExecuteMessage.SetMessage(serializeToJsonString);
            var values = new Dictionary<string, StringBuilder>
            {
                { "ComPluginSource", source.SerializeToJsonStringBuilder() }
            };
            var catalog = new Mock<IResourceCatalog>();
            var comPluginSource = new ComPluginSource();
            catalog.Setup(resourceCatalog => resourceCatalog.GetResource(It.IsAny<Guid>(), source.ResourceName)).Returns(comPluginSource);
            catalog.Setup(resourceCatalog => resourceCatalog.SaveResource(It.IsAny<Guid>(), comPluginSource, It.IsAny<string>()));
            var saveComPluginSource = new SaveComPluginSource(catalog.Object);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var jsonResult = saveComPluginSource.Execute(values, null);
            var result = serializer.Deserialize<ExecuteMessage>(jsonResult);
            //---------------Test Result -----------------------
            Assert.IsFalse(result.HasError);
            catalog.Verify(resourceCatalog => resourceCatalog.GetResource(It.IsAny<Guid>(), source.ResourceName));
            catalog.Verify(resourceCatalog => resourceCatalog.SaveResource(It.IsAny<Guid>(), comPluginSource, It.IsAny<string>()));
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void DllListing_GetHashCode_CorrectlyHashedObject()
        {
            var dllListing = new DllListing
            {
                Name = "Development",
                ClsId = "DevClsid"
            };
            Assert.AreEqual(-1908201757, dllListing.GetHashCode(), "Cannot get correct hash code for this object.");
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void DllListing_EqualsOperator_WithEqualObjects_AreEqual()
        {
            var firstDllListing = new DllListing { Name = "bravo" };
            var secondDllListing = new DllListing { Name = "bravo" };
            Assert.IsTrue(firstDllListing == secondDllListing, "Equals operator doesnt work.");
        }

        [TestMethod, DeploymentItem("EnableDocker.txt")]
        public void DllListing_NotEqualsOperator_WithNotEqualObjects_AreNotEqual()
        {
            var firstDllListing = new DllListing { Name = "bravo" };
            var secondDllListing = new DllListing { Name = "charlie" };
            Assert.IsTrue(firstDllListing != secondDllListing, "Not equals operator doesnt work.");
        }
    }
}