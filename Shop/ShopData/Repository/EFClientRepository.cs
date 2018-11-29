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
            _context.Clients.Remove(_context.Clients.FirstOrDefault(a => a.Id == id));
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
