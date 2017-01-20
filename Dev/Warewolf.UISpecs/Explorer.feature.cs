﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.UISpecs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class ExplorerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Explorer.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Explorer", "\tIn order to manage services\r\n\tAs a Warewolf Studio user\r\n\tI want to perform a co" +
                    "mposition of recorded actions", ProgrammingLanguage.CSharp, new string[] {
                        "Explorer"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Explorer")))
            {
                Warewolf.UISpecs.ExplorerFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag on Remote Subworkflow from Explorer and Execute it")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void DragOnRemoteSubworkflowFromExplorerAndExecuteIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag on Remote Subworkflow from Explorer and Execute it", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I Try DisConnect To Remote Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I Create New Workflow using shortcut", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.And("I Select RemoteConnectionIntegration From Explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("I Filter the Explorer with \"GenericResource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I Drag Explorer Remote GenericResource Onto Workflow Design Surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I Save With Ribbon Button And Dialog As \"LocalGenericResourceWithRemoteSubworkflo" +
                    "w\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I Click Debug Ribbon Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I Click DebugInput Debug Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I Click Debug Output GenericResource Name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening and Editing Workflow from Explorer Remote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void OpeningAndEditingWorkflowFromExplorerRemote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening and Editing Workflow from Explorer Remote", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.And("I Try DisConnect To Remote Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("I Select RemoteConnectionIntegration From Explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I Filter the Explorer with \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("I open \"Hello World\" in Remote Connection Integration", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.And("I Try Close Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Workflow local and remote using right click")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void OpeningWorkflowLocalAndRemoteUsingRightClick()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Workflow local and remote using right click", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
   testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
   testRunner.When("I Select RemoteConnectionIntegration From Explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
   testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
   testRunner.And("I Filter the Explorer with \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
   testRunner.And("I RightClick Explorer First Remote Server First Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
   testRunner.And("I Select Open FromExplorerContextMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
   testRunner.Then("Remote \"Hello World - Remote Connection Integration\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
   testRunner.Then("I RightClick Explorer Localhost First Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
   testRunner.And("I Select Open FromExplorerContextMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
   testRunner.Then("Local \"Hello World\" is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deleting a Resource localhost")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void DeletingAResourceLocalhost()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deleting a Resource localhost", ((string[])(null)));
#line 43
 this.ScenarioSetup(scenarioInfo);
#line 44
   testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
   testRunner.When("I Create New Workflow using shortcut", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
   testRunner.And("I Filter the Explorer with \"GenericResource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
   testRunner.And("I Drag Explorer workflow Onto Workflow Design Surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
   testRunner.And("I Save With Ribbon Button And Dialog As \"LocalWorkflowWithRemoteSubworkflowToDele" +
                    "te\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
   testRunner.And("I Filter the Explorer with \"LocalWorkflowWithRemoteSubworkflowToDelete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
   testRunner.And("I RightClick Explorer Localhost First Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
   testRunner.And("I Select Delete FromExplorerContextMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
   testRunner.And("I Click MessageBox Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deleting a Folder in localhost")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void DeletingAFolderInLocalhost()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deleting a Folder in localhost", ((string[])(null)));
#line 54
 this.ScenarioSetup(scenarioInfo);
#line 55
   testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
   testRunner.When("I Filter the Explorer with \"FolderToDelete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
   testRunner.And("I RightClick Explorer Localhost First Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
   testRunner.And("I Select Delete FromExplorerContextMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
   testRunner.And("I Click MessageBox Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Filter Should Clear On Connection Of Remote Server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void FilterShouldClearOnConnectionOfRemoteServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Filter Should Clear On Connection Of Remote Server", ((string[])(null)));
#line 61
 this.ScenarioSetup(scenarioInfo);
#line 62
   testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
   testRunner.And("I Try DisConnect To Remote Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
   testRunner.When("I Filter the Explorer with \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
   testRunner.When("I Select RemoteConnectionIntegration From Explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
   testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
   testRunner.Then("Filter Textbox is cleared", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
   testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deleting a Resource Remote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void DeletingAResourceRemote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deleting a Resource Remote", ((string[])(null)));
#line 70
 this.ScenarioSetup(scenarioInfo);
#line 71
   testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
   testRunner.And("I Try DisConnect To Remote Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
   testRunner.When("I Select RemoteConnectionIntegration From Explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
   testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
   testRunner.And("I Wait For Explorer First Remote Server Spinner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
   testRunner.And("I Click New Workflow Ribbon Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
   testRunner.And("I Filter the Explorer with \"GenericResource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
   testRunner.And("I Drag Explorer Remote GenericResource Onto Workflow Design Surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
   testRunner.And("I Save With Ribbon Button And Dialog As \"LocalWorkflowWithRemoteSubworkflowToDele" +
                    "te\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
   testRunner.And("I Filter the Explorer with \"LocalWorkflowWithRemoteSubworkflowToDelete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
   testRunner.And("I RightClick Explorer First Remote Server First Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
   testRunner.And("I Select Delete FromExplorerContextMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
   testRunner.And("I Click MessageBox Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
   testRunner.And("I Click Explorer Connect Remote Server Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Clear filter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void ClearFilter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Clear filter", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
   testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 88
   testRunner.When("I Filter the Explorer with \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
   testRunner.Then("Filter Textbox has \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
   testRunner.And("I Click Explorer Filter Clear Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
   testRunner.Then("Filter Textbox is cleared", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Refresh Remote Server Refreshes Only The Remote Server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void RefreshRemoteServerRefreshesOnlyTheRemoteServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Refresh Remote Server Refreshes Only The Remote Server", ((string[])(null)));
#line 93
   this.ScenarioSetup(scenarioInfo);
#line 94
 testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.And("I Try DisConnect To Remote Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.When("I Connect To Remote Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
 testRunner.And("I Double Click Localhost Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("I Select Connected RemoteConnectionIntegration From Explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I Refresh Explorer Withpout Waiting For Spinner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.Then("Remote Server Refreshes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
