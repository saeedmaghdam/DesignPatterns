﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ChainOfResponsibility.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class HandlingRequestsUsingChainOfResponsibilityFeature : object, Xunit.IClassFixture<HandlingRequestsUsingChainOfResponsibilityFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "HandlingDifferentTypesOfRequests.feature"
#line hidden
        
        public HandlingRequestsUsingChainOfResponsibilityFeature(HandlingRequestsUsingChainOfResponsibilityFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Handling Requests Using Chain of Responsibility", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            string testWorkerId = testRunner.TestWorkerId;
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
            global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.ReleaseWorker(testWorkerId);
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Handle a request with the first handler in the chain")]
        [Xunit.TraitAttribute("FeatureTitle", "Handling Requests Using Chain of Responsibility")]
        [Xunit.TraitAttribute("Description", "Handle a request with the first handler in the chain")]
        public async System.Threading.Tasks.Task HandleARequestWithTheFirstHandlerInTheChain()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Handle a request with the first handler in the chain", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 3
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
    await testRunner.GivenAsync("a chain consisting of a Validator, Authorizer, and Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 5
    await testRunner.AndAsync("the Validator can handle the request", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 6
    await testRunner.WhenAsync("the request \"Validate data\" is received", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 7
    await testRunner.ThenAsync("the request should be handled by the Validator", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 8
    await testRunner.AndAsync("the request should not proceed to the Authorizer", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 9
    await testRunner.AndAsync("the request should not proceed to the Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Pass the request to the next handler if the first handler cannot handle it")]
        [Xunit.TraitAttribute("FeatureTitle", "Handling Requests Using Chain of Responsibility")]
        [Xunit.TraitAttribute("Description", "Pass the request to the next handler if the first handler cannot handle it")]
        public async System.Threading.Tasks.Task PassTheRequestToTheNextHandlerIfTheFirstHandlerCannotHandleIt()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Pass the request to the next handler if the first handler cannot handle it", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 12
    await testRunner.GivenAsync("a chain consisting of a Validator, Authorizer, and Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 13
    await testRunner.AndAsync("the Validator cannot handle the request", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 14
    await testRunner.AndAsync("the Authorizer can handle the request", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 15
    await testRunner.WhenAsync("the request \"Authorize user\" is received", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 16
    await testRunner.ThenAsync("the request should be handled by the Authorizer", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 17
    await testRunner.AndAsync("the request should not proceed to the Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Process request if no prior handler can handle it")]
        [Xunit.TraitAttribute("FeatureTitle", "Handling Requests Using Chain of Responsibility")]
        [Xunit.TraitAttribute("Description", "Process request if no prior handler can handle it")]
        public async System.Threading.Tasks.Task ProcessRequestIfNoPriorHandlerCanHandleIt()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Process request if no prior handler can handle it", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 19
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 20
    await testRunner.GivenAsync("a chain consisting of a Validator, Authorizer, and Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 21
    await testRunner.AndAsync("the Validator cannot handle the request", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 22
    await testRunner.AndAsync("the Authorizer cannot handle the request", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 23
    await testRunner.AndAsync("the Processor can handle the request", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 24
    await testRunner.WhenAsync("the request \"Process data\" is received", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 25
    await testRunner.ThenAsync("the request should be handled by the Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Reject request if no handler can handle it")]
        [Xunit.TraitAttribute("FeatureTitle", "Handling Requests Using Chain of Responsibility")]
        [Xunit.TraitAttribute("Description", "Reject request if no handler can handle it")]
        public async System.Threading.Tasks.Task RejectRequestIfNoHandlerCanHandleIt()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Reject request if no handler can handle it", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 28
    await testRunner.GivenAsync("a chain consisting of a Validator, Authorizer, and Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 29
    await testRunner.AndAsync("no handler can handle the request", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 30
    await testRunner.WhenAsync("the request \"Unsupported operation\" is received", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 31
    await testRunner.ThenAsync("the request should be rejected", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Successfully pass through multiple handlers")]
        [Xunit.TraitAttribute("FeatureTitle", "Handling Requests Using Chain of Responsibility")]
        [Xunit.TraitAttribute("Description", "Successfully pass through multiple handlers")]
        public async System.Threading.Tasks.Task SuccessfullyPassThroughMultipleHandlers()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Successfully pass through multiple handlers", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 34
    await testRunner.GivenAsync("a chain consisting of a Validator, Authorizer, and Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 35
    await testRunner.AndAsync("the Validator can partially handle the request \"Complete transaction\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 36
    await testRunner.AndAsync("the Authorizer can partially handle the request \"Complete transaction\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 37
    await testRunner.AndAsync("the Processor can fully handle the request \"Complete transaction\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 38
    await testRunner.WhenAsync("the request \"Complete transaction\" is received", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 39
    await testRunner.ThenAsync("the request should be handled first by the Validator", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 40
    await testRunner.AndAsync("then the request should be passed to the Authorizer", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 41
    await testRunner.AndAsync("finally, the request should be handled by the Processor", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await HandlingRequestsUsingChainOfResponsibilityFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await HandlingRequestsUsingChainOfResponsibilityFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
