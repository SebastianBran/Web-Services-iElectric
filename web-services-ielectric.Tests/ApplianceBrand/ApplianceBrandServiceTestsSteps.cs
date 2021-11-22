﻿using System;
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

namespace web_services_ielectric.Tests.ApplianceBrand
{
    [Binding]
    public class ApplianceBrandServiceTestsSteps:WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response
        {
            get; set;
        }

        public ApplianceBrandServiceTestsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/applianceBrand is available")]
        public void GivenTheEndpointHttpsLocalhostApiVApplianceBrandsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/applianceBrand");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }

        [When(@"A ApplianceBrand Request is sent")]
        public void WhenAApplianceBrandRequestIsSent(Table saveApplianceBrandResource)
        {
            var resource = saveApplianceBrandResource.CreateSet<SaveApplianceBrandResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"A Response with Status (.*) is received for the applianceBrand")]
        public void ThenAResponseWithStatusIsReceivedForTheApplianceBrand(int expectedStatus)
        {
            var statusCode = (HttpStatusCode)expectedStatus;
            Assert.Equal(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}