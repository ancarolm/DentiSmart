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

        public IList<Service> GetAllByFirstLetter(string letter)
        {
            var query = from q in Services
                        where q.Name.StartsWith(letter)
                        select q;
            return query.ToList();
        }

        public
                    ObservableCollection
                    <Grouping<string, Service>>
                    GetAllGrouped()
        {
            IEnumerable<Grouping<string, Service>> sorted = new Grouping<string, Service>[0];
            if (Services != null)
            {
                sorted =
                    from f in Services
                    orderby f.Name
                    group f by f.Name[0].ToString()
                    into theGroup
                    select
                    new Grouping<string, Service>
                        (theGroup.Key, theGroup);
            }


            return new
                ObservableCollection
                <Grouping<string, Service>>(sorted);
        }

    }
}
