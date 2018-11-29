using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.DataModels;
using ShopData;

namespace BussinesLogic.Service
{
    public interface IClientService
    {
        int Add(Client client);
    }

    class ClientService : IClientService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(Client client)
        {
            _uOW.eFClientRepository.Add(client);

            _uOW.Save();

            return client.Id;
        }
    }
}
