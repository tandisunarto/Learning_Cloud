using LambdaShoppingListWebAPI.Models;
using LambdaShoppingListWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LambdaShoppingListWebAPI.Controllers
{
    [Route("v1/ShoppingList/[action]")]
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService) => _shoppingListService = shoppingListService; 

        [HttpGet]
        public IActionResult GetShoppingList()
        {
            var result = _shoppingListService.GetItemsFromShoppingList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddItemToShoppingList([FromBody]ShoppingListModel model)
        {             
            _shoppingListService.AddItemToShoppingList(model);
            return Created("", null);
        }

        [HttpDelete]
        public IActionResult DeleteItemToShoppingList([FromBody]ShoppingListModel model)
        {             
            _shoppingListService.DeleteItemToShoppingList(model);
            return Ok();
        }
    }
}