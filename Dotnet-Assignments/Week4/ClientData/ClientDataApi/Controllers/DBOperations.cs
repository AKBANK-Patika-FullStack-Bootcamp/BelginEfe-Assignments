using DAL.Models;
using Entities;
using System.Linq;

namespace ClientDataApi.Controllers
{
    public class DBOperations
    {
        private ClientContext _context = new ClientContext();
        public LoggerController loggerDB = new LoggerController();


        /// <summary>
        /// Adds new client to list
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>

        public bool AddModel(ClientData client)
        {
            try
            {
                _context.Client.Add(client);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                loggerDB.CreateLog("HATA" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get client list
        /// </summary>
        /// <returns></returns>

        public List<ClientData> GetAllClientsFromDB()
        {
            List<ClientData> _clients = new List<ClientData>();
            _clients = _context.Client.OrderBy(x => x.Id).ToList();
            return _clients;
        }

        internal static ClientData? FindClient(string? name, string? lastname, int? id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Deletes client by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool deleteClient(int Id)
        {
            try
            {
                _context.Client.Remove(FindClient("", "", Id));
                _context.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                loggerDB.CreateLog("HATA" + ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Update clientData by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="client"></param>
        /// <returns></returns>

        public bool UpdateClientById(int Id, ClientData client)
        {
            var currentClient = _context.Client.FirstOrDefault(client => client.Id == Id);
            if (currentClient == null)
            {
                return false;
            }
            else
            {
                currentClient.Name = client.Name;
                currentClient.Lastname = client.Lastname;
                currentClient.GenderId = client.GenderId;
                currentClient.isActive = client.isActive;
                currentClient.Birthday = client.Birthday;
                _context.SaveChanges();
                return true;
            }
        }

        public ClientData FindClient(string Name = "", string Lastname = "", int Id = 0)
        {
            ClientData? client = new ClientData();
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Lastname))
               {
                client = _context.Client.FirstOrDefault(client => client.Name == Name && client.Lastname == Lastname);
            }

            else if (Id > 0)
            {
                client = _context.Client.FirstOrDefault(client => client.Id == Id);
            }

            return client;
        }

    }
