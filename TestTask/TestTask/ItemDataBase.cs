using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TestTask
{
    public class ItemDataBase
    {
        readonly SQLiteAsyncConnection database;

        public ItemDataBase(String path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItems()
        {
            return database.Table<Item>().ToListAsync();
        }
        public Task<Item> GetItem(int id)
        {
            return database.Table<Item>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> InsertItem(Item item)
        {
            return database.InsertAsync(item);
        }
        public Task<int> DeleteItem(Item item)
        {
            return database.DeleteAsync(item);
        }
        public Task<int> DeleteItems()
        {
            return database.ExecuteAsync("delete from [item]");
        }
    }
}
