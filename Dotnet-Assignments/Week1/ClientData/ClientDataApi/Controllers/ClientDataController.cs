using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClientDataApi.Models;
using System.Linq;

namespace ClientDataApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientDataController : ControllerBase
    {
        private static List<ClientData> ClientDatas = new List<ClientData>()
        {
            new ClientData
            {
                Id = 1,
                Name = "Melis",
                LastName = "Kızmaz",
                GenderId = 1,
                Birthday = new DateTime(1983, 06, 01),

            },

            new ClientData
            {
                Id = 2,
                Name = "Kübra",
                LastName = "İlkgün",
                GenderId = 1,
                Birthday = new DateTime(1996, 03, 24),
                isActive = false,
            },

            new ClientData
            {
                Id = 3,
                Name = "Kadir",
                LastName = "Küneci",
                GenderId = 2,
                Birthday = new DateTime(1987, 11, 30)
            },

            new ClientData
            {
                Id = 4,
                Name = "Mehmet",
                LastName = "Kargı",
                GenderId = 2,
                Birthday = new DateTime(1991, 09, 08),
                isActive = false,

            },

            new ClientData
            {
                Id = 5,
                Name = "Bahar Deniz",
                LastName = "Yaylacı",
                GenderId = 1,
                Birthday = new DateTime(2001, 04, 04)
            },
        };


        // <return> returns all client datas </return>

        [HttpGet]
        public List<ClientData> GetAllClients()

        {
            var ClientList = ClientDatas.OrderBy(x => x.Id).ToList<ClientData>();
            return ClientList;
        }

        // <return> returns particular client's data according to id </return>

        [HttpGet("{id}")]

        public ClientData GetClientById(int id)

        {
            var Client = ClientDatas.Where(client => client.Id == id).FirstOrDefault();
            return Client;
        }

        // adds new client to the list

        [HttpPost]

        public IActionResult AddNewClient([FromBody] ClientData newClient)

        {
            var Client = ClientDatas.SingleOrDefault(client => client.Id == newClient.Id);

            if (Client is not null) return BadRequest();

            ClientDatas.Add(newClient);

            return Ok();

        }

        // updates client and keeps existing information which is not updated

        [HttpPut("{id}")]

        public IActionResult UpdateClient(int id, [FromBody] ClientData UpdateClient)

        {
            var Client = ClientDatas.SingleOrDefault(client => client.Id == id);

            if (Client is null) return BadRequest();

            Client.Name = UpdateClient.Name != default ? UpdateClient.Name : Client.Name;
            Client.LastName = UpdateClient.LastName != default ? UpdateClient.LastName : Client.LastName;
            Client.GenderId = UpdateClient.GenderId != default ? UpdateClient.GenderId : Client.GenderId;
            Client.isActive = UpdateClient.isActive != default ? UpdateClient.isActive : Client.isActive;
            Client.Birthday = UpdateClient.Birthday != default ? UpdateClient.Birthday : Client.Birthday;

            return Ok();
        }

        // deletes a particular client according to client's id

        [HttpDelete("{id}")]

        public IActionResult DeleteClient(int id)

        {
            var Client = ClientDatas.SingleOrDefault(client => client.Id == id);

            if (Client is null) return BadRequest();

            ClientDatas.Remove(Client);
            return Ok();
        }

    }
}