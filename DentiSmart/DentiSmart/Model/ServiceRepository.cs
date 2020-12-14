using DentiSmart.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSmart.Model
{
    public class ServiceRepository
    {
        public IList<Service> Services { get; set; }

        public ServiceRepository()
        {
            Task.Run(async () => Services = await App.Database.GetServiceAsync()).Wait();
        }

        public IList<Service> GetAll()
        {
            return Services;
        }


    }
}
