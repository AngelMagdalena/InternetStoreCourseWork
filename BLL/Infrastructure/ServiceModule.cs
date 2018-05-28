using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DAL;
using DAL.EF.Interfaces;

namespace BLL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private string connectString;

        public ServiceModule() { }

        public ServiceModule(string connectStr)
        {
            connectString = connectStr;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectString);
        }

    }
}
