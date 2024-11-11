using UnityEngine;

namespace Shop.View
{
    public class ShopItemViewConfig
    {
        public string ID { get; }
        public string Description { get; }
        public Sprite Sprite { get; }

        public ShopItemViewConfig(string id, string description, Sprite sprite)
        {
            ID = id;
            Description = description;
            Sprite = sprite;
        }
    }
}