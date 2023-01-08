using fakestoreapi.test;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace fakestoreapi.test
{

    internal record People(int? PeopleID, string? Name, string? Lastname, string? Company, int? Phone, long? Location);
    public class PeopleTest : IDisposable
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:5001/api")
        };

        public void Dispose()
        {
            _httpClient.DeleteAsync("/").GetAwaiter().GetResult();
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetPeople_ThenTheAPIReturnsExpectedResponse()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var expectedContent = new[]
            {
            new People(1, "COSKUN","SAHIN","THY",744445,10),
                   new People(2, "COSKUN","SAHIN","THY",744445,10),
                             new People(3, "COSKUN","SAHIN","THY",744445,10),
                                       new People(4, "COSKUN","SAHIN","THY",744445,10)

        };
            var stopwatch = Stopwatch.StartNew();

            // Act.
            var response = await _httpClient.GetAsync("/people");

            // Assert.
            await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingPostPeople_ThenTheAPIReturnsExpectedResponseAndAddsBook()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.Created;
            var expectedContent = new People(6, "COSKUN", "SAHIN", "THY", 744445, 10);
            var stopwatch = Stopwatch.StartNew();

            // Act.
            var response = await _httpClient.PostAsync("/people", TestHelpers.GetJsonStringContent(expectedContent));

            // Assert.
            await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingPutPeople_ThenTheAPIReturnsExpectedResponseAndUpdatesBook()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.NoContent;
            var updateproduct = new People(5, "COSKUN", "SAHIN", "THY", 744445, 10);
            var stopwatch = Stopwatch.StartNew();

            // Act.
            var response = await _httpClient.PutAsync("/people", TestHelpers.GetJsonStringContent(updateproduct));

            // Assert.
            //TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingDeletePeople_ThenTheAPIReturnsExpectedResponseAndDeletesBook()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.NoContent;
            var peopleIdToDelete = 10;
            var stopwatch = Stopwatch.StartNew();

            // Act.
            var response = await _httpClient.DeleteAsync($"/people/10");

            // Assert.
            TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
        }

        [Fact]
        public async Task GivenAnAuthenticatedRequest_WhenCallingAdmin_ThenTheAPIReturnsExpectedResponse()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var expectedContent = "Hi admin!";
            var stopwatch = Stopwatch.StartNew();
            var request = new HttpRequestMessage(HttpMethod.Get, "/admin");
            request.Headers.Add("X-Api-Key", "SuperSecretApiKey");

            // Act.
            var response = await _httpClient.SendAsync(request);

            // Assert.
            await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("WrongApiKey")]
        public async Task GivenAnUnauthenticatedRequest_WhenCallingAdmin_ThenTheAPIReturnsUnauthorized(string? apiKey)
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.Unauthorized;
            var stopwatch = Stopwatch.StartNew();
            var request = new HttpRequestMessage(HttpMethod.Get, "/admin");
            request.Headers.Add("X-Api-Key", apiKey);

            // Act.
            var response = await _httpClient.SendAsync(request);

            // Assert.
            TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
        }
    }

}

