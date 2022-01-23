using DAL.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClientDataApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientDataController : ControllerBase
    {
       /* private static List<ClientData> ClientDatas = new List<ClientData>()
        {
            new ClientData
            {
                Id = 1,
                Name = "Melis",
                Lastname = "Kızmaz",
                GenderId = 1,
                Birthday = new DateTime(1983, 06, 01),

            },

            new ClientData
            {
                Id = 2,
                Name = "Kübra",
                Lastname = "İlkgün",
                GenderId = 1,
                Birthday = new DateTime(1996, 03, 24),
                isActive = "false",
            },

            new ClientData
            {
                Id = 3,
                Name = "Kadir",
                Lastname = "Küneci",
                GenderId = 2,
                Birthday = new DateTime(1987, 11, 30)
            },

            new ClientData
            {
                Id = 4,
                Name = "Mehmet",
                Lastname = "Kargı",
                GenderId = 2,
                Birthday = new DateTime(1991, 09, 08),
                isActive = "false",

            },

            new ClientData
            {
                Id = 5,
                Name = "Bahar Deniz",
                Lastname = "Yaylacı",
                GenderId = 1,
                Birthday = new DateTime(2001, 04, 04)
            },
        };*/

        public Result result = new Result();

        public LoggerController logger = new LoggerController();
        public DBOperations clientdbOperations = new DBOperations();



        // <return> returns all client datas </return>

        [HttpGet]
        public List<ClientData> GetAllClients()

        {
            
           return clientdbOperations.GetAllClients();
        }

        // <return> returns particular client's data according to id </return>

        [HttpGet("{id}")]

        public ClientData GetClientById(int id)

        {
            var Client = ClientDatas.Where(client => client.Id == id).FirstOrDefault();
            return Client;
        }

        // POST api/<ClientDataController>

        [HttpPost]

        public Result AddNewClient([FromBody] ClientData newClient)

        {
            var client = ClientDatas.Where(client => client.Id == newClient.Id).FirstOrDefault();

            if (client is not null)
            {
                result.status = 0;
                result.message = "Kullanıcı id mevcut";
            }

            else if (client is null)
            {
                result.status = 1;
                result.message = "Kullanıcı başarıyla eklendi";
            }

            return result;

        }

        // updates client and keeps existing information which is not updated

        [HttpPut]

        public Result UpdateClient([FromBody] ClientData UpdateClient)

        {
            var Client = ClientDatas.SingleOrDefault(client => client.Id == UpdateClient.Id);

            if (Client is null)

            {
                result.status = 0;
                result.message = "Kullanıcı bilgileri bulunamadı";
            }

            else if (Client is not null)

            {

                Client.Name = UpdateClient.Name != default ? UpdateClient.Name : Client.Name;
                Client.Lastname = UpdateClient.Lastname != default ? UpdateClient.Lastname : Client.Lastname;
                Client.GenderId = UpdateClient.GenderId != default ? UpdateClient.GenderId : Client.GenderId;
                Client.isActive = UpdateClient.isActive != default ? UpdateClient.isActive : Client.isActive;
                Client.Birthday = UpdateClient.Birthday != default ? UpdateClient.Birthday : Client.Birthday;

                result.status = 1;
                result.message = "Kullanıcı bilgileri başarı ile güncellendi";
            }

            return result;
        }

        // deletes a particular client according to client's id

        [HttpDelete("{id}")]

        public Result DeleteClient(int id)

        {
            var Client = ClientDatas.SingleOrDefault(client => client.Id == id);

            try
            {
                if (Client is null)
                {
                    result.status = 0;
                    result.message = "Kullanıcı bilgileri bulunamadı";
                    logger.CreateLog(id + " id numaralı " + result.message);
                }

                else if (Client is not null)
                {
                    ClientDatas.Remove(Client);

                    result.status = 1;
                    result.message = "Kullanıcı başarı ile silindi";
                    logger.CreateLog(Client.Id + " id numaralı " + result.message);
                }
            }

            catch (Exception ex)
            {
                logger.CreateLog(ex.StackTrace);
            }

            return result;
            
        }

    }
}
