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
    public class PokerTableControllerTests : ApiBaseTeste
    {
        [TestMethod()]
        public async Task SalvarTestAsync()
        {

            string postUsuario = "{\r\n  \"id\": 0,\r\n  \"dataCadastro\": \"2024-04-08T14:09:46.330Z\",\r\n  \"name\": \"string\",\r\n  \"cpf\": \"string\",\r\n  \"phone\": \"string\",\r\n  \"password\": \"string\",\r\n  \"username\": \"string\"\r\n}";

            StringContent content = new StringContent(postUsuario, Encoding.UTF8, "application/json");

            // Enviando a solicitação POST para a API
            HttpResponseMessage response = await _client.PostAsync("/users", content);



            // Lendo o conteúdo da resposta
            string responseBody = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);


            Assert.Fail();
            Assert.Fail();
        }

        [TestMethod()]
        public async void IncluirJogadorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async void GanhadorTest()
        {
            Assert.Fail();
        }
    }
}