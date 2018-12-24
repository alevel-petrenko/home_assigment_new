using ShopData.DataModels;
using ShopData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Factory
{
    public static class ClientSimpleFactory
    {
        static ClientSimpleFactory()
        {
            _clients.Add(1, new ShortTermClient());
            _clients.Add(2, new LongTermClient());
        }

        private static Dictionary<int, Client> _clients = new Dictionary<int, Client>();

        public static Client CreateClient(int type)
        {
            var client = _clients[type];
            return client;
        }
    }
}
