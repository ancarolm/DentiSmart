using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using DentiSmart.Model;

namespace DentiSmart.Data
{
    public class DatabaseQuerys
    {
        #region Creacion - Tabla - DbPath 
        readonly SQLiteAsyncConnection _database;

        public DatabaseQuerys(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);


            #region Creacion - Tablas

            _database.CreateTableAsync<UserModel>().Wait();
            _database.CreateTableAsync<PersonModel>().Wait();
            #endregion
        }

        #endregion


        #region CRUD - USER TABLE

        /* SELECT SEARCH BAR*/
        public Task<UserModel> GetUserModelAynsc(int id)
        {
            return _database.Table<UserModel>()
                            .Where(i => i.UserID == id)
                            .FirstOrDefaultAsync();
        }

        /* SELECT*/
        public Task<List<UserModel>> GetUserModel()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        /*GUARDAR Y ACTUALIZAR ()*/
        public Task<int> SaveUserModelAsync(UserModel userModel)
        {
            if (userModel.UserID != 0)
            {
                return _database.UpdateAsync(userModel);
            }
            else
            {
                return _database.InsertAsync(userModel);
            }
        }

        /*ELIMINAR () */
        public Task<int> DeleteUserModelAsync(UserModel userModel)
        {
            return _database.DeleteAsync(userModel);
        }

        public Task<List<UserModel>> GetUsersValidate(string email, string password)
        {
            return _database.QueryAsync<UserModel>("SELECT * FROM UserModel WHERE EmailField = '" + email + "' AND PasswordField = '" + password + "'");
        }

        #endregion


        #region CRUD - PERSON TABLE
        public Task<PersonModel> GetPersonModelAynsc(int id)
        {
            return _database.Table<PersonModel>()
                            .Where(i => i.PersonID == id)
                            .FirstOrDefaultAsync();
        }

        /*SELECT ()*/
        public Task<List<PersonModel>> GetPersonModel()
        {
            return _database.Table<PersonModel>().ToListAsync();
        }

        /*GUARDAR Y ACTUALIZAR ()*/
        public Task<int> SavePersonModelAsync(PersonModel personModel)
        {
            if (personModel.PersonID != 0)
            {
                return _database.UpdateAsync(personModel);
            }
            else
            {
                return _database.InsertAsync(personModel);
            }
        }

        /*ELIMINAR () */
        public Task<int> DeletePersonModelAsync(PersonModel personModel)
        {
            return _database.DeleteAsync(personModel);
        }
        #endregion
         

}
}
