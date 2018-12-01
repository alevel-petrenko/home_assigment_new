using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.DataModels;
using ShopData;
using ShopData.DTO__BusinessModels_;
using ShopData.Extensions;

namespace BussinesLogic.Service
{
    public interface IClientService
    {
        int Add(ClientDTO clientDTO);
        void Delete(int id);
        void Update(ClientDTO clientDTO);
        List<ClientDTO> GetAll();
        ClientDTO Get(int id);
    }

    public class ClientService : IClientService
    {
        private UnitOfWorkClient _uOW = new UnitOfWorkClient();

        public int Add(ClientDTO clientDTO)
        {
            var client = clientDTO.to_SQLModel();
            _uOW.eFClientRepository.Add(client);
            _uOW.Save();

            return client.Id;
        }

        public void Delete(int id)
        {
            _uOW.eFClientRepository.Delete(id);
            _uOW.Save();
        }

        public ClientDTO Get(int id)
        {
            return _uOW.eFClientRepository.Get(id).to_DTOModel();
        }

        public List<ClientDTO> GetAll()
        {
            return _uOW.eFClientRepository.GetAll().Select(a => a.to_DTOModel()).ToList();
        }

        public void Update(ClientDTO clientDTO)
        {
            var client = clientDTO.to_SQLModel();
            
        }
    }
}
