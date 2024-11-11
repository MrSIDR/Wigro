using UnityEngine;

namespace Shop.View
{
    public class ShopItemViewFactory
    {
        private ShopItemView _prefab;
        private readonly Transform _root;

        public ShopItemViewFactory(ShopItemView prefab, Transform root)
        {
            _prefab = prefab;
            _root = root;
        }

        public ShopItemView Create()
        {
            var item = Object.Instantiate(_prefab, _root, false);
            return item;
        }
    }
}