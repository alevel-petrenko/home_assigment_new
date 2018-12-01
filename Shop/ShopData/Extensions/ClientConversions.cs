using ShopData.DataModels;
using ShopData.DTO__BusinessModels_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Extensions
{
    public static class ClientConversions
    {
        public static ClientDTO to_DTOModel (this Client client)
        {
            if (client == null)
            {
                return null;
            }

            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name
            };
        }

        public static Client to_SQLModel(this ClientDTO clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }

            return new Client
            {
                Id = clientDto.Id,
                Name = clientDto.Name
            };
        }
    }
}
