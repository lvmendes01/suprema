using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suprema.WebApi.Controllers;
using Suprema.WebApiTests.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suprema.WebApi.Controllers.Tests
{
    [TestClass()]
    public class AuthControllerTests : ApiBaseTeste
    {
        [TestMethod()]
        public async Task loginTestAsync()
        {
     
            string post = "{\r\n  \"username\": sadsd,\r\n  \"password\": \"sdsds\",\r\n }";

            StringContent content = new StringContent(post, Encoding.UTF8, "application/json");

            // Enviando a solicitação POST para a API
            HttpResponseMessage response = await _client.PostAsync("/auth/login", content);



            // Lendo o conteúdo da resposta
            string responseBody = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);


            Assert.Fail();
        }
    }
}