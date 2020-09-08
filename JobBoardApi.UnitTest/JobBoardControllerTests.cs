using JobBoard.EN.Models;
using JobBoardApi.UnitTest.Utils;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;

namespace JobBoardApi.UnitTest
{
    public class JobBoardControllerTests : IntegrationTest
    {
        public JobBoardControllerTests(ApiWebApplicationFactory fixture)
          : base(fixture) { }

        [Fact]
        public async Task Create_Should_Return_JobEntity()
        {
            var JobEntity = new JobEntity
            {
                JobId = 0,
                Job = "Job 1",
                JobTitle = "Title",
                Description = "Description",
                CreatedAt = DateTime.Now
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseInsert = await _client.PostAsJsonAsync("/api/JobEntity", JobEntity);
            var tupleInserted = await GetEntityResponse<JobEntity>(responseInsert);
            Assert.Equal(HttpStatusCode.OK, tupleInserted.Item1);
            Assert.NotNull(tupleInserted.Item2);


        }

        [Fact]
        public async Task GetAll_Should_Return_JobEntity()
        {

            var response = await _client.GetAsync("/api/JobEntity");
            var tuple = await GetEntityResponse<JobEntity[]>(response);
            Assert.Equal(HttpStatusCode.OK, tuple.Item1);
            Assert.NotNull(tuple.Item2);
        }


        [Fact]
        public async Task GetById_Should_Return_JobEntity()
        {
            var responseGetAll = await _client.GetAsync("/api/JobEntity");
            var tupleGetAll = await GetEntityResponse<JobEntity[]>(responseGetAll);
            var responseGetById = await _client.GetAsync($"/api/JobEntity/{tupleGetAll.Item2[0].JobId}");
            var tupleGetById = await GetEntityResponse<JobEntity>(responseGetById);
            Assert.Equal(HttpStatusCode.OK, tupleGetById.Item1);
            Assert.NotNull(tupleGetById.Item2);
        }

        [Fact]
        public async Task Update_Should_Return_JobEntity()
        {
           await Create_Should_Return_JobEntity();
            var responseGetAll = await _client.GetAsync("/api/JobEntity");
            var tupleGetAll = await GetEntityResponse<JobEntity[]>(responseGetAll);
            var entity = tupleGetAll.Item2[0];
            entity.ExpiresAt = DateTime.Now;
             _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            var responseUpdate = await _client.PutAsJsonAsync("/api/JobEntity",entity);
            var tupleUpdated = await GetEntityResponse<JobEntity>(responseUpdate);
            Assert.Equal(HttpStatusCode.OK, tupleUpdated.Item1);
            Assert.NotNull(tupleUpdated.Item2);
        }

        [Fact]
        public async Task Delete_Should_Return_JobEntity()
        {
            var responseGetAll = await _client.GetAsync("/api/JobEntity");
            var tupleGetAll = await GetEntityResponse<JobEntity[]>(responseGetAll);
            var responseDelete = await _client.DeleteAsync($"/api/JobEntity/{tupleGetAll.Item2[0].JobId}");
            var tupleDeleted = await GetEntityResponse<JobEntity>(responseDelete);
            Assert.Equal(HttpStatusCode.OK, tupleDeleted.Item1);
            Assert.NotNull(tupleDeleted.Item2);
        }

        public async Task<Tuple<HttpStatusCode, T>> GetEntityResponse<T>(HttpResponseMessage response)
        {
            var forecast = JsonConvert.DeserializeObject<T>(
              await response.Content.ReadAsStringAsync()
            );
            return new Tuple<HttpStatusCode, T>(response.StatusCode, forecast);
        }


    }
}
