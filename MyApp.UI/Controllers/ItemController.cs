using Microsoft.AspNetCore.Mvc;
using MyApp.BLL;
using MyApp.DAL;
using System.Threading.Tasks;

public class ItemController : Controller
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _itemService.GetItemsAsync();
        return View(items);
    }

    [HttpPost]
    public async Task<IActionResult> Add(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            var item = new Item { Name = name };
            await _itemService.AddItemAsync(item);
        }
        return RedirectToAction("Index");
    }
}
