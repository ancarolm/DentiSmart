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
            database.CreateTableAsync<Doctor>().Wait();
            database.CreateTableAsync<UserModel>().Wait();
            database.CreateTableAsync<PersonModel>().Wait();

        }

        public Task<UserModel> GetUserModelAynsc(int id)
        {
            return database.Table<UserModel>()
                            .Where(i => i.UserID == id)
                            .FirstOrDefaultAsync();
        }

        /* SELECT*/
        public Task<List<UserModel>> GetUserModel()
        {
            return database.Table<UserModel>().ToListAsync();
        }

        /*GUARDAR Y ACTUALIZAR ()*/
        public Task<int> SaveUserModelAsync(UserModel userModel)
        {
            if (userModel.UserID != 0)
            {
                return database.UpdateAsync(userModel);
            }
            else
            {
                return database.InsertAsync(userModel);
            }
        }

        /*ELIMINAR () */
        public Task<int> DeleteUserModelAsync(UserModel userModel)
        {
            return database.DeleteAsync(userModel);
        }

        public Task<List<UserModel>> GetUsersValidate(string email, string password)
        {
            return database.QueryAsync<UserModel>("SELECT * FROM UserModel WHERE EmailField = '" + email + "' AND PasswordField = '" + password + "'");
        }




        public Task<PersonModel> GetPersonModelAynsc(int id)
        {
            return database.Table<PersonModel>()
                            .Where(i => i.PersonID == id)
                            .FirstOrDefaultAsync();
        }

        /*SELECT ()*/
        public Task<List<PersonModel>> GetPersonModel()
        {
            return database.Table<PersonModel>().ToListAsync();
        }

        /*GUARDAR Y ACTUALIZAR ()*/
        public Task<int> SavePersonModelAsync(PersonModel personModel)
        {
            if (personModel.PersonID != 0)
            {
                return database.UpdateAsync(personModel);
            }
            else
            {
                return database.InsertAsync(personModel);
            }
        }

        /*ELIMINAR () */
        public Task<int> DeletePersonModelAsync(PersonModel personModel)
        {
            return database.DeleteAsync(personModel);
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

        public async Task<List<Doctor>> GetDoctorAsync()
        {
            return await database.Table<Doctor>().ToListAsync();
        }

        public Task<Doctor> GetDoctorAsync(int id)
        {
            return database.Table<Doctor>()
                .Where(i => i.doctorId == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveDoctorAsync(Doctor item)
        {
            if (item.doctorId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }

        }

        public Task<int> DeleteDoctorAsync(Service item)
        {
            return database.DeleteAsync(item);
        }
    }
}
