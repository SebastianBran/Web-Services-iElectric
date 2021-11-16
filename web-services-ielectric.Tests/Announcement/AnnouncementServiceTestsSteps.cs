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

namespace web_services_ielectric.Tests.Announcement
{
    [Binding]
    public class AnnouncementServiceTestsSteps : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response
        {
            get; set;
        }

        public AnnouncementServiceTestsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/announcement is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAnnouncementIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/announcement");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }
        
        [When(@"A Announcement Request is sent")]
        public void WhenAAnnouncementRequestIsSent(Table saveAnnouncementResource)
        {
            var resource = saveAnnouncementResource.CreateSet<SaveAnnouncementResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }
        
        [Then(@"A Response with Status (.*) is received for the Announcement")]
        public void ThenAResponseWithStatusIsReceivedForTheAnnouncement(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode)expectedStatus;
            Assert.Equal(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}
