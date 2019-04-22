using System.Collections.Generic;
using Amazon.Lambda.Core;
using LambdaShoppingListWebAPI.Models;
using LambdaShoppingListWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// [assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LambdaShoppingListWebAPI.Controllers
{
    [Route("v1/ShoppingList/[action]")]
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService) => _shoppingListService = shoppingListService; 

        [HttpGet]
        public ActionResult GetShoppingList()
        {
            var result = _shoppingListService.GetItemsFromShoppingList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddItemToShoppingList(ShoppingListModel model)
        {             
            _shoppingListService.AddItemToShoppingList(model);
            return Created("", null);
        }

        [HttpDelete]
        public IActionResult DeleteItemToShoppingList(ShoppingListModel model)
        {             
            _shoppingListService.DeleteItemToShoppingList(model);
            return Ok();
        }
    }
}