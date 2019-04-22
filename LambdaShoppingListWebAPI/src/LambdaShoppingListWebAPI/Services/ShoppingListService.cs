
using System.Collections.Generic;
using LambdaShoppingListWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LambdaShoppingListWebAPI.Services
{
    internal class ShoppingListService : IShoppingListService
    {
        private readonly List<ShoppingListModel> _shoppingListStorage = new List<ShoppingListModel>();

        public void AddItemToShoppingList(ShoppingListModel model)
        {
            _shoppingListStorage.Add(model);
        }

        public void DeleteItemToShoppingList(ShoppingListModel model)
        {
            var item = _shoppingListStorage.Find(l => l.Name == model.Name);
            _shoppingListStorage.Remove(item);
        }

        public IEnumerable<ShoppingListModel> GetItemsFromShoppingList()
        {
            return _shoppingListStorage;
        }
    }
}