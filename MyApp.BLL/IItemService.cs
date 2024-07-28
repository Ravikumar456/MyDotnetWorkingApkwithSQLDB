using MyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.BLL
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task AddItemAsync(Item item);
    }
}
