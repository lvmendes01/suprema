using System.Net.Http.Json;
using System.Text;

namespace Suprema.Testes
{
    [TestFixture]
    public class Tests
    {


        private HttpClient _client;


        [SetUp]
        public void Setup()
        { // Configuração do cliente HTTP para testar a API
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7214"); // URL da sua API
        
        }

      


        [Test]
        public async Task criando_user()
        {
            string postUsuario = "{\r\n  \"id\": 0,\r\n  \"dataCadastro\": \"2024-04-08T14:09:46.330Z\",\r\n  \"name\": \"string\",\r\n  \"cpf\": \"string\",\r\n  \"phone\": \"string\",\r\n  \"password\": \"string\",\r\n  \"username\": \"string\"\r\n}";

            StringContent content = new StringContent(postUsuario, Encoding.UTF8, "application/json");

            // Enviando a solicitação POST para a API
            HttpResponseMessage response = await _client.PostAsync("/users", content);



                // Lendo o conteúdo da resposta
                string responseBody = await response.Content.ReadAsStringAsync();

                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
           

        }

        [Test]
        public void criando_mesa()
        {
            Assert.Pass();
        }

        [Test]
        public void incluindo_user_mesa_com_erro()
        {
            Assert.Pass();
        }

        [Test]
        public void incluindo_user_mesa_com_sucesso()
        {
            Assert.Pass();
        }

        [Test]
        public void sorteando_vencedor_na_mesa()
        {
            Assert.Pass();
        }
    }
}