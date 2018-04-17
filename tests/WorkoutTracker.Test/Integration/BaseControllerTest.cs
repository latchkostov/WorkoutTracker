using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Net.Http.Headers;
using WorkoutTracker.Infra;

namespace WorkoutTracker.Test.Integration
{
    public abstract class BaseControllerTest
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;
        protected WorkoutTrackerContext _context;

        public BaseControllerTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());
            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            _context = _server.Host.Services.GetService(typeof(WorkoutTrackerContext)) as WorkoutTrackerContext;
            _context.Database.EnsureCreated();
        }
    }
}
