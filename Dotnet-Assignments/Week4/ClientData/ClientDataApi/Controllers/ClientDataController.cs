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

        public Result result = new Result();

        public LoggerController logger = new LoggerController();
        public DBOperations clientdbOperations = new DBOperations();



        // <return> returns all client datas </return>

        [HttpGet]
        public List<ClientData> GetAllClients()

        {
            
           return clientdbOperations.GetAllClientsFromDB();
        }

        // <return> returns particular client's data according to id </return>

        [HttpGet("{id}")]

        public ClientData GetClientById(int id)

        {
            ClientData resultClient = DBOperations.FindClient("", "", id);
            return resultClient;
        }

        /// <summary>
        /// Add new Client to the Clientslist
        /// </summary>
        /// <param name="newClient"></param>
        /// <returns></returns>

        [HttpPost]

        public Result AddNewClient(ClientData newClient)

        {
            ClientData? newC = DBOperations.FindClient(newClient.Name, newClient.Lastname, newClient.Id);
            bool clientCheck = (newC != null) ? true : false;

            if (clientCheck == false)
            {
                if(clientdbOperations.AddModel(newClient) == true)

                {
                    result.status = 1;
                    result.message = "Yeni müşteri listeye eklendi";
                }

                else
                {
                    result.status = 0;
                    result.message = "Müşteri listeye eklenemiyor";
                }
            }
            else
            {
                result.status = 0;
                result.message = "Müşteri zaten listede mevcut";
            }
            

            return result;



        }

        /// <summary>
        /// Update client by Id
        /// </summary>
        /// <param name="UpdateClient"></param>
        /// <returns></returns>

        [HttpPut("{Id}")]

        public Result UpdateClient(int Id, ClientData newValue)

        {
            bool clientCheck = clientdbOperations.UpdateClientById(Id: Id, client: newValue);
            if (clientCheck == true)
            {
                result.status= 1;
                result.message = "Güncelleme işlemi başarıyla tamamlandı";
            }
            else
            {
                result.status = 0;
                result.message = "Müşteri bilgileri bulunamadı";
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        public Result DeleteClient(int id)

        {
            if (clientdbOperations.deleteClient(id))
            {

                result.status = 1;
                result.message = "Müşteri başarı ile silindi";
            }
            else
            {
                result.status = 0;
                result.message = "Müşteri bilgileri bulunamadı";
            }

            return result;
            
        }

    }
}
