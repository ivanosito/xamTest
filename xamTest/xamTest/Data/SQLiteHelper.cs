using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using xamTest.Models;

namespace xamTest.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<User>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(User user)
        {
            if (user.id != 0)
            {
                return db.UpdateAsync(user);
            }
            else
            {
                return db.InsertAsync(user);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync(User user)
        {
            return db.DeleteAsync(user);
        }

        //Read All Items
        public Task<List<User>> GetItemsAsync()
        {
            return db.Table<User>().ToListAsync();
        }


        //Read Item By Id
        public Task<User> GetItemByIdAsync(int userId)
        {
            return db.Table<User>().Where(i => i.id == userId).FirstOrDefaultAsync();
        }


        //Read Item By UserName
        public Task<User> GetItemByUserNameAsync(string SearchedUserName)
        {
            return db.Table<User>().Where(i => i.UserName == SearchedUserName).FirstOrDefaultAsync();
        }
    }
}
