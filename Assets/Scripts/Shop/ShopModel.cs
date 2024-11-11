using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Shop
{
    public class ShopModel
    {
        private readonly Dictionary<string, ShopItem> _items = new();

        public IEnumerable<IReadOnlyShopItem> Items => _items.Values;

        public ShopModel(IEnumerable<ShopItemConfig> configs)
        {
            var asd = _items.Values;
            if (configs == null)
            {
                Debug.LogError($"{nameof(configs)} is null!");
                return;
            }
            
            foreach (var config in configs)
            {
                if (_items.ContainsKey(config.ID))
                {
                    Debug.LogError($"Item with ID {config.ID} already exist!");
                    continue;
                }

                _items.Add(config.ID, new ShopItem(config));
            }
        }

        public void BuyItem(string id)
        {
            if (_items.TryGetValue(id, out var item))
            {
                item.SetBought();
                return;
            }

            Debug.LogError($"Item with ID {id} doesn't exist!");
        }
        
        public Result<IReadOnlyShopItem> GetItem(string id)
        {
            if (_items.TryGetValue(id, out var item))
            {
                return Result<IReadOnlyShopItem>.Success(item);
            }

            return Result<IReadOnlyShopItem>.Fail();
        }
    }
}