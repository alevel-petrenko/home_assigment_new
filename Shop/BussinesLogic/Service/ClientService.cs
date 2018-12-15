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
        bool Validate(string name);

        int Add(ClientDTO clientDTO);
        void Delete(int id);
        void Update(ClientDTO clientDTO);
        List<ClientDTO> GetAll();
        ClientDTO Get(int id);

        List<ClientDTO> GetLimited(int number);

        List<ClientDTO> Serch(string name);
    }

    public class ClientService : IClientService
    {
        private UnitOfWork _uOW;

        public ClientService(UnitOfWork uoW)
        {
            _uOW = uoW;
        }

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

        public virtual ClientDTO Get(int id)
        {
            return _uOW.EFClientRepository.Get(id).to_DTOModel();
        }

        public virtual List<ClientDTO> GetAll()
        {
            return _uOW.EFClientRepository.GetAll()
                .Select(a => a.to_DTOModel()).ToList();
        }

        public List<ClientDTO> GetLimited(int number)
        {

            var clients = _uOW.EFClientRepository.GetAll();

            if (number > clients.Count)
                throw new ArgumentException("Number");

            return clients.Select(c => c.to_DTOModel()).Take(number).ToList();
        }

        public List<ClientDTO> Serch(string name)
        {
            var list = _uOW.EFClientRepository.GetAll();

            return list.Where(o => o.Name.Contains(name))
                .Select(y => y.to_DTOModel()).ToList();
        }

        public void Update(ClientDTO clientDTO)
        {
            var client = clientDTO.to_SQLModel();
        }

        public bool Validate(string name)
        {
            return !_uOW.EFClientRepository
                .GetAll()
                .Any(c => c.Name.ToLower() == name.ToLower());
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

        public List<ClientDTO> GetLimited(int number)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTO> Serch(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string name)
        {
            throw new NotImplementedException();
        }
    }
}
