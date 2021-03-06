using System.Collections.Generic;
using LambdaShoppingListWebAPI.Models;

namespace LambdaShoppingListWebAPI.Services
{
    public interface IShoppingListService
    {
        IEnumerable<ShoppingListModel> GetItemsFromShoppingList();
        void AddItemToShoppingList(ShoppingListModel model);
        void DeleteItemToShoppingList(ShoppingListModel model);
    }
}