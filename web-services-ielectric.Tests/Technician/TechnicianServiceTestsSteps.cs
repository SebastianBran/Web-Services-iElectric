using Microsoft.AspNetCore.Mvc.Testing;
using SpecFlow.Internal.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using web_services_ielectric.Resources;
using Xunit;

namespace web_services_ielectric.Tests.Technician
{
    [Binding]
    public class TechnicianServiceTestsSteps : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response
        {
            get; set;
        }

        public TechnicianServiceTestsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/technicians is available")]
        public void GivenTheEndpointHttpsLocalhostApiVTechniciansIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/technicians");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }
        
        [When(@"A Technician Request is sent")]
        public void WhenATechnicianRequestIsSent(Table saveTechnicianResource)
        {
            var resource = saveTechnicianResource.CreateSet<SaveTechnicianResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"A Response with Status (.*) is received for the technician")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode)expectedStatus;
            Assert.Equal(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}
