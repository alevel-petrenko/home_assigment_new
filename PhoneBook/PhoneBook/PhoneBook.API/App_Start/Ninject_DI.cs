using Logic.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook.API.App_Start
{
    public class Ninject_DI
    {
        public class Ninjectdependencies : NinjectModule
        {
            public override void Load()
            {
                Bind<IContactService_Ns>().To<IContactService_Ns>();
            }
        }

        public static void LoadDependencies ()
        {
            var ninject = new Ninjectdependencies();

            ninject.Load();
        }
    }
}