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
namespace Dev2.Activities.Specs.BrowserDebug
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class BrowserDebugFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BrowserDebug.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BrowserDebug", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "BrowserDebug")))
            {
                Dev2.Activities.Specs.BrowserDebug.BrowserDebugFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing an empty workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAnEmptyWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing an empty workflow", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
  testRunner.Given("I have a workflow \"BlankWorkflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
  testRunner.When("workflow \"BlankWorkflow\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/BlankWorkflow.debug?\" in" +
                    " Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.Then("The Debug in Browser content contains \"The workflow must have at least one servic" +
                    "e or activity connected to the Start Node.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing a workflow with no inputs and outputs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAWorkflowWithNoInputsAndOutputs()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing a workflow with no inputs and outputs", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
  testRunner.Given("I have a workflow \"NoInputsWorkflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
  testRunner.When("workflow \"NoInputsWorkflow\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/NoInputsWorkflow.debug?\"" +
                    " in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
  testRunner.Then("The Debug in Browser content contains has children with no Inputs and Ouputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Assign workflow with valid inputs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAssignWorkflowWithValidInputs()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Assign workflow with valid inputs", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
  testRunner.Given("I have a workflow \"ValidAssignedVariableWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table1.AddRow(new string[] {
                        "[[dateMonth]]",
                        "February"});
            table1.AddRow(new string[] {
                        "[[dateYear]]",
                        "2017"});
#line 20
  testRunner.And("\"ValidAssignedVariableWF\" contains an Assign \"ValidAssignVariables\" as", ((string)(null)), table1, "And ");
#line 24
  testRunner.When("workflow \"ValidAssignedVariableWF\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/ValidAssignedVariableWF." +
                    "debug?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
  testRunner.Then("The Debug in Browser content contains has \"2\" inputs and \"2\" outputs for \"ValidAs" +
                    "signVariables\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Assign workflow with invalid variable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAssignWorkflowWithInvalidVariable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Assign workflow with invalid variable", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
  testRunner.Given("I have a workflow \"InvalidAssignedVariableWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table2.AddRow(new string[] {
                        "d@teMonth",
                        "February"});
#line 30
  testRunner.And("\"InvalidAssignedVariableWF\" contains an Assign \"InvalidAssignVariables\" as", ((string)(null)), table2, "And ");
#line 33
  testRunner.When("workflow \"InvalidAssignedVariableWF\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/InvalidAssignedVariableW" +
                    "F.debug?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.Then("The Debug in Browser content contains has error messagge \"\"invalid variable assig" +
                    "ned to d@teMonth\"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Hello World workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingHelloWorldWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Hello World workflow", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
  testRunner.Given("I have a workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
  testRunner.And("I Debug \"http://localhost:3142/secure/Hello%20World.debug?Name=Bob\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.Then("The Debug in Browser content contains has \"3\" inputs and \"1\" outputs for \"Decisio" +
                    "n\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
  testRunner.Then("The Debug in Browser content contains has \"1\" inputs and \"1\" outputs for \"Set the" +
                    " output variable (1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Hello World workflow with no Name Input")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingHelloWorldWorkflowWithNoNameInput()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Hello World workflow with no Name Input", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
  testRunner.Given("I have a workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
  testRunner.And("I Debug \"http://localhost:3142/secure/Hello%20World.debug?Name=\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
  testRunner.Then("The Debug in Browser content contains has \"3\" inputs and \"1\" outputs for \"Decisio" +
                    "n\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
  testRunner.Then("The Debug in Browser content contains has \"1\" inputs and \"1\" outputs for \"Set the" +
                    " output variable (1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing a Sequence workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingASequenceWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing a Sequence workflow", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
  testRunner.Given("I have a workflow \"SequenceVariableWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
  testRunner.And("\"SequenceVariableWF\" contains a Sequence \"SequenceFlow\" as", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table3.AddRow(new string[] {
                        "[[dateMonth]]",
                        "February"});
            table3.AddRow(new string[] {
                        "[[dateDay]]",
                        "Thursday"});
#line 52
  testRunner.And("\"SequenceFlow\" contains an Assign \"AssignFlow\" as", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable",
                        "Type"});
            table4.AddRow(new string[] {
                        "[[dateMonth]]",
                        "UPPER"});
            table4.AddRow(new string[] {
                        "[[dateDay]]",
                        "UPPER"});
#line 56
  testRunner.And("\"SequenceFlow\" contains case convert \"CaseConvertFlow\" as", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "In Fields",
                        "Find",
                        "Replace With"});
            table5.AddRow(new string[] {
                        "[[dateDay]]",
                        "THURSDAY",
                        "Friday"});
#line 60
  testRunner.And("\"SequenceFlow\" contains Replace \"ReplaceFlow\" into \"[[replaceResult]]\" as", ((string)(null)), table5, "And ");
#line 63
  testRunner.When("workflow \"SequenceVariableWF\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/SequenceVariableWF.debug" +
                    "?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
  testRunner.Then("The Debug in Browser content contains order of \"AssignFlow\", \"CaseConvertFlow\" an" +
                    "d \"ReplaceFlow\" in SequenceFlow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing a Foreach workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAForeachWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing a Foreach workflow", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
  testRunner.Given("I have a workflow \"ForEachAssigneWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
  testRunner.And("\"ForEachAssigneWF\" contains a Foreach \"ForEachTest\" as \"NumOfExecution\" execution" +
                    "s \"4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table6.AddRow(new string[] {
                        "[[Year]]",
                        "2017"});
#line 70
  testRunner.And("\"ForEachTest\" contains an Assign \"MyAssign\" as", ((string)(null)), table6, "And ");
#line 73
  testRunner.When("workflow \"ForEachAssigneWF\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/ForEachAssigneWF.debug?\"" +
                    " in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
  testRunner.Then("The Debug in Browser content contains the variable assigned executed \"4\" times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing a Dotnet plugin workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingADotnetPluginWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing a Dotnet plugin workflow", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 78
  testRunner.Given("I have a workflow \"DotNetDLLWf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Source",
                        "ClassName",
                        "ObjectName",
                        "Action",
                        "ActionOutputVaribale"});
            table7.AddRow(new string[] {
                        "New DotNet Plugin Source",
                        "TestingDotnetDllCascading.Human",
                        "[[@human]]",
                        "BuildInts",
                        "[[rec1().num]]"});
#line 79
  testRunner.And("\"DotNetDLLWf\" contains an DotNet DLL \"DotNetService\" as", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "parameterName",
                        "value",
                        "type"});
#line 82
  testRunner.And("\"DotNetService\" constructorinputs 0 with inputs as", ((string)(null)), table8, "And ");
#line 84
  testRunner.When("workflow \"DotNetDLLWf\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/DotNetDLLWf.debug?\" in B" +
                    "rowser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
  testRunner.And("The Debug in Browser content contains for Dotnet has 4 states", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
  testRunner.And("The 1 debug state has 1 children", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
  testRunner.And("The 0 debug state has 0 children", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
  testRunner.And("The 2 debug state has 0 children", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
  testRunner.And("The 3 debug state has 0 children", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing a Forward Sort Recordset workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAForwardSortRecordsetWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing a Forward Sort Recordset workflow", ((string[])(null)));
#line 93
this.ScenarioSetup(scenarioInfo);
#line 94
  testRunner.Given("I have a workflow \"SortRecordsetWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table9.AddRow(new string[] {
                        "[[Degree(1).YearCompleted]]",
                        "2015"});
            table9.AddRow(new string[] {
                        "[[Degree(2).YearCompleted]]",
                        "2012"});
            table9.AddRow(new string[] {
                        "[[Degree(3).YearCompleted]]",
                        "2014"});
            table9.AddRow(new string[] {
                        "[[Degree(4).YearCompleted]]",
                        "2013"});
#line 95
  testRunner.And("\"SortRecordsetWF\" contains an Assign \"ExampleRecordSet\" as", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table10.AddRow(new string[] {
                        "[[Degree().YearCompleted]]",
                        "Forward"});
#line 101
  testRunner.And("\"SortRecordsetWF\" contains an Sort \"Degree\" as", ((string)(null)), table10, "And ");
#line 104
  testRunner.And("workflow \"SortRecordsetWF\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
  testRunner.And("I Debug \"http://localhost:3142/secure/Acceptance%20Tests/SortRecordsetWF.debug?\" " +
                    "in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Values"});
            table11.AddRow(new string[] {
                        "2012"});
            table11.AddRow(new string[] {
                        "2013"});
            table11.AddRow(new string[] {
                        "2014"});
            table11.AddRow(new string[] {
                        "2015"});
#line 106
  testRunner.Then("Debugstate in index 2 has output as", ((string)(null)), table11, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Hello Wolrd in a Foreach Looped Three times")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingHelloWolrdInAForeachLoopedThreeTimes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Hello Wolrd in a Foreach Looped Three times", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
