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

namespace web_services_ielectric.Tests
{
    [Binding]
    public class ClientServiceTestsSteps : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response {
            get; set; 
        }

        public ClientServiceTestsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/clients is available")]
        public void GivenTheEndpointHttpsLocalhostApiVClientsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/clients");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }
        
        [When(@"A Client Request is sent")]
        public void WhenAClientRequestIsSent(Table saveClientResource)
        {
            var resource = saveClientResource.CreateSet<SaveClientResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }
        
        [Then(@"A Response with Status (.*) is received for the client")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode)expectedStatus;
            Assert.Equal(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}
