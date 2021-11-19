using System.Net.Http;
using TechTalk.SpecFlow;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow.Assist;
using web_services_ielectric.Resources;
using System.Linq;
using SpecFlow.Internal.Json;
using System.Text;
using System.Net;
using Xunit;

namespace web_services_ielectric.Tests.Plan
{
    [Binding]
    public class PlanServiceTestsSteps : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response
        {
            get; set;
        }

        public PlanServiceTestsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/plans is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPlansIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/plans");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }
        
        [When(@"A Plan Request is sent")]
        public void WhenAPlanRequestIsSent(Table savePlanResource)
        {
            var resource = savePlanResource.CreateSet<SavePlanResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }
        
        [Then(@"A Response with Status (.*) is received for the plan")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode)expectedStatus;
            Assert.Equal(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}
