using Microsoft.EntityFrameworkCore;
using MyApp.BLL;
using MyApp.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ItemService : IItemService
{
    private readonly AppDbContext _context;

    public ItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task AddItemAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }
}
