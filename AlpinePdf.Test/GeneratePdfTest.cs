using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace AlpinePdf.Test
{
    public class GeneratePdfTest : IDisposable
    {
        private readonly HttpClient _client;
        private readonly Environment _env;

        public GeneratePdfTest()
        {
            _client = new HttpClient();
            _env = new Environment();
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }
        
        [Fact]
        public async void SendRequestToController_PdfWasGeneratedSuccessfully()
        {
            // Act
            var result = await _client.GetAsync(_env.ApplicationUrl());

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}