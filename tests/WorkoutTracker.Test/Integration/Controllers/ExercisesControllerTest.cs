using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Models.DTOs;
using WorkoutTracker.Models.Entities;
using Xunit;

namespace WorkoutTracker.Test.Integration.Controllers
{
    public class ExercisesControllerTest : BaseControllerTest
    {
        private const string BASE_CONTROLLER_ROUTE = "api/exercises/";

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task GetAll_Ok()
        {
            CreateExercise("test", "test");

            var response = await _client.GetAsync(BASE_CONTROLLER_ROUTE);
            var responseBody = await response.Content.ReadAsStringAsync();

            var retrievedExercises = JsonConvert.DeserializeObject<IEnumerable<ExerciseDto>>(responseBody);

            Assert.Single(retrievedExercises);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task GetById_Ok()
        {
            var createdExercise = CreateExercise("test", "test");

            var response = await _client.GetAsync($"{BASE_CONTROLLER_ROUTE}{createdExercise.Id}");
            var responseBody = await response.Content.ReadAsStringAsync();

            var retrieveExercise = JsonConvert.DeserializeObject<ExerciseDto>(responseBody);

            Assert.Equal(createdExercise.Id, retrieveExercise.Id);
            Assert.Equal(createdExercise.Name, retrieveExercise.Name);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task GetById_NotFound()
        {
            var response = await _client.GetAsync($"{BASE_CONTROLLER_ROUTE}{1}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task GetByName_Ok()
        {
            var createdExercise = CreateExercise("test", "test");

            var response = await _client.GetAsync($"{BASE_CONTROLLER_ROUTE}{createdExercise.Name}");
            var responseBody = await response.Content.ReadAsStringAsync();

            var retrieveExercise = JsonConvert.DeserializeObject<ExerciseDto>(responseBody);

            Assert.Equal(createdExercise.Id, retrieveExercise.Id);
            Assert.Equal(createdExercise.Name, retrieveExercise.Name);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task GetByName_NotFound()
        {
            var response = await _client.GetAsync($"{BASE_CONTROLLER_ROUTE}some_name");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task Add_Success_Created()
        {
            var model = new ExerciseAddDto
            {
                Name = "test name",
                Description = "test description"
            };

            var postContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(BASE_CONTROLLER_ROUTE, postContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task Add_AlreadyExists_Conflict()
        {
            // Seed an exercise
            var name = "test";
            var description = "test";

            var exercise = CreateExercise(name, description);

            // Prepare model for POST
            var model = new ExerciseAddDto
            {
                Name = name,
                Description = description
            };

            var postContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            // POST
            var response = await _client.PostAsync(BASE_CONTROLLER_ROUTE, postContent);

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration.ExercisesController")]
        public async Task Add_InvalidBody_BadRequest()
        {
            // Seed an exercise
            var name = "test";
            var description = "test";

            var exercise = CreateExercise(name, description);

            var postContent = new StringContent(JsonConvert.SerializeObject(new { hello = "world" }), Encoding.UTF8, "application/json");
            // POST
            var response = await _client.PostAsync(BASE_CONTROLLER_ROUTE, postContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private Exercise CreateExercise(string name, string description)
        {
            var exercise = new Exercise {
                Name = name,
                Description = description
            };

            _context.Exercises.Add(exercise);
            _context.SaveChanges();

            return exercise;
        }
    }
}
