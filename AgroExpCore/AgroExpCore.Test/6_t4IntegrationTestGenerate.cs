﻿


// —————————————— 
// <auto-generated> 
//	This code was auto-generated 01/22/2021 05:38:52
//	T4 template generates test code 
//	NOTE:T4 generated code may need additional updates/addjustments by developer in order to compile a solution.
// <auto-generated> 
// —————————————–
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AgroExpCore.Api;
using AgroExpCore.Domain;
using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using static JWT.Controllers.TokenController;

namespace AgroExpCore.Test
{
	#region unit tests
	#region Company tests

    /// <summary>
    ///
    /// Company API Integration tests
    ///
    /// MANUAL UPDATES REQUIRED!
    ///
    /// NOTE: In order to run an pass these scaffolded tests they have to be manually adjusted 
    ///       according to new entity class properties - search for MANUAL UPDATES REQUIRED!
    ///
    /// </summary>
    [Collection("HttpClient collection")]
    public class CompanyTest: BaseTest
    {
        public HttpClientFixture fixture;
        public CompanyTest(HttpClientFixture fixture)
        {
            this.fixture = fixture;
            var client = fixture.Client;
        }

        public static string LastAddedCompany { get; set; }

        #region Company tests

        [Fact]
        public async Task company_getall()
        {
            var httpclient = fixture.Client;
            if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
            //
            var util = new UtilityExt();
                        //MANUAL UPDATES REQUIRED!
			//todo - add if any parent of the entity
			//add entity
            var companyid = await util.addCompany(httpclient);
            //
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await httpclient.GetAsync("/api/company");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonString = await response.Content.ReadAsStringAsync();
            var vmenititys = (ICollection<UserViewModel>)JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(jsonString);
            Assert.True(vmenititys.Count > 0);
            // lazy-loading test if entity has children
            response = await httpclient.GetAsync("/api/company/" + companyid.ToString());
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonString = await response.Content.ReadAsStringAsync();
            var vmenitity = JsonConvert.DeserializeObject<CompanyViewModel>(jsonString);
            //Assert.True(vmenitity.Kids.Count == 1);
            //clean
            await util.removeCompany(httpclient, companyid);
			//remove if any parent entity added 
        }


        [Fact]
        public async Task company_add_update_delete()
        {
            var httpclient = fixture.Client;;
            if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
            //
            CompanyViewModel company = new CompanyViewModel
            {
			//MANUAL UPDATES REQUIRED!
			TestText = "tt updated"
            };

            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await httpclient.PostAsync("/api/company", new StringContent(
                                                               JsonConvert.SerializeObject(company), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var lastAddedId = await response.Content.ReadAsStringAsync();
            Assert.True(int.Parse(lastAddedId) > 1);
            int id = 0; int.TryParse(lastAddedId, out id);

            //get inserted
            var util = new UtilityExt();
            var vmentity = await util.GetCompany(httpclient, id);

            //update test
            vmentity.TestText = "tt updated";
            response = await httpclient.PutAsync("/api/company/" + id.ToString(), new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            //confirm update
            response = await httpclient.GetAsync("/api/company/" + id.ToString());
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var oj = JObject.Parse(jsonString);
            var tt = oj["testText"].ToString();
            Assert.Equal(tt, vmentity.TestText);

            //another update with same account - concurrency
            vmentity.TestText = "tt updated 2";
            response = await httpclient.PutAsync("/api/company/" + id.ToString(), new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.PreconditionFailed, response.StatusCode);

            //delete test 
            response = await httpclient.DeleteAsync("/api/company/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task company_getbyid()
        {
			var httpclient = fixture.Client;
            if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
            //
            var util = new UtilityExt();
	                //MANUAL UPDATES REQUIRED!
			//todo - add parent of the entity if exist
			//add entity
            var companyid = await util.addCompany(httpclient);
            //
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await httpclient.GetAsync("/api/company/" + companyid.ToString());
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonString = await response.Content.ReadAsStringAsync();
            var vmenitity = JsonConvert.DeserializeObject<CompanyViewModel>(jsonString);
            Assert.True(vmenitity.TestText == "tt updated");
			
            //clean
            await util.removeCompany(httpclient, companyid);
	    //remove if any parent entity added 
        }

        #endregion

        #region Company async tests

        [Fact]
        public async Task company_getallasync()
        {
            var httpclient = fixture.Client;
            if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
            //
            var util = new UtilityExt();
			//MANUAL UPDATES REQUIRED!
			//todo - add parent of the entity if exist
			//add entity
            var companyid = await util.addCompany(httpclient);
            //
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await httpclient.GetAsync("/api/companyasync");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonString = await response.Content.ReadAsStringAsync();
            var vmenititys = (ICollection<UserViewModel>)JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(jsonString);
            Assert.True(vmenititys.Count > 0);
            // lazy-loading test if entity has children
            response = await httpclient.GetAsync("/api/companyasync/" + companyid.ToString());
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonString = await response.Content.ReadAsStringAsync();
            var vmenitity = JsonConvert.DeserializeObject<CompanyViewModel>(jsonString);
            //Assert.True(vmenitity.Kids.Count == 1);
            //clean
            await util.removeCompany(httpclient, companyid);
			//remove if any parent entity added 
        }


        [Fact]
        public async Task company_add_update_delete_async()
        {
            var httpclient = fixture.Client;;
            if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
            //
            CompanyViewModel company = new CompanyViewModel
            {
			//MANUAL UPDATES REQUIRED!
			//initiate viewmodel object
			TestText = "tt updated"
            };

            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await httpclient.PostAsync("/api/companyasync", new StringContent(
                                                               JsonConvert.SerializeObject(company), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var lastAddedId = await response.Content.ReadAsStringAsync();
            Assert.True(int.Parse(lastAddedId) > 1);
            int id = 0; int.TryParse(lastAddedId, out id);

            //get inserted
            var util = new UtilityExt();
            var vmentity = await util.GetCompany(httpclient, id);

            //update test
            vmentity.TestText = "tt updated";
            response = await httpclient.PutAsync("/api/companyasync/" + id.ToString(), new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            //confirm update
            response = await httpclient.GetAsync("/api/companyasync/" + id.ToString());
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var oj = JObject.Parse(jsonString);
            var tt = oj["testText"].ToString();
            Assert.Equal(tt, vmentity.TestText);

            //another update with same account - concurrency
            vmentity.TestText = "tt updated 2";
            response = await httpclient.PutAsync("/api/companyasync/" + id.ToString(), new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.PreconditionFailed, response.StatusCode);

            //delete test 
            response = await httpclient.DeleteAsync("/api/companyasync/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        }

        [Fact]
        public async Task company_getbyidasync()
        {

			var httpclient = fixture.Client;
            if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
            //
            var util = new UtilityExt();
			//MANUAL UPDATES REQUIRED!
			//todo - add if any parent of the entity
			//add entity
            var companyid = await util.addCompany(httpclient);
            //
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await httpclient.GetAsync("/api/companyasync/" + companyid.ToString());
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonString = await response.Content.ReadAsStringAsync();
            var vmenitity = JsonConvert.DeserializeObject<CompanyViewModel>(jsonString);
            Assert.True(vmenitity.TestText == "tt updated");
			
            //clean
            await util.removeCompany(httpclient, companyid);
	    //remove if any parent entity added 
        }

        #endregion
	}
        #endregion

    #endregion

    #region Shared test

    public class UtilityExt
    {

        public async Task<int> addCompany(HttpClient client)
        {
		    
            CompanyViewModel vmentity = new CompanyViewModel
            {
			//MANUAL UPDATES REQUIRED!
			//initiate viewmodel object
			TestText = "tt updated"
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await client.PostAsync("/api/company", new StringContent(
                                                               JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
            var jsonString = await response.Content.ReadAsStringAsync();
            int lastAdded = 0;
            int.TryParse(jsonString, out lastAdded);
            return lastAdded;
        }
        public async Task<CompanyViewModel> GetCompany(HttpClient client, int id)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
            var response = await client.GetAsync("/api/companyasync/" + id.ToString());
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var vmentity = JsonConvert.DeserializeObject<CompanyViewModel>(jsonString);
            return vmentity;
        }
        public async Task removeCompany(HttpClient client, int id)
        {
            await client.DeleteAsync("/api/company/" + id.ToString());
        }

	}
	 #endregion
}
