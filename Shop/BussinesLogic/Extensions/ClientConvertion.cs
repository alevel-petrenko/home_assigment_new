using BussinesLogic.Model;
using ShopData.DTO__BusinessModels_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Extensions
{
    public static class ClientConvertion
    {
        public static ClientViewModel toViewModel (this ClientDTO clientDTO)
        {
            if (clientDTO == null)
            {
                return null;
            }

            return new ClientViewModel
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name
            };
        }

        public static ClientDTO toDTOModel(this ClientViewModel clientView)
        {
            if (clientView == null)
            {
                return null;
            }

            return new ClientDTO
            {
                Name = clientView.Name,
                Id = clientView.Id
            };
        }
    }
}

//задача: Как не делать двойную конвертацию? use genetic methods