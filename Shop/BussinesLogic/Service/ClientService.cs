using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.DataModels;
using ShopData;
using ShopData.DTO__BusinessModels_;
using ShopData.Extensions;
using BussinesLogic.Model;

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
            _uOW.EFClientRepository.Add(client);
            _uOW.Save();

            return client.Id;
        }

        public void Delete(int id)
        {
            var client = Get(id);

            client.IsDeleted = true;
            _uOW.Save();
        }

        public ClientDTO Get(int id)
        {
            return _uOW.EFClientRepository.Get(id).to_DTOModel();
        }

        public List<ClientDTO> GetAll()
        {
            return _uOW.EFClientRepository.GetAll().Select(a => a.to_DTOModel()).ToList();
        }

        public void Update(ClientDTO clientDTO)
        {
            var client = clientDTO.to_SQLModel();
        }
    }

    public class ClientServiceMock : IClientService
    {
        public int Add(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClientDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTO> GetAll()
        {
            return new List<ClientDTO>
            {
                new ClientDTO
                {
                    Id = 100,
                    Name = "LuckyOne Mocked"
                }
            };
        }

        public void Update(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }
    }
}
