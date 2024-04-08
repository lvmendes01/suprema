using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suprema.WebApiTests.Controllers
{
    public class ApiBaseTeste
    {
        public HttpClient _client;


        public ApiBaseTeste()
        { 
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7214"); 
        }
    }
}
