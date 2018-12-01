using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Repository
{
    public class EFClientRepository : IClientRepository
    {
        public EFClientRepository(ShopDataModel context)
        {
            _context = context;
        }

        private ShopDataModel _context;

        public int Add(Client client)
        {
            _context.Clients.Add(client);
            return client.Id;
        }

        public void Delete(int id)
        {
            var client = Get(id);
                client.IsDeleted = true;
        }

        public Client Get(int id)
        {
            return _context.Clients.FirstOrDefault(a => a.Id == id);
        }

        public List<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public void Update(Client client)
        {
            var oldClient = Get(client.Id);
            oldClient.Name = client.Name;
        }
    }
}
