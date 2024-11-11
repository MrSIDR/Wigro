using UnityEngine;

namespace Shop
{
    public class ShopItem : IReadOnlyShopItem
    {
        private readonly string _id;
        private readonly string _name;
        private readonly string _description;
        private readonly Sprite _sprite;
        
        private bool _wasBought;

        public string ID => _id;
        public string Name => _name;
        public string Description => _description;
        public Sprite Sprite => _sprite;
        public bool WasBought => _wasBought;

        public ShopItem(ShopItemConfig config) : this(config.ID, config.Name, config.Description, config.Sprite)
        { }

        public ShopItem(string id, string name, string description, Sprite sprite)
        {
            _id = id;
            _name = name;
            _description = description;
            _sprite = sprite;
        }

        public void SetBought()
        {
            _wasBought = true;
        }
    }
}