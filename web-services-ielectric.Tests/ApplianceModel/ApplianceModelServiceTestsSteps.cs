using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using web_services_ielectric.Resources;
using Xunit;

namespace web_services_ielectric.Tests.ApplianceModel
{
    [Binding]
    public class ApplianceModelServiceTestsSteps:WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response { get; set; }

        public ApplianceModelServiceTestsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/applianceModel is available")]
        public void GivenTheEndpointHttpsLocalhostApiVApplianceModelIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/applianceModel");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"A ApplianceModel Request is sent")]
        public void WhenAApplianceModelRequestIsSent(Table saveApplianceModelResource)
        {
            var resource = saveApplianceModelResource.CreateSet<SaveApplianceModelResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "applicarion/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"A Response with Status (.*) is received for the applianceModel")]
        public void ThenAResponseWithStatusIsReceivedForTheApplianceModel(int expectedStatus)
        {
            var statusCode = (HttpStatusCode) expectedStatus;
            Assert.Equal(statusCode.ToString(),Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}