using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DentiSmart.Model;
using SQLite;

namespace DentiSmart.Data
{
    public class DentistDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public DentistDatabase (string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Service>().Wait();
        }

        public async Task<List<Service>> GetServiceAsync()
        {
            return await database.Table<Service>().ToListAsync();
        }

        public Task<Service> GetServiceAsync (int id)
        {
            return database.Table<Service>()
                .Where(i => i.serviceId == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveServiceAsync(Service item)
        {
            if (item.serviceId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
                
        }

        public Task<int> DeleteServiceAsync(Service item)
        {
            return database.DeleteAsync(item);
        }
    }
}
